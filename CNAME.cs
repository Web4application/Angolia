https://www.algolia.com

        var client = new SearchClient(new SearchConfig("YOUR_APP_ID", "YOUR_ADMIN_API_KEY"));
        string indexName = "my_first_index";

        try
        {
            // 2. Add Data (Indexing)
            Console.WriteLine("Indexing record...");
            var record = new Dictionary<string, string> 
            { 
                { "objectID", "unique-id-123" }, 
                { "name", "Example Product" },
                { "category", "Electronics" }
            };

            var saveResponse = await client.SaveObjectAsync(indexName, record);
            
            // Wait for the indexing task to complete so it's searchable immediately
            await client.WaitForTaskAsync(indexName, saveResponse.TaskId);
            Console.WriteLine("Record indexed successfully!");

            // 3. Search for Data
            Console.WriteLine("Searching for 'Example'...");
            var searchParams = new SearchMethodParams 
            {
                Requests = new List<SearchQuery> 
                {
                    new SearchQuery(new SearchForHits 
                    { 
                        IndexName = indexName, 
                        Query = "Example",
                        HitsPerPage = 5 
                    })
                }
            };

            var results = await client.SearchAsync<Dictionary<string, object>>(searchParams);

            // 4. Display Results
            foreach (var hit in results.Results[0].AsSearchResponse().Hits)
            {
                Console.WriteLine($"- Found: {hit["name"]} (ID: {hit["objectID"]})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
