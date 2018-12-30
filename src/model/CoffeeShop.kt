/**
 * Defines a CoffeeShop object, containing a CoffeeShop name and its distance to a given user
 *
 * created by AlexandraV on 12/26/2018
 */
data class CoffeeShop(val shopName: String, val shopDistanceToUser: Double) : Comparable<CoffeeShop> {
    override fun compareTo(other: CoffeeShop) = when {
        shopDistanceToUser < other.shopDistanceToUser -> -1
        shopDistanceToUser > other.shopDistanceToUser -> 1
        else -> 0
    }
}