class CoffeeShopApp (val x: Double, val y: Double, val filename: String) {
    fun getNearestShops(): List<CoffeeShopWithDistance> {
        return List(3, { CoffeeShopWithDistance(CoffeeShop("",0.0,0.0), Location(0.0,0.0))})
    }

}
