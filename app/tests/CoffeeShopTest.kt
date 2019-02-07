import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
import kotlin.test.assertEquals

class CoffeeShopTest {
    @Test
    fun `test coffee shop`() {
        val shop = CoffeeShop("Starbucks", Location(21.51, -74.58))
        assertEquals("Starbucks", shop.name)
        assertEquals(21.51, shop.location.x)
        assertEquals(-74.58, shop.location.y)
    }

    @Test
    fun `test coffee shop without using location`() {
        val shop = CoffeeShop("Starbucks", 21.51, -74.58)
        assertEquals("Starbucks", shop.name)
        assertEquals(21.51, shop.location.x)
        assertEquals(-74.58, shop.location.y)
    }

    @Test
    fun `test coffee shop from csv row`() {
        val row = "Starbucks Sydney,-33.871843,151.206767"
        val shop = row.toCoffeeShop()
        assertEquals("Starbucks Sydney", shop.name)
        assertEquals(-33.871843, shop.location.x)
        assertEquals(151.206767, shop.location.y)
    }

    @Test
    fun `test coffee shop from invalid csv row`() {
        val row = "Starbucks Sydney;-33.871843;151.206767"
        assertThrows <CouldNotParseCsvRowException> { row.toCoffeeShop() }
    }

    @Test
    fun `test coffee shops from csv rows`() {
        val rows = listOf("Starbucks Rio De Janeiro,-22.923489,-43.234418", "Starbucks Sydney,-33.871843,151.206767")
        val shops = rows.toCoffeeShops()
        assertEquals(2, shops.size)
        assertEquals("Starbucks Rio De Janeiro", shops[0].name)
        assertEquals(-22.923489, shops[0].location.x)
        assertEquals(-43.234418, shops[0].location.y)
        assertEquals("Starbucks Sydney", shops[1].name)
        assertEquals(-33.871843, shops[1].location.x)
        assertEquals(151.206767, shops[1].location.y)
    }

    @Test
    fun `test coffee shops from invalid csv rows`() {
        val rows = listOf("Starbucks Rio De Janeiro,-22.923489,-43.234418", "Starbucks Sydney;-33.871843;151.206767")
        assertThrows <CouldNotParseCsvRowException> { rows.toCoffeeShops() }
    }

    @Test
    fun `test empty csv rows to coffee shops`() {
        val rows = listOf<String>()
        val shops = rows.toCoffeeShops()
        assert(shops.isEmpty())
    }

    @Test
    fun `test csv file to list of csv rows`() {
        val filename = "coffee_shops.csv"
        val rows = filename.readAllLinesAsCsvRows()
        assertEquals(6, rows.size)
    }
}
