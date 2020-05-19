require 'csv'
require_relative 'string'

class InputValidator
  attr_reader :x_coordinate, :y_coordinate, :filename
  def initialize(input)
    @x_coordinate = input[0]
    @y_coordinate = input[1]
    @filename = input[2]
  end

  def validate
    raise 'Invalid input: check correctness of arguments, filename or file entries' unless valid_input?
  end

  def valid_input?
    valid_file? && valid_user_coordinates? && valid_file_entries?
  end

  def valid_file?
    CSV.read(filename)
  rescue
    false
  end

  def valid_user_coordinates?
    x_coordinate.numeric? && y_coordinate.numeric?
  end

  def valid_file_entries?
    CSV.read(filename).each do |entry|
      coffe_shop_name_present = !entry[0].empty?
      coffe_shop_name_position_valid = entry[1].numeric? && entry[2].numeric?
      return false unless coffe_shop_name_present && coffe_shop_name_position_valid
    end
    true
  end
end