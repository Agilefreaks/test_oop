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
            !compoments[0].isEmpty,
            let x = Double(compoments[1]),
            let y = Double(compoments[2])
            else {
            return nil
        }
        self.init(name: compoments[0], location: Location(x: x, y: y))
    }
}
