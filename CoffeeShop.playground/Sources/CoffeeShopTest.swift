import Foundation
import XCTest

public class CoffeeShopTest: XCTestCase {

    public func test_coffeeShop() {
        let coffeeShop = CoffeeShop(name: "Starbucks Seattle", location: Location(x: 47.5809, y: -122.3160))
        XCTAssertEqual(coffeeShop.name, "Starbucks Seattle")
        XCTAssertEqual(coffeeShop.location, Location(x: 47.5809, y: -122.3160))
    }

    public func test_coffeeShopFromString() {
        continueAfterFailure = false
        let coffeeShop = CoffeeShop(from: "Starbucks Seattle,-122.3160,47.5809", separator: ",")
        XCTAssertNotNil(coffeeShop)
        XCTAssertEqual(coffeeShop!.name, "Starbucks Seattle")
        XCTAssertEqual(coffeeShop!.location, Location(x: 47.5809, y: -122.3160))
    }

    public func test_coffeeShopFromStringEmptySeparator() {
        let coffeeShop = CoffeeShop(from: "Starbucks Seattle,47.5809,-122.3160", separator: "")
        XCTAssertNil(coffeeShop)
    }

    public func test_coffeeShopFromStringLessData() {
        let coffeeShop = CoffeeShop(from: "Starbucks Seattle,47.5809", separator: ",")
        XCTAssertNil(coffeeShop)
    }

    public func test_coffeeShopFromStringMoreData() {
        let coffeeShop = CoffeeShop(from: "Starbucks Seattle,47.5809,-122.3160,more,data", separator: ",")
        XCTAssertNil(coffeeShop)
    }

    public func test_coffeeShopFromStringEmptyName() {
        let coffeeShop = CoffeeShop(from: ",47.5809,-122.3160", separator: ",")
        XCTAssertNil(coffeeShop)
    }

    public func test_coffeeShopFromStringInvalidX() {
        let coffeeShop = CoffeeShop(from: "Starbucks Seattle,47.5809invalid,-122.3160", separator: ",")
        XCTAssertNil(coffeeShop)
    }

    public func test_coffeeShopFromStringInvalidY() {
        let coffeeShop = CoffeeShop(from: "Starbucks Seattle,47.5809,-122.3160invalid", separator: ",")
        XCTAssertNil(coffeeShop)
    }

}
