require 'test/unit'
require './import'

class ImportTest < Test::Unit::TestCase

  #The parsed CSV file has the same values as the expected result
  def test_ParsedCSVFileShouldBeAsExpectedResult

    expectedCSVDataResult = Array.new

    expectedCSVDataResult.push "Starbucks Sibiu Oituz, 45.7826201, 24.1465759",
                               "Starbucks Bucuresti Calea Victoriei, 44.4514467, 26.0827712",
                               "Starbucks Vienna, 48.1817174, 16.3798455",
                               "Starbucks Sibiu Piata Mare, 45.7973354, 24.1503473",
                               "Starbucks Andorra la Vella, 42.5080922, 1.5291981",
                               "Starbucks Cluj Iulius Mall, 46.771803, 23.6234979"

    actualCSVDataResult = Array.new

    coffeeShopFileName = "coffee_shops.csv"

    coffeeShopName = Array.new
    coffeeShopLatitude = Array.new
    coffeeShopLongitude = Array.new

    Import.CSVDataIntoCoffeeShop(coffeeShopFileName, coffeeShopName, coffeeShopLatitude, coffeeShopLongitude)

    coffeeShopIndex = 0

    coffeeShopName.each do
      actualCSVDataResult.push "#{coffeeShopName[coffeeShopIndex]}, #{coffeeShopLatitude[coffeeShopIndex]}, #{coffeeShopLongitude[coffeeShopIndex]}"
      coffeeShopIndex += 1
    end

    puts "• The parsed CSV file has the same values as the expected result"
    assert_equal(expectedCSVDataResult, actualCSVDataResult)
  end
end
