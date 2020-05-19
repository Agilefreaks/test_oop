require_relative 'distance_calculator'

class UserCoffeeShopQuery
  attr_reader :distances

  def initialize(coffee_shops, user)
    @coffee_shops = coffee_shops
    @user = user
  end

  def calculate_distances
    @distances = @coffee_shops.map do |coffee_shop|
      distance = DistanceCalculator.calculate(@user, coffee_shop[:x].to_f, coffee_shop[:y].to_f)
      { name: coffee_shop[:name], distance: distance }
    end
  end

  def show_closest
    calculate_distances
    @distances.sort_by { |coffee_shop| coffee_shop[:distance] }.first(3).each do |coffee_shop|
      puts "#{coffee_shop[:name]},#{coffee_shop[:distance]}"
    end
  end
end