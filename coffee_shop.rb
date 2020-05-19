require 'csv'

class CoffeeShop
  def initialize(csv_file_name)
    @csv_file_name = csv_file_name
  end

  def all
    CSV.read(@csv_file_name).map { |coffee_shop| { name: coffee_shop[0], x: coffee_shop[1], y: coffee_shop[2] } }
  end
end