# frozen_string_literal: true

require 'coffee_place/location'
require 'coffee_place/search'

RSpec.describe CoffeePlace::Search do
  subject(:search) { described_class.new(locations) }

  describe '#find_closest_to' do
    context 'with main example locations' do
      let(:target_location) { CoffeePlace::Location.new(lat: 47.6, lon: -122.4, name: 'User location') }

      let(:locations) do
        [
          CoffeePlace::Location.new(lat: 47.5809, lon: -122.316, name: 'Coffee Shop Seattle'),
          CoffeePlace::Location.new(lat: 37.5209, lon: -122.334, name: 'Coffee Shop SF'),
          CoffeePlace::Location.new(lat: 55.752047, lon: 37.595242, name: 'Coffee Shop Moscow'),
          CoffeePlace::Location.new(lat: 47.5869, lon: -122.3368, name: 'Coffee Shop Seattle2'),
          CoffeePlace::Location.new(lat: -22.923489, lon: -43.234418, name: 'Coffee Shop Rio De Janeiro'),
          CoffeePlace::Location.new(lat: -33.871843, lon: 151.206767, name: 'Coffee Shop Sydney')
        ]
      end

      let(:expected_results) do
        [
          ['Coffee Shop Seattle2', 0.0645],
          ['Coffee Shop Seattle', 0.0861],
          ['Coffee Shop SF', 10.0793]
        ]
      end

      it 'returns closest locations to target' do
        expect_to_match_locations(
          search.find_closest_to(target_location),
          expected_results
        )
      end

      it 'allows us to ask for more results' do
        # Add two more expected results
        expected_results << ['Coffee Shop Rio De Janeiro', 106.02241]
        expected_results << ['Coffee Shop Sydney', 118.7495]

        expect_to_match_locations(
          search.find_closest_to(target_location, 5),
          expected_results
        )
      end
    end
  end

  # Helpers
  def expect_to_match_locations(closest, expected_results)
    expect(closest.size).to eq(expected_results.size)

    closest.zip(expected_results) do |(distance, location), (expected_name, expected_distance)|
      expect(distance).to be_almost_eq(expected_distance)
      expect(location).to have_attributes(name: expected_name)
    end
  end
end
