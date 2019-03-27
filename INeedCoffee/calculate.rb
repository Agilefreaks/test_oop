require 'haversine'

class Calculate
  def self.DistanceBetweenCoffeeShopAndUser(coffeeShopName, coffeeShopLatitude,coffeeShopLongitude,userLatitude,userLongitude, distanceFromUserToCoffeeShop)
    begin

      coffeeShopIndex = 0
      coffeeShopName.each do

        distance = Haversine.distance(Float(coffeeShopLatitude[coffeeShopIndex]), Float(coffeeShopLongitude[coffeeShopIndex]), userLatitude, userLongitude)

        distanceFromUserToCoffeeShop.push distance.to_kilometers.round(4)

        coffeeShopIndex += 1
      end
    rescue ArgumentError => e

      invalidNumberError = e.message
      invalidNumber = invalidNumberError.scan(/"([^"]*)"/)
      puts "#{invalidNumber} is not a number"
    rescue TypeError => e
      puts "Value is missing from the CSV File or missing parameters"
    end
  end
end
