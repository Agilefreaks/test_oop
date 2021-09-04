# frozen_string_literal: true

require 'coffee_place/location'

RSpec.describe CoffeePlace::Location do
  subject(:location) { described_class.new(lat: 22, lon: 42, name: 'Funkytown') }

  it 'returns location information' do
    expect(location).to have_attributes(
      lat: 22,
      lon: 42,
      name: 'Funkytown'
    )
  end

  describe '#distance_to' do
    subject(:location) do
      described_class.new(
        lat: 47.6,
        lon: -122.4,
        name: 'Current user location'
      )
    end

    let(:seattle) do
      described_class.new(
        lat: 47.5809,
        lon: -122.3160,
        name: 'Coffee Shop Seattle'
      )
    end

    let(:downtown) do
      described_class.new(
        lat: 47.5869,
        lon: -122.3368,
        name: 'Coffee Shop Downtown'
      )
    end

    let(:san_fransisco) do
      described_class.new(
        lat: 37.5209,
        lon: -122.3340,
        name: 'Coffee Shop San Francisco'
      )
    end

    it 'returns distance to other locations' do
      expect(location.distance_to(downtown)).to be_almost_eq(0.0645)
      expect(location.distance_to(seattle)).to be_almost_eq(0.0861)
      expect(location.distance_to(san_fransisco)).to be_almost_eq(10.0793)
    end

    context 'when locations are across 180 meridian' do
      let(:honolulu) do
        described_class.new(
          lat: 21.350601,
          lon: -157.933155,
          name: 'Coffee Shop Honolulu Hawaii'
        )
      end

      let(:tokyo) do
        described_class.new(
          lat: 35.681933,
          lon: 139.763514,
          name: 'Coffee Shop Tokyo'
        )
      end

      it 'returns correct distance between locations' do
        expect(honolulu.distance_to(tokyo)).to be_almost_eq(63.9303)
      end
    end

    context 'when location are far but both close to the poles' do
      # https://en.wikipedia.org/wiki/Longyearbyen
      let(:northernmost_town) do
        described_class.new(
          lat: 78.13,
          lon: 15.38,
          name: 'Coffee Shop Longyearbyen Norway'
        )
      end

      # https://en.wikipedia.org/wiki/Ushuaia
      let(:southernmost_town) do
        described_class.new(
          lat: -54.48,
          lon: 68.18,
          name: 'Coffee Shop Ushuaia Argentina'
        )
      end

      it 'returns correct distance between locations' do
        expect(northernmost_town.distance_to(southernmost_town)).to be_almost_eq(142.7349)
      end
    end
  end

  describe 'same_place?' do
    subject(:location) { described_class.new(lat: 1.0, lon: 2.0, name: 'Location') }
    subject(:other) { described_class.new(lat: 1.0, lon: 2.0, name: 'Other') }

    it 'is same place as another location when coordinates are the same' do
      expect(location).to be_same_place(other)
    end

    it 'is not same place as another location when lat differs' do
      other.lat = 3

      expect(location).not_to be_same_place(other)
    end

    it 'is not same place as another location when lon differs' do
      other.lon = 3

      expect(location).not_to be_same_place(other)
    end
  end

  describe '.validation' do
    subject(:location) { described_class.new(lat: 22.3, lon: 42.9, name: 'Funkytown') }

    it { is_expected.to be_valid }

    it 'returns error when latitude is invalid' do
      location.lat = -91.2

      expect(location).not_to be_valid
      expect(location.errors).to include('Invalid latitude: -91.2')
    end

    it 'returns failure when longitude is invalid' do
      location.lon = 182.3

      expect(location).not_to be_valid
      expect(location.errors).to include('Invalid longitude: 182.3')
    end

    it 'returns failure when latitude cannot be parsed' do
      location.lat = '7 cats'

      expect(location).not_to be_valid
      expect(location.errors).to include('Invalid latitude: "7 cats"')
    end

    it 'returns failure when longitude cannot be parsed' do
      location.lon = '10 passes North'

      expect(location).not_to be_valid
      expect(location.errors).to include('Invalid longitude: "10 passes North"')
    end

    it 'returns failure when latitude is missing' do
      location.lat = nil

      expect(location).not_to be_valid
      expect(location.errors).to include('Missing latitude')
    end

    it 'returns failure when longitude is missing' do
      location.lon = nil

      expect(location).not_to be_valid
      expect(location.errors).to include('Missing longitude')
    end
  end
end
