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
        let compoments = line.components(separatedBy: separator)
        guard !separator.isEmpty,
            compoments.count == 3,
            !compoments[0].isEmpty
            else {
            return nil
        }
        self.init(name: compoments[0], location: Location(x: 47.5809, y: -122.3160))
    }
}
