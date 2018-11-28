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

class LocationTest: XCTestCase {

    override func setUp() {
    }

    override func tearDown() {
    }

    func test_defaultLocation() {
        let location = Location()
        XCTAssertEqual(location.x, 0.0)
        XCTAssertEqual(location.y, 0.0)
    }

    func test_specificLocation() {
        var location = Location()
        location.x = 1
        location.y = 1
        XCTAssertEqual(location.x, 1)
        XCTAssertEqual(location.y, 1)
    }
}

LocationTest.defaultTestSuite.run()
