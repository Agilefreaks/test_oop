import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
import java.lang.NumberFormatException

internal class CoffeeShopLocatorKtTest {

    @Test
    fun testWithInssuficientArgs() {
        assertThrows<InvalidInput> { main(arrayOf("122.4", "41.3")) }
    }

    @Test
    fun testWithIncorrectArgs() {
        assertThrows<NumberFormatException> { main(arrayOf("122.4", "coffee_shops.csv", "41.3")) }
    }

}