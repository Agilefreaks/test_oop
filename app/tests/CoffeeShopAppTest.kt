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

    @Test
    fun `test coffee shop app with example`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shop.csv")
        val shops: List<CoffeeShopWithDistance> = app.getNearestShops()
        assertEquals(3, shops.size)
        assertEquals("Starbucks Seattle2,0.0645", shops[0].toString())
        assertEquals("Starbucks Seattle,0.0861", shops[0].toString())
        assertEquals("Starbucks SF,10.0793", shops[0].toString())
    }
}
