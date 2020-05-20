require_relative '../input_validator'

RSpec.describe InputValidator do
  let(:filename) { 'coffee_shops.csv' }
  let(:valid_input) { "47.6 -122.4 coffee_shops.csv".chomp.split }
  let(:invalid_input) { "3".chomp.split }
  let(:coffee_shops) { [["Starbucks Seattle", "47.5809", "-122.3160"],
                       ["Starbucks SF", "37.5209", "-122.3340"],
                       ["Starbucks Moscow", "55.752047", "37.595242"],
                       ["Starbucks Seattle2", "47.5869", "-122.3368"]] }

  describe '#validate' do
    context 'when invalid input' do
      it 'throws error and program exits' do
        input_validator = InputValidator.new(invalid_input)
        expect { input_validator.validate }.to raise_error(RuntimeError)
      end
    end
    context 'when valid input' do
      it 'doesn\'t throw error' do
        input_validator = InputValidator.new(valid_input)
        expect { input_validator.validate }.to_not raise_error     
      end
    end
  end
end