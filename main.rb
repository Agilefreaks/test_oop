require_relative 'solution'

input = gets.chomp.split
closest_coffee_shops = Solution.new(input).find

closest_coffee_shops.each { |coffee_shop| puts "#{coffee_shop[:name]},#{coffee_shop[:distance]}" }
