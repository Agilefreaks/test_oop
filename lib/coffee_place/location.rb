# frozen_string_literal: true

require_relative './result'
require_relative './geo'
require_relative './earth_distance'

module CoffeePlace
  # Represents a location on the map
  class Location
    include Geo
    include EarthDistance

    attr_accessor :lat, :lon, :name, :errors

    def initialize(lat:, lon:, name:)
      @lat = lat
      @lon = lon
      @name = name
    end

    def distance_to(other_location)
      earth_distance(self, other_location)
    end

    def valid_latitude?
      return false unless @lat

      within_latitude_bounds?(@lat)
    end

    def valid_longitude?
      return false unless @lon

      within_longitude_bounds?(@lon)
    end

    def to_s
      "location(lat = #{@lat}, lon: #{@lon}, name: #{@name})"
    end

    def ==(other)
      same_place?(other) && (@name == other.name)
    end

    def same_place?(other)
      (@lat == other.lat) && (@lon == other.lon)
    end

    def valid?
      check_validation_errors
      @errors.empty?
    end

    private

    def check_validation_errors
      @errors = []

      normalize_lat
      normalize_lon

      # Guard clause returning early in case latitude / longitude are invalid
      return if @errors.any?

      @errors << "Invalid latitude: #{lat}" unless valid_latitude?
      @errors << "Invalid longitude: #{lon}" unless valid_longitude?

      @errors
    end

    def normalize_lat
      result = parse_coordinate(lat, 'latitude')

      if result.success?
        @lat = result.value
      else
        @lat = nil
        @errors << result.error
      end
    end

    def normalize_lon
      result = parse_coordinate(lon, 'longitude')

      if result.success?
        @lon = result.value
      else
        @lon = nil
        @errors << result.error
      end
    end

    def parse_coordinate(coordinate, label)
      return Result.failure("Missing #{label}") unless coordinate

      value = Float(coordinate)
      Result.success(value)
    rescue ArgumentError
      Result.failure("Invalid #{label}: #{coordinate.inspect}")
    end
  end
end
