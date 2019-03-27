class Display

  def self.ThreeClosestCoffeeShopsToUser(coffeeShopName, distanceFromUserToCoffeeShop, sortedDistanceFromUserToCoffeeShop)
    indexOfSortedCoffeeShopsByDistance = 0
    maximumNumberOfCoffeeShops = 2

    until indexOfSortedCoffeeShopsByDistance > maximumNumberOfCoffeeShops do
      coffeeShopIndex = distanceFromUserToCoffeeShop.index(sortedDistanceFromUserToCoffeeShop[indexOfSortedCoffeeShopsByDistance])
      puts "#{coffeeShopName[coffeeShopIndex]}, #{distanceFromUserToCoffeeShop[coffeeShopIndex]}"
      indexOfSortedCoffeeShopsByDistance += 1
    end
  end

end
