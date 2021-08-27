# frozen_string_literal: true

require_relative './result'
require_relative './geo'

module CoffeePlace
  # Represents a location on the map
  class Location
    include Geo

    attr :lat, :lon, :name

    def initialize(lat:, lon:, name:)
      @lat = lat
      @lon = lon
      @name = name
    end

    def valid_latitude?
      within_latitude_bounds?(@lat)
    end

    def valid_longitude?
      within_longitude_bounds?(@lon)
    end

    def to_s
      "location(lat = #{@lat}, lon: #{@lon}, name: #{@name})"
    end

    class << self
      def validate(lat:, lon:, name:)
        result_lat = parse_coordinate(lat, 'latitude')
        return result_lat unless result_lat.success?

        result_lon = parse_coordinate(lon, 'longitude')
        return result_lon unless result_lon.success?

        location = new(lat: result_lat.value, lon: result_lon.value, name: name.to_s)

        return Result.failure("Invalid latitude: #{lat}") unless location.valid_latitude?
        return Result.failure("Invalid longitude: #{lon}") unless location.valid_longitude?

        Result.success(location)
      rescue ArgumentError => e
        Result.failure(e.message)
      end

      private

      def parse_coordinate(coordinate, label)
        return Result.failure("Missing #{label}") unless coordinate

        value = Float(coordinate)
        Result.success(value)
      rescue ArgumentError
        Result.failure("Invalid #{label}: #{coordinate.inspect}")
      end
    end
  end
end
