require_relative '../string'

RSpec.describe String do

  describe "#numeric?" do
    it 'determines if a certain string containes only numeric values' do
      expect('123.123'.numeric?).to be true
      expect('7654'.numeric?).to be true
      expect('abc'.numeric?).to be false
      expect('1a1.2'.numeric?).to be false
      expect(''.numeric?).to be false
    end
  end
end