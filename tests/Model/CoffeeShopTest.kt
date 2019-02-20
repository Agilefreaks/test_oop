import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

internal class CoffeeShopTest {

    @Test
    fun createCoffeeShop() {
        val coffeeShop = CoffeeShop(Coordinates(42.4,143.234), "Starbucks")
        assertEquals("Starbucks", coffeeShop.name)
        assertEquals(42.4, coffeeShop.coordinates.latitude)
        assertEquals(143.234, coffeeShop.coordinates.longitude)
    }

}