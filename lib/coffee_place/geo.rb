# frozen_string_literal: true

module CoffeePlace
  # Constants and helpers for geographic information
  module Geo
    module_function

    # Maximum number of latitude degrees
    MAX_LAT = 90

    # Maximum number of longitude degrees
    MAX_LON = 180

    def within_latitude_bounds?(lat)
      (lat >= -MAX_LAT) && (lat <= MAX_LAT)
    end

    def within_longitude_bounds?(lon)
      (lon >= -MAX_LON) && (lon <= MAX_LON)
    end
  end
end
