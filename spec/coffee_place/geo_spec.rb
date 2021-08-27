# frozen_string_literal: true

require 'coffee_place/geo'

RSpec.describe CoffeePlace::Geo do
  subject(:geo) { described_class }

  it 'checks whether a value is within latitude bounds' do
    expect(geo.within_latitude_bounds?(0)).to eq(true)
    expect(geo.within_latitude_bounds?(42.0)).to eq(true)
    expect(geo.within_latitude_bounds?(-42.0)).to eq(true)

    expect(geo.within_latitude_bounds?(90.0)).to eq(true)
    expect(geo.within_latitude_bounds?(-90.0)).to eq(true)

    expect(geo.within_latitude_bounds?(92.0)).to eq(false)
    expect(geo.within_latitude_bounds?(-92.0)).to eq(false)
  end

  it 'checks whether a value is within longitude bounds' do
    expect(geo.within_longitude_bounds?(0)).to eq(true)
    expect(geo.within_longitude_bounds?(42.0)).to eq(true)
    expect(geo.within_longitude_bounds?(-42.0)).to eq(true)

    expect(geo.within_longitude_bounds?(180)).to eq(true)
    expect(geo.within_longitude_bounds?(-180.0)).to eq(true)

    expect(geo.within_longitude_bounds?(182.0)).to eq(false)
    expect(geo.within_longitude_bounds?(-182.0)).to eq(false)
  end
end
