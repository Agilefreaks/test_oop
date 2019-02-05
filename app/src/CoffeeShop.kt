data class CoffeeShop (val name: String, val location: Location) {
    constructor(name: String, x: Double, y: Double) : this(name, Location(x, y))
}

fun CoffeeShopFromCsv(row: String): CoffeeShop {
    try {
        val (name, xs, ys) = row.split(",")
        val x = xs.toDouble()
        val y = ys.toDouble()
        return CoffeeShop(name, x, y)
    }
    catch (e: Throwable) {
        throw IllegalArgumentException("row is invalid csv: $row")
    }
}
