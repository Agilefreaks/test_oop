require 'test/unit'

class DisplayTest < Test::Unit::TestCase

  #The output of the three closest coffee shops should be as expected
  def test_ThreeClosestCoffeeShopsOutputShouldBeAsExpectedResult
    puts "• The output of the three closest coffee shops should be as expected"
    assert_equal("Starbucks Sibiu Oituz, 0.8857
Starbucks Sibiu Piata Mare, 2.4913
Starbucks Cluj Iulius Mall, 117.9905\n", %x( ruby coffeeShop.rb 45.7838552 24.1515281 coffee_shops.csv ))
  end

  #DisplayCoffeeShop three closest Coffee Shops missing parameters should throw TypeError
  def test_ThreeClosestCoffeeShopsToUserWithMissingParameters
    puts "• Three closest Coffee Shops missing parameters should throw TypeError"
    %x( ruby coffeeShop.rb 45.7838552 )
  end

  #DisplayCoffeeShop three closest Coffee Shops incorrect arguments should throw ArgumentError
  def test_DisplayThreeClosestCoffeeShopsIncorrectArguments
    puts "• Three closest Coffee Shops incorrect arguments should throw ArgumentError"
    %x( ruby coffeeShop.rb 45.7838552 aa coffee_shops.csv )
  end
end