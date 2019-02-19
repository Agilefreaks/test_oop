import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows

internal class CoffeeShopLocatorKtTest {

    @Test
    fun testWithInssuficientArgs() {
        assertThrows<InvalidInput> { main(arrayOf("122.4", "41.3")) }
    }

}