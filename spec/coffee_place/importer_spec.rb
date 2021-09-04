# frozen_string_literal: true

require 'coffee_place/importer'
require 'coffee_place/location'

RSpec.describe CoffeePlace::Importer do
  subject(:importer) { described_class.new }

  describe '#import_from' do
    context 'with main example CSV file' do
      let(:locations_file) { fixture_file('coffee_shops.csv') }

      let(:expected_locations) do
        [
          CoffeePlace::Location.new(lat: 47.5809, lon: -122.316, name: 'Starbucks Seattle'),
          CoffeePlace::Location.new(lat: 37.5209, lon: -122.334, name: 'Starbucks SF'),
          CoffeePlace::Location.new(lat: 55.752047, lon: 37.595242, name: 'Starbucks Moscow'),
          CoffeePlace::Location.new(lat: 47.5869, lon: -122.3368, name: 'Starbucks Seattle2'),
          CoffeePlace::Location.new(lat: -22.923489, lon: -43.234418, name: 'Starbucks Rio De Janeiro'),
          CoffeePlace::Location.new(lat: -33.871843, lon: 151.206767, name: 'Starbucks Sydney')
        ]
      end

      it 'imports locations from file' do
        result = importer.import_from(locations_file)

        expect(result).to be_success
        expect(result.value).to eq(expected_locations)
      end
    end

    context 'with simple example CSV file' do
      let(:locations_file) { fixture_file('coffee_shops_simple.csv') }

      let(:expected_locations) do
        [
          CoffeePlace::Location.new(lat: 47.5, lon: -122.3, name: 'Coffee Shop Seattle'),
          CoffeePlace::Location.new(lat: -22.9, lon: -43.2, name: 'Coffee Shop Rio De Janeiro')
        ]
      end

      it 'imports locations from file' do
        result = importer.import_from(locations_file)

        expect(result).to be_success
        expect(result.value).to eq(expected_locations)
      end
    end

    context 'with invalid csv file' do
      let(:locations_file) { fixture_file('coffee_shops_invalid.csv') }

      it 'returns errors for locations from file' do
        result = importer.import_from(locations_file)

        expect(result).not_to be_success
        expect(result.error).to contain_exactly(
          'CSV error on line 2: Invalid latitude: " South America"',
          'CSV error on line 2: Invalid longitude: " Western Hemisphere"',
          'CSV error on line 4: Missing longitude'
        )
      end
    end
  end
end
