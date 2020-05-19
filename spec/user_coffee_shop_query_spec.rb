require_relative '../user_coffee_shop_query'
require_relative '../coffee_shop'
require_relative '../user'

RSpec.describe UserCoffeeShopQuery do
  let (:filename) { 'coffee_shops.csv' }
  let (:coffee_shops) { CoffeeShop.new(filename).all }
  let (:user) { User.new(12, 43) }
  let(:coffee_shops) { [{name: "Starbucks Seattle", x: "47.5809", y: "-122.3160"},
                       {name: "Starbucks SF", x: "37.5209", y: "-122.3340"},
                       {name: "Starbucks Moscow", x: "55.752047", y: "37.595242"},
                       {name: "Starbucks Seattle2", x: "47.5869", y: "-122.3368"}] }

  describe "#calculate_distances?" do
    before { allow(CSV).to receive(:read).with(filename).and_return(coffee_shops) }

    it 'calculates the distance from user to each coffee shop' do
      user_coffee_shop_query = UserCoffeeShopQuery.new(coffee_shops, user)
      user_coffee_shop_query.calculate_distances
      expect(user_coffee_shop_query.distances.length).to be(coffee_shops.length)
      expect(user_coffee_shop_query.distances.first).to have_key(:distance)
      expect(user_coffee_shop_query.distances.first).to have_key(:name)
    end

    it 'determines what are the closest three coffee shops for a user' do
      user_coffee_shop_query = UserCoffeeShopQuery.new(coffee_shops, user)
      expect(user_coffee_shop_query.show_closest.length).to be(3)
      expect(user_coffee_shop_query.show_closest.first[:name]).to eq('Starbucks Moscow')
    end
  end
end