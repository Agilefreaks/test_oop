dirPath = File.dirname(File.dirname(File.expand_path(__FILE__)))
load dirPath + "/CoffeeShopApp/Objects/CoffeeShop.rb"
load dirPath + "/CoffeeShopApp/Services/CsvParser.rb"
load dirPath + "/CoffeeShopApp/Services/Location.rb"
load dirPath + "/CoffeeShopApp/Services/DistanceService.rb"

myParser = CsvParser.new()
shopsList = myParser.get_content

location = Location.new()
currentLocation = location.get_current_location

distanceService = DistanceService.new()
result = distanceService.get_distance(shopsList, currentLocation).first(3)

result.each { |x| puts (x.name + "," + x.distance.to_s)}


#shopsList.each { |x|  puts x.name}
