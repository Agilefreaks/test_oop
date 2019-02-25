import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
import java.io.FileNotFoundException
import java.lang.NumberFormatException

internal class MainKtTest {

    @Test
    fun `find closest coffee shops with insufficient number of args should throw error`() {
        assertThrows<InvalidInput> { main(arrayOf("122.4", "41.3")) }
    }

    @Test
    fun `find closest coffee shops with incorrect type of args should throw error`() {
        assertThrows<NumberFormatException> { main(arrayOf("122.4", "coffee_shops.csv", "41.3")) }
    }
}