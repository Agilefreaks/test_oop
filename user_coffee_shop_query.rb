require_relative 'distance_calculator'

class UserCoffeeShopQuery
  def initialize(coffee_shops, user)
    @coffee_shops = coffee_shops
    @user = user
  end

  def result
    distances.sort_by { |coffee_shop| coffee_shop[:distance] }.first(3)
  end

  private

  def distances
    @coffee_shops.map { |coffee_shop| { name: coffee_shop.name, distance: distance(coffee_shop) } }
  end

  def distance(coffee_shop)
    DistanceCalculator.calculate(@user, coffee_shop)
  end
end