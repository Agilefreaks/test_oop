import Foundation


public struct Coordinates {
    
    public let latitude:Double
    public let longitude:Double
    
    // MARK:- Constructor
    public init(latitude:Double, longitude:Double){
        self.latitude  = latitude
        self.longitude = longitude
    }
    
    // MARK:- Public functions
    
    public func distance(to coordinates:Coordinates) -> Double {
        let dX = (self.latitude - coordinates.latitude).magnitude
        let dY = (self.longitude - coordinates.longitude).magnitude
        return sqrt(pow(dX, 2) +  pow(dY, 2))
    }
    
}
