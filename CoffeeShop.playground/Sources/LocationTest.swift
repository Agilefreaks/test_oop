import Foundation
import XCTest


class LocationTest: XCTestCase {
    
    override func setUp() {
    }
    
    override func tearDown() {
    }
    
    func test_location() {
        let location = Location(x: 0, y: 0)
        XCTAssertEqual(location.x, 0.0)
        XCTAssertEqual(location.y, 0.0)
    }
    
    func test_distanceToLocation() {
        let locationA = Location(x: -2, y: 1)
        let locationB = Location(x: 1, y: 5)
        XCTAssertEqual(locationA.distanceTo(locationB), 5)
    }
}
