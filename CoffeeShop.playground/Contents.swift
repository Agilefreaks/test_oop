import Foundation

typealias CoffeeShopWithDistance = (coffeeShop: CoffeeShop, distance: Double)

    func coffeeShops(fromCSV content: String) -> [CoffeeShop]? {
        var coffeeShops = [CoffeeShop]()
        let lines = content.components(separatedBy: .newlines)
        for line in lines {
            guard let coffeeShop = CoffeeShop(from: line, separator: ",") else {
                return nil
            }
            coffeeShops.append(coffeeShop)
        }
        return coffeeShops
    }

    func sort(coffeeShops: [CoffeeShop], byDistanceTo location: Location, ascending: Bool = true) -> [CoffeeShopWithDistance] {
        var coffeeShopWithDistance = coffeeShops.map { CoffeeShopWithDistance(coffeeShop: $0, distance: $0.location.distanceTo(location)) }
        coffeeShopWithDistance.sort {
            if ascending {
                return $0.distance < $1.distance
            } else {
                return $0.distance > $1.distance
            }
        }
        return coffeeShopWithDistance
    }

// MARK: - main

let app = CoffeeShopApp(userLocation: Location(x: 47.6, y: -122.4), coffeeShopFilename: "coffee_shops.csv")

//guard let documentDirectoryUrl = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask).first else {
//    NSLog("Failed retrieving user document directory")
//    break done
//}
//let fileUrl = documentDirectoryUrl.appendingPathComponent("Shared Playground Data").appendingPathComponent(app.shopDataFilename)
//var fileContent = ""
//do {
//    fileContent = try String(contentsOf: fileUrl, encoding: .utf8)
//} catch {
//    NSLog("Failed reading \(app.shopDataFilename) from ~\\Documents\\Shared Playground Data. Error: \(error.localizedDescription)")
//    break done
//}
//
//guard let coffeeShopsWithDistance = app.closestCoffeeShops(count: 3, coffeeShopsCSV: fileContent) else {
//    NSLog("Invalid data format")
//    break done
//}
//
//for coffeeShopWithDistance in coffeeShopsWithDistance {
//    let distance = String(format: "%.4f", coffeeShopWithDistance.distance)
//    NSLog("\(coffeeShopWithDistance.coffeeShop.name),\(distance)")
//}

// MARK: - perform unit tests
LocationTest.defaultTestSuite.run()
CoffeeShopTest.defaultTestSuite.run()
CoffeeShopAppTest.defaultTestSuite.run()
