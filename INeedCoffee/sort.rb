class Sort
  def self.DistanceBetweenCoffeeShopAndUser(coffeeShopName, distanceFromUserToCoffeeShop, sortedDistanceFromUserToCoffeeShop)

    distanceFromUserToCoffeeShop = distanceFromUserToCoffeeShop.sort

    coffeeShopIndex = 0

    coffeeShopName.each do
      sortedDistanceFromUserToCoffeeShop[coffeeShopIndex] = distanceFromUserToCoffeeShop[coffeeShopIndex]
      coffeeShopIndex += 1
    end

  end
end
