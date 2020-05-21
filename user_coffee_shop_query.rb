require_relative 'distance_calculator'

class UserCoffeeShopQuery
  attr_reader :coffee_shops

  def initialize(coffee_shops, user)
    @coffee_shops = coffee_shops
    @user = user
  end

  def result
    distances.min(3).map { |distance| { name: coffee_shops[distances.index(distance)].name, distance: distance } }
  end

  private

  def distances
    @distances ||= coffee_shops.map { |coffee_shop| distance(coffee_shop) }
  end

  def distance(coffee_shop)
    DistanceCalculator.calculate(@user, coffee_shop)
  end
end