import PackageDescription

let package = Package(
    name: "Integration",
    platforms: [
        .macOS(.v11)
    ],
    dependencies: [
        .package(url: "https://github.com/algolia/algoliasearch-client-swift", from: "9.7.4"),
    ],
    targets: [
        .executableTarget(
            name: "Integration",
            dependencies: [
                .product(name: "Search", package: "algoliasearch-client-swift")
            ]
        )
    ]
)
