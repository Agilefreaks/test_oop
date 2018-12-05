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

    func test_orderedCoffeeShopsClosestToUserLocation() {
        let userLocation = Location(x: 0, y: 0)
        let app = CoffeeShopApp(userLocation: userLocation, coffeeShopFilename: "test_orderedCofeeShopsClosestToUserLocation.csv")
        do {
            let orderedCoffeeShops = try app.orderedCoffeeShopsClosestToUserLocation()
            let expectedResult = [(name: "Starbucks Sydney", distance: 5.0), (name: "Starbucks Moscow", distance: 13.0), (name: "Starbucks Rio De Janeiro", distance: 17.0), (name: "Starbucks Seattle", distance: 41.0)]
            XCTAssertEqual(orderedCoffeeShops.count, expectedResult.count)
            for i in 0...3 {
                XCTAssertEqual(orderedCoffeeShops[i].coffeeShop.name, expectedResult[i].name)
                XCTAssertEqual(orderedCoffeeShops[i].distance, expectedResult[i].distance)
            }
        } catch {
            XCTFail("Failed retrieving ordered coffee shops closest to user location: \(error)")
        }
    }

    func test_orderedCoffeeShopsClosestToUserLocationMissingFile() {
        let userLocation = Location(x: 0, y: 0)
        let app = CoffeeShopApp(userLocation: userLocation, coffeeShopFilename: "missing_file")
        do {
            let _ = try app.orderedCoffeeShopsClosestToUserLocation()
            XCTFail("Should not get here. There should be no missing_file in playground Resources folder.")
        } catch {
            XCTAssertNotNil(error)
        }
    }
}
