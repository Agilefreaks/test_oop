import Foundation
import XCTest

extension Location: Equatable {
    public static func == (lhs: Location, rhs: Location) -> Bool {
        return lhs.x == rhs.x && lhs.y == rhs.y
    }
}

public class LocationTest: XCTestCase {

    public func test_location() {
        let location = Location(x: 0, y: 0)
        XCTAssertEqual(location.x, 0.0)
        XCTAssertEqual(location.y, 0.0)
    }

    public func test_distanceToLocation() {
        let locationA = Location(x: -2, y: 1)
        let locationB = Location(x: 1, y: 5)
        XCTAssertEqual(locationA.distanceTo(locationB), 5)
    }
}
