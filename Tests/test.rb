dirPath = File.dirname(File.dirname(File.expand_path(__FILE__)))
load dirPath + "/Objects/CoffeeShop.rb"
load dirPath + "/Services/CsvParser.rb"
load dirPath + "/Services/Location.rb"
load dirPath + "/Services/DistanceService.rb"

require 'test/unit'

class My_test <Test::Unit::TestCase

  def test_not_null_file
    assert_not_nil( CsvParser.new.get_content)
  end

  def test_pow2
    assert_equal(64,DistanceService.new.pow2(8))
  end

  def test_location_algorithm
    myParser = CsvParser.new()
    shopsList = myParser.get_content

    coffeeShop = CoffeeShop.new()


    currentLocation = Location.new()
    currentLocation.xCoord = 47.6
    currentLocation.yCoord = -122.4

    distanceService = DistanceService.new()

    result = distanceService.get_distance(shopsList, currentLocation)

    assert_equal(0.0645, result[0].distance)
  end
end
