import Foundation
import XCTest

struct CoffeeShopApp {

    init?(_ arguments: [String]) {
        guard arguments.count == 3,
            let y = Double(arguments[0]),
            let x = Double(arguments[1])
        else {
            return
        }
    }
}

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
