require_relative '../coffee_shop'

RSpec.describe CoffeeShop do

  let(:filename) { 'coffee_shops.csv' }
  let(:coffee_shops) { [["Starbucks Seattle", "47.5809", "-122.3160"],
                       ["Starbucks SF", "37.5209", "-122.3340"],
                       ["Starbucks Moscow", "55.752047", "37.595242"],
                       ["Starbucks Seattle2", "47.5869", "-122.3368"]] }
  describe "#all" do
    before { allow(CSV).to receive(:read).with(filename).and_return(coffee_shops) }

    it 'returns an array with all the coffee shops existing in the csv file' do
      coffee_shop = CoffeeShop.new(filename)
      expect(coffee_shop.all.length).to eq(coffee_shops.length)
    end
  end
end