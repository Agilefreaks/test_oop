
internal data class CoffeeShop(val coordinates: Coordinates, val name: String, val distanceFromUser: Double) {
    override fun toString(): String {
        return name + "," + "%.4f".format(distanceFromUser)
    }
}