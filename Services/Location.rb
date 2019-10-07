class Location

attr_accessor :xCoord, :yCoord

def get_current_location
  location = Location.new()
  puts "Hello Littla coffee addict, give us your x location"
  location.xCoord = gets
  puts "Awesome, what about your y location?"
  location.yCoord = gets

  return location
end


end
