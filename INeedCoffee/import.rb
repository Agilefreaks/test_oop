require 'csv'

class Import
  def self.CSVDataIntoCoffeeShop(coffeeShopFileName, coffeeShopName, coffeeShopLatitude, coffeeShopLongitude)

    begin
      CSV.foreach(coffeeShopFileName.to_s, {encoding: 'UTF-8', headers: false, :col_sep => ',', header_converters: :symbol, converters: :all}) do |row|
        coffeeShopName.push row[0]
        coffeeShopLatitude.push row[1]
        coffeeShopLongitude.push row[2]
      end
    rescue Errno::ENOENT => e
      puts 'The CSV file name is not valid or the file does not exist'
    end
  end
end