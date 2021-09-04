# frozen_string_literal: true

require 'coffee_place/geo'

RSpec.describe CoffeePlace::Geo do
  subject(:geo) { described_class }

  describe '#within_latitude_bounds?' do
    it 'returns true for values within bounds' do
      expect(geo.within_latitude_bounds?(0)).to eq(true)
      expect(geo.within_latitude_bounds?(42.0)).to eq(true)
      expect(geo.within_latitude_bounds?(-42.0)).to eq(true)
    end

    it 'returns true for edge values' do
      expect(geo.within_latitude_bounds?(90.0)).to eq(true)
      expect(geo.within_latitude_bounds?(-90.0)).to eq(true)
    end

    it 'returns false for values outside bounds' do
      expect(geo.within_latitude_bounds?(92.0)).to eq(false)
      expect(geo.within_latitude_bounds?(-92.0)).to eq(false)
    end
  end

  describe '#within_longitude_bounds?' do
    it 'returns true for values within bounds' do
      expect(geo.within_longitude_bounds?(0)).to eq(true)
      expect(geo.within_longitude_bounds?(42.0)).to eq(true)
      expect(geo.within_longitude_bounds?(-42.0)).to eq(true)
    end

    it 'returns true for edge values' do
      expect(geo.within_longitude_bounds?(180)).to eq(true)
      expect(geo.within_longitude_bounds?(-180.0)).to eq(true)
    end

    it 'returns false for values outside bounds' do
      expect(geo.within_longitude_bounds?(182.0)).to eq(false)
      expect(geo.within_longitude_bounds?(-182.0)).to eq(false)
    end
  end
end
