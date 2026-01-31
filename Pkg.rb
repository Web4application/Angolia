import Foundation
#if os(Linux) // For linux interop
    import FoundationNetworking
#endif

import Core
import Search

func saveObjectsMovies() async throws {
    let url = URL(string: "https://dashboard.algolia.com/api/1/sample_datasets?type=movie")!
    var data: Data? = nil
    #if os(Linux) // For linux interop
        (data, _) = try await URLSession.shared.asyncData(for: URLRequest(url: url))
    #else
        (data, _) = try await URLSession.shared.data(from: url)
    #endif
    let movies = try JSONDecoder().decode([AnyCodable].self, from: data!)

    // Connect and authenticate with your Algolia app using your app ID and write API key
    let client = try SearchClient(appID: "6O1IQFSZPV", apiKey: "8907cd6a3114f7e70f01270502edb520")

    do {
        // Save records in Algolia index
        try await client.saveObjects(indexName: "movies_index", objects: movies)
    } catch {
        print(error.localizedDescription)
    }
}
