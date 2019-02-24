import Foundation


public class CoffeeShop {

    public let name:String
    public let location:Coordinates
    public var distanceFromUser:Double
    public var formattedDescription:String {
        get {
            return String.init(format: "%@,%.04f", self.name, self.distanceFromUser)
        }
    }

    // MARK:- Constructor

    public init(name:String, location:Coordinates) {
        self.name             = name
        self.location         = location
        self.distanceFromUser = 0
    }

}
