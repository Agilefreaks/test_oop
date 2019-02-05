data class CoffeeShop (val name: String, val location: Location) {
    constructor(name: String, x: Double, y: Double) : this(name, Location(x, y))
}
