require "csv"
$dirPath = File.dirname(File.dirname(File.expand_path(__FILE__)))
$shopFile = $dirPath + '/Data/coffee_shops.csv'

class CsvParser

  def get_content
      a = []
      CSV.foreach($shopFile) do |row|
      shop = CoffeeShop.new()
      shop.name = row[0]
      shop.xCoord = row[1]
      shop.yCoord = row[2]
      a << shop
      end
      return a
  end
end
