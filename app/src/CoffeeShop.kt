internal data class CoffeeShop (val name: String, val location: Location) {
    constructor(name: String, x: Double, y: Double) : this(name, Location(x, y))
}

internal fun String.toCoffeeShop(): CoffeeShop {
    try {
        val (name, xs, ys) = this.split(",")
        val x = xs.toDouble()
        val y = ys.toDouble()
        return CoffeeShop(name, x, y)
    }
    catch (e: Throwable) {
        throw CouldNotParseCsvRowException("row is invalid csv: $this")
    }
}

internal fun List<String>.toCoffeeShops(): List<CoffeeShop> {
    return this.map { it.toCoffeeShop() }
}
