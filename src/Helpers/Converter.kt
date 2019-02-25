

internal class Converter {
    fun lineToCoffeeShop(line: String, userLocation: Coordinates): CoffeeShop = try {
        val coffeeShopDetailArray = line.split(",").toTypedArray()
        val name = coffeeShopDetailArray[0]
        val latitudeString = coffeeShopDetailArray[1]
        val longitudeString = coffeeShopDetailArray[2]
        val coordinates = Coordinates(latitudeString.toDouble(), longitudeString.toDouble())
        val distanceFromUser = DistanceUtility().calculateDistance(coordinates, userLocation)
        CoffeeShop(coordinates, name, distanceFromUser)
    } catch (error: Throwable) {
        throw InvalidCsvException("line: \" $line \" is not valid")
    }

    fun linesToCoffeeShops(lines: List<String>, userLocation: Coordinates): List<CoffeeShop>  {
        return lines.map { lineToCoffeeShop(it, userLocation) }
    }

    fun listToString(list: List<CoffeeShop>, closestCount: Int): String {
        return list.map { it.toString() }.take(closestCount).joinToString(separator = "\n")
    }
}

internal class InvalidCsvException(message: String): Exception(message)