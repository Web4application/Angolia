var settings = new IndexSettings
{
    // Records matching 'Name' will rank higher than 'Category'
    SearchableAttributes = new List<string> { "Name", "Category" },
    
    // Add custom ranking (e.g., sort by popularity if you have that field)
    CustomRanking = new List<string> { "desc(Popularity)" }
};

await client.SetSettingsAsync(indexName, settings);
Console.WriteLine("Index settings updated!");

// 1. Create a typed record
var record = new Product 
{ 
    ObjectID = "unique-id-123", 
    Name = "Example Product", 
    Category = "Electronics" 
};

// 2. Index the record (Typed)
var saveResponse = await client.SaveObjectAsync(indexName, record);
await client.WaitForTaskAsync(indexName, saveResponse.TaskId);

// 3. Search for data (Typed)
var searchParams = new SearchMethodParams 
{
    Requests = new List<SearchQuery> 
    {
        new SearchQuery(new SearchForHits 
        { 
            IndexName = indexName, 
            Query = "Example" 
        })
    }
};

// Specify <Product> to automatically deserialize hits into Product objects
var results = await client.SearchAsync<Product>(searchParams);

// 4. Display Results with IntelliSense support
foreach (var hit in results.Results[0].AsSearchResponse<Product>().Hits)
{
    Console.WriteLine($"- Found: {hit.Name} (ID: {hit.ObjectID})");
}
