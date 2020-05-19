require_relative '../distance_calculator'
require_relative '../user'

RSpec.describe DistanceCalculator do

  let (:user) { User.new(47.6, -122.4) }
  
  describe "#calculate" do
    it 'calculates the distance between 2 points that lie on a plane' do
      distance_calculator = DistanceCalculator.new(user, 	47.5869, -122.3368)
      expect(distance_calculator.calculate).to be(0.0645)
      expect(distance_calculator.calculate).to be_a Float
    end
  end
end