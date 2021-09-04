# frozen_string_literal: true

require 'coffee_place/result'

RSpec.describe CoffeePlace::Result do
  it 'can represent a success value' do
    result = described_class.success(42)

    expect(result).to be_success
    expect(result).not_to be_failure
    expect(result.value).to eq(42)
    expect(result.error).to be_nil
  end

  it 'can represent a failure value' do
    result = described_class.failure('Oh noes!')

    expect(result).not_to be_success
    expect(result).to be_failure

    expect(result.value).to be_nil
    expect(result.error).to eq('Oh noes!')
  end
end
