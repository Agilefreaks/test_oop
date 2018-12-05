import Foundation

// MARK: - CoffeeShop
public struct CoffeeShop {

    public let name: String
    public let location: Location

    public init(name: String, location: Location) {
        self.name = name
        self.location = location
    }

    /// Creates a new instance from the given string by extracting its data delimited by separator
    ///
    /// This function throws an error if line does not have the following format:
    /// <Name>separator<Y Coordinate>separator<X Coordinate>
    ///
    /// - Parameter line: The string from where to extract data for the new instance.
    /// - Parameter separator: The sequence that separates the data.
    public init?(from line: String, separator: String) {
        let compoments = line.components(separatedBy: separator)
        guard !separator.isEmpty,
            compoments.count == 3,
            !compoments[0].isEmpty,
            let x = Double(compoments[2]),
            let y = Double(compoments[1])
            else {
            return nil
        }
        self.init(name: compoments[0], location: Location(x: x, y: y))
    }
}
