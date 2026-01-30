// Example Logic for SEEKIT
var searchResults = await client.SearchAsync<Product>(params);
string context = string.Join("\n", searchResults.Results[0].AsSearchResponse().Hits.Select(h => h.Description));

string prompt = $"Based on these products: {context}, answer the user: {userQuery}";
// Send 'prompt' to your Llama LLM...
