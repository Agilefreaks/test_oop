# frozen_string_literal: true

require 'coffee_place/earth_distance'
require 'coffee_place/location'

RSpec.describe CoffeePlace::EarthDistance do
  subject(:earth) { described_class }

  let(:location_a) { CoffeePlace::Location.new(lat: 0, lon: 0, name: 'Location A') }
  let(:location_b) { CoffeePlace::Location.new(lat: 0, lon: 0, name: 'Location B') }

  describe 'earth_distance' do
    it 'computes distance on a plane' do
      location_a.lat = 3.0
      location_b.lon = 4.0

      expect(earth.earth_distance(location_a, location_b)).to be_almost_eq(5.0)
    end
  end

  describe 'wrapped_delta' do
    context 'for longitude' do
      it 'returns absolute value of difference' do
        expect(longitude_delta(62, 44)).to be_almost_eq(18)
        expect(longitude_delta(-10.2, -4.2)).to be_almost_eq(6)
        expect(longitude_delta(30, -20.8)).to be_almost_eq(50.8)
        expect(longitude_delta(-142, 10.6)).to be_almost_eq(152.6)
      end

      it 'wraps around when delta too great' do
        expect(longitude_delta(162, -100)).to be_almost_eq(98)      # (360 - (162 + 100)
        expect(longitude_delta(-142, 40.6)).to be_almost_eq(177.4)  # (360 - (142 + 40.6)
      end

      def longitude_delta(lon_a, lon_b)
        earth.wrapped_delta(lon_a, lon_b, CoffeePlace::Geo::MAX_LON)
      end
    end

    context 'for latitude' do
      it 'returns absolute value of difference' do
        expect(latitude_delta(62, 44)).to be_almost_eq(18)
        expect(latitude_delta(-10.2, -4.2)).to be_almost_eq(6)
        expect(latitude_delta(30, -20.8)).to be_almost_eq(50.8)
      end

      it 'wraps around when delta too great' do
        expect(latitude_delta(62, -80.3)).to be_almost_eq(37.7) # (180 - (62 + 80.3))
        expect(latitude_delta(-82, 10.6)).to be_almost_eq(87.4) # (180 - (82 + 10.6))
      end

      def latitude_delta(lat_a, lat_b)
        earth.wrapped_delta(lat_a, lat_b, CoffeePlace::Geo::MAX_LAT)
      end
    end
  end
end
