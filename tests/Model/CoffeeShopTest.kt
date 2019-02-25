import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows

internal class CoffeeShopTest {

    @Test
    fun `string from CoffeeShop object`() {
        val coffeeShop = CoffeeShop(Coordinates(42.4,143.234), "Starbucks",120.0)
        val expectedString = "Starbucks,120.0000"
        val actualString = coffeeShop.toString()

        assertEquals(expectedString, actualString)
    }

}