import XCTest


public class CoordinatesTests:XCTestCase {
    
    var coordinates:Coordinates!
    var userLocationCoordinates:Coordinates!
    
    public override func setUp() {
        super.setUp()
        coordinates             = Coordinates.init(latitude: 47.6 , longitude: -122.4)
        userLocationCoordinates = Coordinates.init(latitude: 47.5869 , longitude: -122.3368)
    }
    
    public func test(){
        XCTAssertNotNil(coordinates)
        XCTAssertEqual(coordinates.latitude, 47.6)
        XCTAssertEqual(coordinates.longitude, -122.4)
    }
    
    public func testDistanceTo() {
        XCTAssertEqual(userLocationCoordinates.distance(to: coordinates), 0.06454339625400246)
    }
    
}
