

public class FindMyCoffeeApp {
    
    private var userLocation:Coordinates!
    private var coffeeShopsDatabase:String!

    lazy var availableCoffeeShops:[CoffeeShop]? = {
        return parseCoffeeShopDatabase()
    }()
    
    // MARK:- Constructor
    
    public init(_ userLocation:Coordinates, coffeeShopsDatabase:String) {
        self.userLocation       = userLocation
        self.coffeeShopsDatabase = coffeeShopsDatabase
    }
    
    // MARK:- Public methods
    
    public func findSolution() -> [CoffeeShop] {
        guard let coffeeShops = availableCoffeeShops, coffeeShops.count > 0 else {
            print("Error. Solution canot be printed")
            return []
        }
        
        let finder = CoffeeShopFinder.init(coffeeShops, userLocation)
        
        return finder.closestCoffeeShops
    }
    
    public func showSolution() {
        for coffeeShop in findSolution()  {
            print(coffeeShop.formattedDescription)
        }
    }
    
    // MARK:- Private methods

    private func parseCoffeeShopDatabase() -> [CoffeeShop]? {
        do {
            
            return try CoffeeShopLocationsParser.parse(inputDataCSVString: coffeeShopsDatabase)
            
        } catch CoffeeShopLocationsParserErrors.invalidDataInSource {
            print("Error. Invalid informations in database.")
        } catch {
            print("Unknown error occured.")
        }
        
        return nil
    }
    
}
