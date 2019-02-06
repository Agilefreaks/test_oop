class CoffeeShopWithDistance(val shop: CoffeeShop, val location: Location) {
    val distance: Double by lazy {
        distance(location, shop.location)
    }
}
