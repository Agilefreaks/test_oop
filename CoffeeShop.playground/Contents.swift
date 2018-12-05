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


// MARK: - unit tests

// uncomment to run tests

/*
import XCTest

class CoffeeShopAppTest: XCTestCase {

    override func setUp() {
    }

    override func tearDown() {
    }

    func test_applicationValidArguments() {
        let app = CoffeeShopApp(["47.6", "-122.4", "coffee_shop.csv"])
        XCTAssertNotNil(app)
        XCTAssertEqual(app!.user.y, 47.6)
        XCTAssertEqual(app!.user.x, -122.4)
        XCTAssertEqual(app!.shopDataFilename, "coffee_shop.csv")
    }

    func test_applicationNotEnoughArguments() {
        let app = CoffeeShopApp(["47.6", "-122.4"])
        XCTAssertNil(app)
    }

    func test_applicationYNotDouble() {
        let app = CoffeeShopApp(["47.6.5", "-122.4", "coffee_shop.csv"])
        XCTAssertNil(app)
    }

    func test_applicationXNotDouble() {
        let app = CoffeeShopApp(["47.6", "-122b", "coffee_shop.csv"])
        XCTAssertNil(app)
    }

    func test_isFilename() {
        let isFilename = CoffeeShopApp.isFilename("coffee_shop.csv")
        XCTAssertTrue(isFilename)
    }

    func test_isNotFilename() {
        let isFilename = CoffeeShopApp.isFilename("coffee_shop_csv")
        XCTAssertFalse(isFilename)
    }

    func test_isNotFilenameNoName() {
        let isFilename = CoffeeShopApp.isFilename(".csv")
        XCTAssertFalse(isFilename)
    }

    func test_isNotFilenameNoExtension() {
        let isFilename = CoffeeShopApp.isFilename("coffee_shop.")
        XCTAssertFalse(isFilename)
    }

    func test_3ClosestCoffeeShops() {
        let app = CoffeeShopApp(["47.6", "-122.4", "coffee_shop.csv"])
        XCTAssertNotNil(app)
        let fileContent = """
                        Starbucks Seattle,47.5809,-122.3160
                        Starbucks SF,37.5209,-122.3340
                        Starbucks Moscow,55.752047,37.595242
                        Starbucks Seattle2,47.5869,-122.3368
                        Starbucks Rio De Janeiro,-22.923489,-43.234418
                        Starbucks Sydney,-33.871843,151.206767
                        """

        guard let coffeeShopsWithDistance = app!.closestCoffeeShops(count: 3, coffeeShopsCSV: fileContent) else {
            NSLog("Invalid data format")
            return
        }

        for coffeeShopWithDistance in coffeeShopsWithDistance {
            let distance = String(format: "%.4f", coffeeShopWithDistance.distance)
            print("\(coffeeShopWithDistance.coffeeShop.name),\(distance)")
        }
    }

}

*/

LocationTest.defaultTestSuite.run()
CoffeeShopTest.defaultTestSuite.run()
//CoffeeShopAppTest.defaultTestSuite.run()
