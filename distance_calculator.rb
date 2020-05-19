class DistanceCalculator
  attr_reader :x1, :y1, :x2, :y2

  def initialize(user, x2, y2)
    @x1 = user.x
    @y1 = user.y
    @x2 = x2
    @y2 = y2
  end

  def self.calculate(user, x2, y2)
    new(user, x2, y2).calculate
  end

  def calculate
    Math.sqrt((x2 - x1)**2 + ((y2 - y1)**2)).round(4)
  end
end