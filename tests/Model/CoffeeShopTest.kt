import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows

internal class CoffeeShopTest {

    @Test
    fun createCoffeeShop() {
        val coffeeShop = CoffeeShop(Coordinates(42.4,143.234), "Starbucks")
        assertEquals("Starbucks", coffeeShop.name)
        assertEquals(42.4, coffeeShop.coordinates.latitude)
        assertEquals(143.234, coffeeShop.coordinates.longitude)
    }

    @Test
    fun stringFromCoffeeShop() {
        val coffeeShop = CoffeeShop(Coordinates(42.4,143.234), "Starbucks")
        coffeeShop.distanceFromUser = 120.0
        val expectedString = "Starbucks,120.0000"
        val computedString = coffeeShop.toString()

        assertEquals(expectedString, computedString)
    }

    @Test
    fun stringFromCoffeeShopWithNullDistance() {
        val coffeeShop = CoffeeShop(Coordinates(42.4,143.234), "Starbucks")

        assertThrows <DistanceError> { coffeeShop.toString() }
    }

}