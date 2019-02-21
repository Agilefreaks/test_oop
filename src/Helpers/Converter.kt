

internal class Converter {
    fun lineToCoffeeShop(line: String): CoffeeShop = try {
        val coffeeShopDetailArray = line.split(",").toTypedArray()
        val name = coffeeShopDetailArray[0]
        val latitudeString = coffeeShopDetailArray[1]
        val longitudeString = coffeeShopDetailArray[2]
        val coordinates = Coordinates(latitudeString.toDouble(), longitudeString.toDouble())
        CoffeeShop(coordinates, name)
    } catch (error: Throwable) {
        throw InvalidCsvException("line: \" $line \" is not valid")
    }

    fun linesToCoffeeShops(lines: List<String>): List<CoffeeShop>  {
        return lines.map { lineToCoffeeShop(it) }
    }

    fun listToString(list: List<CoffeeShop>, closestCount: Int): String {
        return list.map { it.name + "," + "%.4f".format(it.distanceFromUser) }.take(closestCount).joinToString(separator = "\n")
    }
}

internal class InvalidCsvException(message: String): Exception(message)