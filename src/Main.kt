import java.lang.NumberFormatException

fun main(args: Array<String>) {

    if (args.size != 3) { throw InvalidInput("Incorrect number of arguments") }

    try {
        val latitude: Double = args[0].toDouble()
        val longitude: Double = args[1].toDouble()
        val filename: String = args[2]

        val closestLocations = CoffeeShopFinder(Coordinates(latitude, longitude), filename).findClosestLocations()
        println(closestLocations)
    } catch (e: NumberFormatException) {
        throw NumberFormatException("Input format is incorrect")
    }

}

internal class InvalidInput(message: String): Exception(message)