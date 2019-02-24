import XCTest


public class CoffeeShopLocationsParserTests: XCTestCase {
    
    var coffeeShops:[CoffeeShop]?
    
    public override func setUp() {
        super.setUp()
        let input = "Starbucks Seattle,47.5809,-122.3160"
        coffeeShops = try? CoffeeShopLocationsParser.parse(inputDataCSVString: input)
    }
    
    public func test() {
        XCTAssertNotNil(coffeeShops)
        XCTAssertEqual(coffeeShops![0].name, "Starbucks Seattle")
        XCTAssertEqual(coffeeShops![0].location.latitude, 47.5809)
        XCTAssertEqual(coffeeShops![0].location.longitude, -122.3160)
    }

}
