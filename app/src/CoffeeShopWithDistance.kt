data class CoffeeShopWithDistance(val shop: CoffeeShop, val location: Location) {
    val distance: Double by lazy {
        distance(location, shop.location)
    }

    override fun toString(): String {
        return "${shop.name},${distance.roundTo4Digits()}"
    }
}

fun List<CoffeeShop>.toCoffeeShopsWithDistance(location: Location): List<CoffeeShopWithDistance> {
    return this.map { CoffeeShopWithDistance(it, location) }
}
