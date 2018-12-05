import Foundation

// MARK: - Location
public struct Location {

    public let x: Double
    public let y: Double

    public init(x: Double, y: Double) {
        self.x = x
        self.y = y
    }

    public func distanceTo(_ location: Location) -> Double {
        return sqrt( pow(self.x - location.x, 2) + pow(self.y - location.y, 2) )
    }
}
