import Foundation

// MARK: - perform unit tests
LocationTest.defaultTestSuite.run()
CoffeeShopTest.defaultTestSuite.run()
CoffeeShopAppTest.defaultTestSuite.run()
print()

// MARK: - main
let app = CoffeeShopApp(userLocation: Location(x: 47.6, y: -122.4), coffeeShopFilename: "coffee_shops.csv")
let orderedCoffeeShops = try app.orderedCoffeeShopsClosestToUserLocation()
for i in 0..<3 {
    let tuple = orderedCoffeeShops[i]
    let distance = String(format: "%.4f", tuple.distance)
    print("\(tuple.coffeeShop.name),\(distance)")
}
