data class CoffeeShopWithDistance(val shop: CoffeeShop, val location: Location) {
    val distance: Distance by lazy {
        distance(location, shop.location)
    }

    override fun toString(): String {
        return "${shop.name},$distance"
    }
}

fun List<CoffeeShop>.toCoffeeShopsWithDistance(location: Location): List<CoffeeShopWithDistance> {
    return this.map { CoffeeShopWithDistance(it, location) }
}

fun List<CoffeeShopWithDistance>.sortedByDistance(): List<CoffeeShopWithDistance> {
    return this.sortedBy { it.distance }
}
