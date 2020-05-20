require_relative 'input_validator'
require_relative 'user'
require_relative 'user_coffee_shop_query'
require_relative 'coffee_shop'
class Solution
  attr_reader :user_x_coordinate, :user_y_coordinate, :csv_file_name, :input

  def initialize(input)
    @input = input
    @user_x_coordinate = input[0].to_f
    @user_y_coordinate = input[1].to_f
    @csv_file_name = input[2]
  end

  def find
    input_validator.validate
    user_coffee_shop_query.result
  end

  private

  def input_validator
    @input_validator ||= InputValidator.new(input)
  end

  def user_coffee_shop_query
    UserCoffeeShopQuery.new(coffee_shops, user)
  end

  def coffee_shops
    file_entries.map { |name, x, y| CoffeeShop.new(name, x, y) }
  end

  def file_entries
    input_validator.file_entries
  end

  def user
    User.new(user_x_coordinate, user_y_coordinate)
  end
end
