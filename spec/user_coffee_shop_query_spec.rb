require_relative '../user_coffee_shop_query'
require_relative '../user'
require_relative '../coffee_shop'

RSpec.describe UserCoffeeShopQuery do
  let (:filename) { 'coffee_shops.csv' }
  let (:user) { User.new(12, 43) }
  let(:coffee_shops) {[
    CoffeeShop.new("Starbucks Seattle", "47.5809", "-122.3160"),
    CoffeeShop.new("Starbucks SF", "37.5209", "-122.3340"),
    CoffeeShop.new("Starbucks Moscow", "55.752047", "37.595242"),
    CoffeeShop.new("Starbucks Seattle2", "47.5869", "-122.3368")
  ]}
  let (:user_coffee_shop_query) { UserCoffeeShopQuery.new(coffee_shops, user) }

  describe "#result" do
    context 'when there are more than three coffee shops present in the file' do
      it 'only shows the closest three from a specific user' do
        expect(user_coffee_shop_query.result.length).to be(3)
      end
    end
  end
end