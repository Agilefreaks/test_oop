require_relative '../distance_calculator'
require_relative '../user'
require_relative '../coffee_shop'

RSpec.describe DistanceCalculator do

  let (:user) { User.new(47.6, -122.4) }
  let (:coffee_shop) { CoffeeShop.new('Meron', 23.45, -112.2) }
  let (:distance_calculator) { DistanceCalculator.new(user, coffee_shop) }
  
  describe "#calculate" do
    it 'calculates the distance between user and coffee shop' do
      expect(distance_calculator.calculate).to be(26.2157)
    end
  end
end