import java.io.File
import java.io.FileNotFoundException

internal class CoffeeShopFinder(val userLocation: Coordinates, val filename: String) {

    fun findClosestLocations(): String = try {
        val lines = File(filename).readLines().distinct()
        ""
    } catch (error: FileNotFoundException) {
        throw FileNotFoundException("$filename not found")
    }
}