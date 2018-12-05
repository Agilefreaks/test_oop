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

// MARK: - CoffeeShopApp
struct CoffeeShopApp {

    var user: Location
    var shopDataFilename = ""

    init?(_ arguments: [String]) {
        guard arguments.count == 3,
            let y = Double(arguments[0]),
            let x = Double(arguments[1]),
            CoffeeShopApp.isFilename(arguments[2])
        else {
            return nil
        }
        user = Location(x: x, y: y)
        shopDataFilename = arguments[2]
    }

    static func isFilename(_ value: String) -> Bool {
        guard value.contains("."),
            let first = value.first, first != ".",
            let last = value.last, last != "."
        else {
            return false
        }
        return true
    }

    func closestCoffeeShops(count: Int, coffeeShopsCSV fileContent: String) -> [CoffeeShopWithDistance]? {

        guard let coffeeShops = coffeeShops(fromCSV: fileContent) else {
            return nil
        }

        let coffeeShopsWithDistance = sort(coffeeShops: coffeeShops, byDistanceTo: self.user)

        let itemsToPrint = min(count, coffeeShopsWithDistance.count)
        return Array(coffeeShopsWithDistance.prefix(itemsToPrint))
    }
}


// MARK: - main

var commandLineArguments = CommandLine.arguments
let first = commandLineArguments.removeFirst()
if first.hasSuffix(".app/CoffeeShop") {
    // run from within playground, not command line
    commandLineArguments = ["47.6", "-122.4", "coffee_shops.csv"]
}

done: if let app = CoffeeShopApp(commandLineArguments) {

    guard let documentDirectoryUrl = FileManager.default.urls(for: .documentDirectory, in: .userDomainMask).first else {
        NSLog("Failed retrieving user document directory")
        break done
    }
    let fileUrl = documentDirectoryUrl.appendingPathComponent("Shared Playground Data").appendingPathComponent(app.shopDataFilename)
    var fileContent = ""
    do {
        fileContent = try String(contentsOf: fileUrl, encoding: .utf8)
    } catch {
        NSLog("Failed reading \(app.shopDataFilename) from ~\\Documents\\Shared Playground Data. Error: \(error.localizedDescription)")
        break done
    }

    guard let coffeeShopsWithDistance = app.closestCoffeeShops(count: 3, coffeeShopsCSV: fileContent) else {
        NSLog("Invalid data format")
        break done
    }

    for coffeeShopWithDistance in coffeeShopsWithDistance {
        let distance = String(format: "%.4f", coffeeShopWithDistance.distance)
        NSLog("\(coffeeShopWithDistance.coffeeShop.name),\(distance)")
    }

} else {
    NSLog("invalid paramenters for Coffee Shop application")
}

// MARK: - perform unit tests
LocationTest.defaultTestSuite.run()
CoffeeShopTest.defaultTestSuite.run()
CoffeeShopAppTest.defaultTestSuite.run()
