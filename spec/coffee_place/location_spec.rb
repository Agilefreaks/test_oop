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
  end

  describe '.validate' do
    subject { described_class }

    let(:valid_opts) do
      { lat: 22.3, lon: 42.9, name: 'Funkytown' }
    end

    it 'returns success with location when options valid' do
      result = subject.validate(**valid_opts)

      expect(result).to be_success
      expect(result.value).to have_attributes(
        lat: 22.3,
        lon: 42.9,
        name: 'Funkytown'
      )
    end

    it 'returns failure when latitude is invalid' do
      invalid_opts = valid_opts.merge(lat: -91.2)
      result = subject.validate(**invalid_opts)

      expect(result).to be_failure
      expect(result.error).to eq('Invalid latitude: -91.2')
    end

    it 'returns failure when longitude is invalid' do
      invalid_opts = valid_opts.merge(lon: 182.3)
      result = subject.validate(**invalid_opts)

      expect(result).to be_failure
      expect(result.error).to eq('Invalid longitude: 182.3')
    end

    it 'returns failure when latitude cannot be parsed' do
      invalid_opts = valid_opts.merge(lat: '7 cats')
      result = subject.validate(**invalid_opts)

      expect(result).to be_failure
      expect(result.error).to eq('Invalid latitude: "7 cats"')
    end

    it 'returns failure when longitude cannot be parsed' do
      invalid_opts = valid_opts.merge(lon: '10 passes North')
      result = subject.validate(**invalid_opts)

      expect(result).to be_failure
      expect(result.error).to eq('Invalid longitude: "10 passes North"')
    end

    it 'returns failure when latitude is missing' do
      invalid_opts = valid_opts.merge(lat: nil)
      result = subject.validate(**invalid_opts)

      expect(result).to be_failure
      expect(result.error).to eq('Missing latitude')
    end

    it 'returns failure when longitude is missing' do
      invalid_opts = valid_opts.merge(lon: nil)
      result = subject.validate(**invalid_opts)

      expect(result).to be_failure
      expect(result.error).to eq('Missing longitude')
    end
  end
end
