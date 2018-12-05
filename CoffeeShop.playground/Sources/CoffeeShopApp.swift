import Foundation

// MARK: - CoffeeShopApp
public struct CoffeeShopApp {

    public enum CustomError: Error {
        case runtimeError(String)
    }

    public let userLocation: Location
    public let shopDataFilename: String

    public init(userLocation: Location, coffeeShopFilename: String) {
        self.userLocation = userLocation
        self.shopDataFilename = coffeeShopFilename
    }

    public func orderedCoffeeShopsClosestToUserLocation() throws -> [(coffeeShop: CoffeeShop, distance: Double)] {
        guard let _ = Bundle.main.url(forResource: shopDataFilename, withExtension: nil) else {
            throw CustomError.runtimeError("\(shopDataFilename) not found in playground Resources file")
        }
        let content = """
                    Starbucks Seattle,9,40
                    Starbucks Moscow,5,12
                    Starbucks Rio De Janeiro,8,15
                    Starbucks Sydney,3,4
                    """
        let lines = content.components(separatedBy: .newlines)
        var result: [(coffeeShop: CoffeeShop, distance: Double)] = []
        for line in lines {
            guard let coffeeShop = CoffeeShop(from: line, separator: ",") else {
                continue
            }
            result.append((coffeeShop: coffeeShop, distance: coffeeShop.location.distanceTo(userLocation)))
        }
        result.sort { $0.distance <= $1.distance}
        return result
    }
}
