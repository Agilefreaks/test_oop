import XCTest


public class CoffeeShopFinderTests: XCTestCase {
    
    var coffeeShopFinder:CoffeeShopFinder!
    var closestCoffeeShops:[CoffeeShop]!
    
    public override func setUp() {
        super.setUp()
        let coffeeShops = [
            CoffeeShop.init(name: "Starbucks1", location: Coordinates.init(latitude: 1, longitude: 1)),
            CoffeeShop.init(name: "Starbucks2", location: Coordinates.init(latitude: 2, longitude: 2)),
            CoffeeShop.init(name: "Starbucks3", location: Coordinates.init(latitude: 3, longitude: 3)),
            CoffeeShop.init(name: "Starbucks4", location: Coordinates.init(latitude: 4, longitude: 4)),
        ]
        
        coffeeShopFinder   =  CoffeeShopFinder.init(coffeeShops, Coordinates.init(latitude: 0, longitude: 0))
        closestCoffeeShops =  coffeeShopFinder.closestCoffeeShops
    }
    
    // TODO: implement teardown
    
    public func test() {
        XCTAssertNotNil(coffeeShopFinder)
        XCTAssertNotNil(closestCoffeeShops)
        XCTAssertEqual(closestCoffeeShops.count, 3)
        XCTAssertEqual(closestCoffeeShops.first!.name, "Starbucks1")
     }
}

