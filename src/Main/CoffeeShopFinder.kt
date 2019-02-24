import Helpers.CSVParser
import java.io.FileNotFoundException

internal class CoffeeShopFinder(val userLocation: Coordinates, val filename: String) {

    fun findClosestLocations(): String = try {
        val lines = CSVParser().parseCsvFileWithName(filename)
        val coffeeShops = Converter().linesToCoffeeShops(lines)
        val sortedCoffeeShops = DistanceUtility().sortByDistance(coffeeShops, userLocation)

        Converter().listToString(sortedCoffeeShops, 3)

    } catch (error: FileNotFoundException) {
        throw FileNotFoundException("$filename was not found")
    }
}

internal class EmptyCsvException(message: String): Exception(message)