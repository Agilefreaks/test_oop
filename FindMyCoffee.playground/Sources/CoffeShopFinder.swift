import Foundation


public class CoffeeShopFinder {
    
    let maxNumberOfLocations = 3
    
    public var availableCoffeeShops:[CoffeeShop]
    public var userLocation:Coordinates
    public var closestCoffeeShops:[CoffeeShop] {
        get {
            return self.discoverClosestLocations()
        }
    }
    
    // MARK:- Constructors
    
    public init(_ coffeeShops:[CoffeeShop], _ userLocation:Coordinates) {
        self.availableCoffeeShops = coffeeShops
        self.userLocation         = userLocation
    }
    
    // MARK:- Private methods
    
    private func discoverClosestLocations() -> [CoffeeShop] {
        
        for coffeeShop in availableCoffeeShops {
            coffeeShop.distanceFromUser = userLocation.distance(to: coffeeShop.location)
        }
        
        availableCoffeeShops.sort { (lshCoffeeShop, rshCoffeeShop) -> Bool in
            return lshCoffeeShop.distanceFromUser < rshCoffeeShop.distanceFromUser
        }
        
        let solution: [CoffeeShop] = Array.init(availableCoffeeShops.prefix(maxNumberOfLocations))
        
        return solution
    }
    
}


