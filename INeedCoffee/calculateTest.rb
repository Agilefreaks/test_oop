require 'test/unit'
require './calculate'

class CalculateTest < Test::Unit::TestCase

  #The distance calculation between Starbucks Sibiu Oituz and the User should be as expected
  def test_CalculateDistanceBetweenUserAndSibiuOituz

    distanceFromUserToCoffeeShop = Array.new
    coffeeShopName = Array.new
    coffeeShopName.push "Starbucks Sibiu Oituz"

    coffeeShopLatitude = Array.new
    coffeeShopLatitude.push 45.7826201

    coffeeShopLongitude = Array.new
    coffeeShopLongitude.push 24.1465759

    Calculate.DistanceBetweenCoffeeShopAndUser(coffeeShopName, coffeeShopLatitude, coffeeShopLongitude, 45.7838552, 24.1515281, distanceFromUserToCoffeeShop)

    assert_equal([0.4078], distanceFromUserToCoffeeShop)

  end
end