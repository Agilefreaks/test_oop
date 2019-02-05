import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
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

    @Test
    fun `test coffee shop without using location`() {
        val shop = CoffeeShop("Starbucks", 21.51, -74.58)
        assertEquals("Starbucks", shop.name)
//        assertEquals(21.51, shop.x)
//        assertEquals(-74.58, shop.y)
        assertEquals(21.51, shop.location.x)
        assertEquals(-74.58, shop.location.y)
    }

    @Test
    fun `test coffee shop from csv row`() {
        val row = "Starbucks Sydney,-33.871843,151.206767"
        val shop = CoffeeShopFromCsv(row)
        assertEquals("Starbucks Sydney", shop.name)
        assertEquals(-33.871843, shop.location.x)
        assertEquals(151.206767, shop.location.y)
    }

    @Test
    fun `test coffee shop from invalid csv row`() {
        val row = "Starbucks Sydney;-33.871843;151.206767"
        assertThrows <IllegalArgumentException> { CoffeeShopFromCsv(row) }
    }
}
