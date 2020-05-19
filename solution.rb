require_relative 'input_validator'
require_relative 'user'
require_relative 'coffee_shop'
require_relative 'user_coffee_shop_query'

class Solution
  attr_reader :user_x_coordinate, :user_y_coordinate, :csv_file_name, :input

  def initialize(input)
    @input = input
    @user_x_coordinate = input[0].to_f
    @user_y_coordinate = input[1].to_f
    @csv_file_name = input[2]
  end

  def find
    validate_input
    user_coffee_shop_query.show_closest
  end

  def validate_input
    InputValidator.new(input).validate
  end

  def user_coffee_shop_query
    UserCoffeeShopQuery.new(coffee_shop.all, user)
  end

  def coffee_shop
    CoffeeShop.new(csv_file_name)
  end

  def user
    User.new(user_x_coordinate, user_y_coordinate)
  end
end
