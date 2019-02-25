import Helpers.CSVParser

internal class CoffeeShopFinder(private val userLocation: Coordinates, private val filename: String) {

    fun findClosestLocations(): String {
        val lines = CSVParser().parseCsvFileWithName(filename)
        val coffeeShops = Converter().linesToCoffeeShops(lines, userLocation)
        val sortedCoffeeShops = DistanceUtility().sortByDistance(coffeeShops, userLocation)

        return Converter().listToString(sortedCoffeeShops, 3)
    }
}