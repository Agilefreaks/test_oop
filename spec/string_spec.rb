require_relative '../string'

RSpec.describe String do
  describe "#numeric?" do
    context 'when only digits' do
      it 'returns true' do
        expect('123.123'.numeric?).to be true
      end
    end
    context 'when non-digits characters included' do
      it 'returns false' do
        expect('1a1.2'.numeric?).to be false
      end
    end
    context 'when empty string' do
      it 'returns false' do
        expect(''.numeric?).to be false
      end
    end
  end
end