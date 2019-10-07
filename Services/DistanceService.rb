
class DistanceService
  def pow2(x)
    return x * x
  end

  def get_distance(shopsList, currentLocation)

    shopsList.each { |shop| shop.distance = Math.sqrt((pow2(shop.yCoord.to_f - currentLocation.yCoord.to_f) + pow2(shop.xCoord.to_f - currentLocation.xCoord.to_f))).round(4)}

    return shopsList.sort_by(&:distance)

  end

end
