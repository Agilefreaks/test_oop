import Foundation
import XCTest

class CoffeeShopAppTest: XCTestCase {
    
    override func setUp() {
        
    }
    
    override func tearDown() {
        
    }
    
    func test_applicationValidArguments() {
        let app = CoffeeShopApp(["47.6", "-122.4", "coffee_shop.csv"])
        XCTAssertNotNil(app)
    }
}

CoffeeShopAppTest.defaultTestSuite.run()
