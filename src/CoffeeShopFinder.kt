import java.io.File
import java.io.FileNotFoundException

internal class CoffeeShopFinder(val userLocation: Coordinates, val filename: String) {

    fun findClosestLocations(): String = try {
        val lines = File(filename).readLines().distinct()
        if (lines.isEmpty()) { throw EmptyCsvException("$filename is empty") }
        val coffeeShops = Converter.linesToCoffeeShops(lines)
        val sortedCoffeeShops = DistanceUtility.sortByDistance(coffeeShops, userLocation)

        Converter.listToString(sortedCoffeeShops, 3)

    } catch (error: FileNotFoundException) {
        throw FileNotFoundException("$filename not found")
    }
}

internal class EmptyCsvException(message: String): Exception(message)