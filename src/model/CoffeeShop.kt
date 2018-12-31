/**
 * Defines a CoffeeShop object, containing a CoffeeShop name, its coordinates and a given user's coordinates
 *
 * created by AlexandraV on 12/26/2018
 */
data class CoffeeShop(val shopName: String, val shopCoordinate: Coordinate, val userCoordinate: Coordinate) : Comparable<CoffeeShop> {
    val shopDistanceToUser: Double = shopCoordinate.distanceTo(userCoordinate.xCoordinate, userCoordinate.yCoordinate)

    override fun compareTo(other: CoffeeShop) = when {
        shopDistanceToUser < other.shopDistanceToUser -> -1
        shopDistanceToUser > other.shopDistanceToUser -> 1
        else -> 0
    }

    /**
     * checks if two coffee shops are the same
     */
    fun isIdentical(other: CoffeeShop): Boolean = shopName == other.shopName && shopCoordinate.xCoordinate == other.shopCoordinate.xCoordinate && shopCoordinate.yCoordinate == other.shopCoordinate.yCoordinate
}