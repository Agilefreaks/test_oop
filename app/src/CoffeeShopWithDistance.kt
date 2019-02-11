internal data class CoffeeShopWithDistance(val shop: CoffeeShop, val location: Location) {
    internal val distance: Distance by lazy {
        distance(location, shop)
    }

    override fun toString(): String {
        return "${shop.name},$distance"
    }
}

internal fun List<CoffeeShop>.toCoffeeShopsWithDistance(location: Location): List<CoffeeShopWithDistance> {
    return this.map { CoffeeShopWithDistance(it, location) }
}

internal fun List<CoffeeShopWithDistance>.sortedByDistance(): List<CoffeeShopWithDistance> {
    return this.sortedBy { it.distance }
}
