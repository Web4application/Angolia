var searchParams = new SearchMethodParams 
{
    Requests = new List<SearchQuery> 
    {
        new SearchQuery(new SearchForHits { IndexName = "products", Query = "camera" }),
        new SearchQuery(new SearchForHits { IndexName = "locations", Query = "camera" }),
        new SearchQuery(new SearchForHits { IndexName = "articles", Query = "camera" })
    }
};
