# frozen_string_literal: true

module CoffeePlace
  # Searches between locations, finding the closest one.
  class Search
    # Search returns the closest 3 locations found by default.
    DEFAULT_NUM_RESULTS = 3

    def initialize(available_locations)
      @locations = available_locations
    end

    # Returns an array of `[distance, location]` tuples,
    # sorted in ascending order of distance to `target_location`
    def find_closest_to(target_location, num_results = DEFAULT_NUM_RESULTS)
      @locations
        .map { |location| [target_location.distance_to(location), location] }
        .sort_by(&:first)
        .take(num_results)
    end
  end
end
