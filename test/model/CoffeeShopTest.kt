import org.testng.annotations.Test

/**
 * created by AlexandraV on 12/30/2018
 */
@Test
fun isIdentical_DifferentNames() {
    val shopCoordinate = Coordinate("47.8", "89")
    val userCoordinate = Coordinate("45.0", "30.02")
    val coffeeShop = CoffeeShop("CoffeeShop1", shopCoordinate, userCoordinate)
    val otherCoffeeShop = CoffeeShop("CoffeeShop2", shopCoordinate, userCoordinate)

    assert(!coffeeShop.isIdentical(otherCoffeeShop)){ "Different names, same coordinates" }
}

@Test
fun isIdentical_DifferentXCoordinate() {
    val shopCoordinate1 = Coordinate("47.8", "89")
    val shopCoordinate2 = Coordinate("47.9", "89")

    val userCoordinate = Coordinate("45.0", "30.02")
    val coffeeShop = CoffeeShop("CoffeeShop", shopCoordinate1, userCoordinate)
    val otherCoffeeShop = CoffeeShop("CoffeeShop", shopCoordinate2, userCoordinate)

    assert(!coffeeShop.isIdentical(otherCoffeeShop)){ "Same names, different x coordinate" }
}

@Test
fun isIdentical_DifferentYCoordinate() {
    val shopCoordinate1 = Coordinate("47.8", "89")
    val shopCoordinate2 = Coordinate("47.8", "89.2")

    val userCoordinate = Coordinate("45.0", "30.02")
    val coffeeShop = CoffeeShop("CoffeeShop", shopCoordinate1, userCoordinate)
    val otherCoffeeShop = CoffeeShop("CoffeeShop", shopCoordinate2, userCoordinate)

    assert(!coffeeShop.isIdentical(otherCoffeeShop)){ "Same names, different y coordinate" }
}

@Test
fun isIdentical_DifferentCoordinates() {
    val shopCoordinate1 = Coordinate("56.2", "102")
    val shopCoordinate2 = Coordinate("47.8", "89.2")

    val userCoordinate = Coordinate("45.0", "30.02")
    val coffeeShop = CoffeeShop("CoffeeShop", shopCoordinate1, userCoordinate)
    val otherCoffeeShop = CoffeeShop("CoffeeShop", shopCoordinate2, userCoordinate)

    assert(!coffeeShop.isIdentical(otherCoffeeShop)){ "Same names, different coordinates" }
}

@Test
fun isIdentical_DifferentShops() {
    val shopCoordinate1 = Coordinate("56.2", "102")
    val shopCoordinate2 = Coordinate("47.8", "89.2")

    val userCoordinate = Coordinate("45.0", "30.02")
    val coffeeShop = CoffeeShop("CoffeeShop1", shopCoordinate1, userCoordinate)
    val otherCoffeeShop = CoffeeShop("CoffeeShop2", shopCoordinate2, userCoordinate)

    assert(!coffeeShop.isIdentical(otherCoffeeShop)){ "Different names, different coordinates" }
}

@Test
fun isIdentical_SameShops() {
    val shopCoordinate = Coordinate("56.2", "102")
    val userCoordinate = Coordinate("45.0", "30.02")
    val coffeeShop = CoffeeShop("CoffeeShop", shopCoordinate, userCoordinate)
    val otherCoffeeShop = CoffeeShop("CoffeeShop", shopCoordinate, userCoordinate)

    assert(coffeeShop.isIdentical(otherCoffeeShop)){ "Different names, different coordinates" }
}