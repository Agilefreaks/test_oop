# frozen_string_literal: true

require_relative './geo'

module CoffeePlace
  # Helpers for computing distances across our flat Earth
  module EarthDistance
    module_function

    def earth_distance(location_a, location_b)
      lon_delta = wrapped_delta(location_a.lon, location_b.lon, Geo::MAX_LON)
      lat_delta = wrapped_delta(location_a.lat, location_b.lat, Geo::MAX_LAT)

      Math.sqrt(lon_delta**2 + lat_delta**2)
    end

    # Ensure that we can wrap around longitude and latitude
    # This means that if the direct distance is too great we "go the other way",
    # crossing the event horizon, and ending up on the other side of our map.
    #
    def wrapped_delta(coord_a, coord_b, max_distance)
      value = (coord_a - coord_b).abs

      if value <= max_distance
        value
      else
        complement_dinstace(value, max_distance)
      end
    end

    # Go the other way, across the event horizon
    #
    # This distance will be the complement = (total_distance - value),
    # where `total_distance` is twice the `max_distance`, since we have
    # values in the interval [-max_distance, max_distance]
    #
    def complement_dinstace(value, max_distance)
      2 * max_distance - value
    end
  end
end
