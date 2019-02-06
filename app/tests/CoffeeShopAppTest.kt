import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class CoffeeShopAppTest {
    @Test
    fun `test coffee shop app instance`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shop.csv")
        assertEquals(47.6, app.x)
        assertEquals(-122.4, app.y)
        assertEquals("coffee_shop.csv", app.filename)
    }
}
