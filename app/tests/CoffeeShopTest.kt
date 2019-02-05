import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class CoffeeShopTest {
    @Test
    fun `test coffee shop`() {
        val shop = CoffeeShop("Starbucks", Location(21.51, -74.58))
        assertEquals("Starbucks", shop.name)
//        assertEquals(21.51, shop.x)
//        assertEquals(-74.58, shop.y)
        assertEquals(21.51, shop.location.x)
        assertEquals(-74.58, shop.location.y)
    }

    fun `test coffee shop without using location`() {
        val shop = CoffeeShop("Starbucks", 21.51, -74.58)
        assertEquals("Starbucks", shop.name)
//        assertEquals(21.51, shop.x)
//        assertEquals(-74.58, shop.y)
        assertEquals(21.51, shop.location.x)
        assertEquals(-74.58, shop.location.y)
    }
}