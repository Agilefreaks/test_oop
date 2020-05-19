require_relative '../input_validator'

RSpec.describe InputValidator do
  let(:filename) { 'coffee_shops.csv' }
  let(:input) { "47.6 -122.4 coffee_shops.csv".chomp.split }
  let(:wrong_input) { "3".chomp.split }
  let(:coffee_shops) { [["Starbucks Seattle", "47.5809", "-122.3160"],
                       ["Starbucks SF", "37.5209", "-122.3340"],
                       ["Starbucks Moscow", "55.752047", "37.595242"],
                       ["Starbucks Seattle2", "47.5869", "-122.3368"]] }

  describe "#valid_input?" do
    it 'checks if the user\'s input is correct' do
      input_validator = InputValidator.new(input)
      expect(input_validator.valid_input?).to be true
      input_validator = InputValidator.new(wrong_input)
      expect(input_validator.valid_input?).to be false
    end
  end
end