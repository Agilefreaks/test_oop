require_relative '../solution'

RSpec.describe Solution do
  let(:filename) { 'coffee_shops.csv' }
  let(:valid_input) { "47.6 -122.4 coffee_shops.csv".chomp.split }
  let(:invalid_input) { "47.6 -122.4 coooffee_shops.csv".chomp.split }

  let (:solution) { Solution.new(valid_input).find }
  let (:solution1) { Solution.new(invalid_input).find }

  describe "#find" do
    context 'when valid input given' do
      it 'returns the closest three coffee shops for a user' do
        expect(solution.length).to be(3)
      end
    end
    context 'when invalid input given' do
      it 'throws an error and program exits' do
        expect { solution1 }.to raise_error(RuntimeError)
      end
    end
  end
end