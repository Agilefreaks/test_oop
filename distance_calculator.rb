class DistanceCalculator
  attr_reader :x1, :y1, :x2, :y2

  def initialize(user, coffee_shop)
    @x1 = user.x
    @y1 = user.y
    @x2 = coffee_shop.x
    @y2 = coffee_shop.y
  end

  def self.calculate(user, coffee_shop)
    new(user, coffee_shop).calculate
  end

  def calculate
    Math.sqrt((x2 - x1)**2 + ((y2 - y1)**2)).round(4)
  end
end