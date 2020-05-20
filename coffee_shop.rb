class CoffeeShop
  attr_reader :name, :x, :y

  def initialize(name, x, y)
    @name = name
    @x = x.to_f
    @y = y.to_f
  end
end