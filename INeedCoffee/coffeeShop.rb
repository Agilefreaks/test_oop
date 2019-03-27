require './calculate'
require './import'
require './display'
require './sort'

class CoffeeShop
  def self.INeedCoffee()
    userLatitude = Float(ARGV[0])
    userLongitude = Float(ARGV[1])
    coffeeShopFileName = ARGV[2]

    coffeeShopName = Array.new
    coffeeShopLatitude = Array.new
    coffeeShopLongitude = Array.new
    distanceFromUserToCoffeeShop = Array.new
    sortedDistanceFromUserToCoffeeShop = Array.new

    Import.CSVDataIntoCoffeeShop(coffeeShopFileName, coffeeShopName, coffeeShopLatitude, coffeeShopLongitude)
    Calculate.DistanceBetweenCoffeeShopAndUser(coffeeShopName, coffeeShopLatitude, coffeeShopLongitude, userLatitude, userLongitude, distanceFromUserToCoffeeShop)
    Sort.DistanceBetweenCoffeeShopAndUser(coffeeShopName, distanceFromUserToCoffeeShop, sortedDistanceFromUserToCoffeeShop)
    Display.ThreeClosestCoffeeShopsToUser(coffeeShopName, distanceFromUserToCoffeeShop, sortedDistanceFromUserToCoffeeShop)

  end
end
CoffeeShop.INeedCoffee