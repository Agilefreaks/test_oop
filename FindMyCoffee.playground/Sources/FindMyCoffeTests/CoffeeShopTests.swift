import XCTest


public class CoffeeShopTests:XCTestCase {
    
    var coffeeShop:CoffeeShop!
    
    public override func setUp() {
        super.setUp()
        coffeeShop = CoffeeShop.init(name: "Starbucks Seattle", location: Coordinates.init(latitude: 0, longitude: 0))
    }
    
    public func test(){
        XCTAssertNotNil(coffeeShop)
        XCTAssertEqual(coffeeShop.name, "Starbucks Seattle")
    }
    
}
