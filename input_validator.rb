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

  def file_entries
    @file_entries ||= CSV.read(filename)
  end

  private

  def valid_input?
    valid_file? && valid_user_coordinates?
  end

  def valid_file?
    File.file?(filename)
  rescue
    false
  end

  def valid_user_coordinates?
    x_coordinate.numeric? && y_coordinate.numeric?
  end

  def valid_file_entries?(file_entries)
    file_entries.each do |entry|
      coffe_shop_name_present = !entry[0].empty?
      coffe_shop_name_position_valid = entry[1].numeric? && entry[2].numeric?
      return false unless coffe_shop_name_present && coffe_shop_name_position_valid
    end
    true
  rescue
    false
  end
end