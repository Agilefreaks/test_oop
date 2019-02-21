
internal data class CoffeeShop(val coordinates: Coordinates, val name: String) {
    var distanceFromUser: Double? = null

    override fun toString(): String {
        if (distanceFromUser != null) {
            return name + "," + "%.4f".format(distanceFromUser)
        } else {
            throw DistanceError("There was an error and the distance could not be calculated")
        }
    }
}

internal class DistanceError(message: String): Exception(message)