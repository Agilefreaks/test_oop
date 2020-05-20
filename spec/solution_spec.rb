require_relative '../solution'

RSpec.describe Solution do
  let(:filename) { 'coffee_shops.csv' }
  let(:input) { "47.6 -122.4 coffee_shops.csv".chomp.split }
  let(:wrong_input) { "47.6 -122.4 coooffee_shops.csv".chomp.split }
  let(:coffee_shops) { [["Starbucks Seattle", "47.5809", "-122.3160"],
                       ["Starbucks SF", "37.5209", "-122.3340"],
                       ["Starbucks Moscow", "55.752047", "37.595242"],
                       ["Starbucks Seattle2", "47.5869", "-122.3368"]] }
  describe "#find" do
    before { allow(CSV).to receive(:read).with(filename).and_return(coffee_shops) }
    it 'returns the closest three coffee shops for a user' do
      solution = Solution.new(input).find
      expect(solution.length).to be(3)
    end
  end
end