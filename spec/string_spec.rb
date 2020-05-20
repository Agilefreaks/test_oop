require_relative '../string'

RSpec.describe String do

  describe "#numeric?" do
    context 'when valid float number is given' do
      it 'should return true' do
        expect('123.123'.numeric?).to be true
      end
    end
    context 'when valid integer number is given' do
      it 'should return true' do
        expect('7654'.numeric?).to be true
      end
    end
    context 'when alphabet characters are given' do
      it 'should return false' do
        expect('abc'.numeric?).to be false
      end
    end
    context 'when alphabet characters combined with digits are given' do
      it 'should return false' do
        expect('1a1.2'.numeric?).to be false
      end
    end
    context 'empty string given' do
      it 'should return false' do
        expect(''.numeric?).to be false
      end
    end
  end
end