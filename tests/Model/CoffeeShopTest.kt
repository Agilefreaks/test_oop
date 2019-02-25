import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

internal class CoffeeShopTest {

    @Test
    fun `transform CoffeeShop object to string should work`() {
        val coffeeShop = CoffeeShop(Coordinates(42.4,143.234), "Starbucks",120.0)
        val expectedString = "Starbucks,120.0000"
        val actualString = coffeeShop.toString()

        assertEquals(expectedString, actualString)
    }

}