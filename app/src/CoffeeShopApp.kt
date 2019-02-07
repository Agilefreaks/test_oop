class CoffeeShopApp (val x: Double, val y: Double, val filename: String) {
    fun getNearestShops(): List<CoffeeShopWithDistance> {
        val user = Location(x, y)
        return filename.readAllLinesAsCsvRows().toCoffeeShops().toCoffeeShopsWithDistance(user).sortedByDistance().take(3)
    }

    fun getOutput(): String {
        val shops = getNearestShops()
        return shops.joinToString(separator = System.lineSeparator())
    }
}
