import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
import java.io.FileNotFoundException
import java.lang.NumberFormatException

internal class CoffeeShopLocatorKtTest {

    @Test
    fun locateWithInsufficientArgs() {
        assertThrows<InvalidInput> { main(arrayOf("122.4", "41.3")) }
    }

    @Test
    fun locateWithIncorrectArgs() {
        assertThrows<NumberFormatException> { main(arrayOf("122.4", "coffee_shops.csv", "41.3")) }
    }

    @Test
    fun locateWithNonExistentFile() {
        assertThrows<FileNotFoundException> { main(arrayOf("122.4", "41.3", "random.csv")) }
    }

}