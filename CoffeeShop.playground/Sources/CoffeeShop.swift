import Foundation

// MARK: - CoffeeShop
public struct CoffeeShop {

    public let name: String
    public let location: Location

    public init(name: String, location: Location) {
        self.name = name
        self.location = location
    }

    public init?(from line: String, separator: String) {
        guard !separator.isEmpty else {
            return nil
        }
        self.init(name: "Starbucks Seattle", location: Location(x: 47.5809, y: -122.3160))
    }
}
