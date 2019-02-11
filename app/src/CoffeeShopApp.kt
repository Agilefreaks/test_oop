import java.io.File
import java.io.FileNotFoundException

class CoffeeShopApp (val x: Double, val y: Double, val filename: String) {
    internal fun getNearestShops(): List<CoffeeShopWithDistance> {
        val user = Location(x, y)
        return readAllLinesAsCsvRows(filename).toCoffeeShops().toCoffeeShopsWithDistance(user).sortedByDistance().take(3)
    }

    fun getOutput(): String {
        try {
            val shops = getNearestShops()

            if (shops.isEmpty()) {
                return "No coffee shops was found in $filename."
            }
            else {
                return shops.joinToString(separator = System.lineSeparator())
            }

        }
        catch (e: FileNotFoundException) {
            return "$filename was not found."
        }
        catch (e: CouldNotParseCsvRowException) {
            return "$filename is not a valid file."
        }
    }
}

internal fun readAllLinesAsCsvRows(filename: String): List<String> {
    return File(filename).readLines()
}
