import Foundation


public enum CoffeeShopLocationsParserErrors:Error {
    case invalidDataInSource
}

public class CoffeeShopLocationsParser {
    
    public class func parse(inputDataCSVString data:String) throws -> [CoffeeShop] {
        var coffeeShops:[CoffeeShop] = []
        
        for line in data.split(separator: "\n") {
            let values = line.split(separator: ",") // csv format: name,coordinate x,coordinate y
            guard let latitude = Double(values[1]), let longitude = Double(values[2])  else {
                throw CoffeeShopLocationsParserErrors.invalidDataInSource
            }
            coffeeShops.append(CoffeeShop.init(name: String(values[0]), location: Coordinates.init(latitude: latitude, longitude: longitude)))
        }
        
        return coffeeShops
    }
    
}
