import Foundation
import XCTest

public class CoffeeShopAppTest: XCTestCase {

    public override func setUp() {
    }

    public override func tearDown() {
    }

    func test_cofeeShopApp() {
        let userLocation = Location(x: 47.6, y: -122.4)
        let app = CoffeeShopApp(userLocation: userLocation, coffeeShopFilename: "coffee_shops.csv")
        XCTAssertEqual(app.userLocation, Location(x: 47.6, y: -122.4))
        XCTAssertEqual(app.shopDataFilename, "coffee_shops.csv")
    }

}
