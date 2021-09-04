# frozen_string_literal: true

require 'coffee_place'

RSpec.describe CoffeePlace do
  it 'has a version' do
    expect(CoffeePlace::VERSION).to be_frozen
  end
end
