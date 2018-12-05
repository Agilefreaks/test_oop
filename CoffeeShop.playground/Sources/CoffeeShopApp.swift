import Foundation

// MARK: - CoffeeShopApp
public struct CoffeeShopApp {

    public let userLocation: Location
    public let shopDataFilename: String

    public init(userLocation: Location, coffeeShopFilename: String) {
        self.userLocation = userLocation
        self.shopDataFilename = coffeeShopFilename
    }
}
