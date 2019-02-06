import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class CoffeeShopWithDistanceTest {

    private val shop = CoffeeShop("Starbucks SF", 37.5209, -122.3340)
    private val location = Location(47.6, -122.4)
    private val distance = CoffeeShopWithDistance(shop, location)

    @Test
    fun `test coffee shop with distance instance`() {
        assertEquals(shop, distance.shop)
        assertEquals(location, distance.location)
    }

    @Test
    fun `test coffee shop with distance from example`() {
        assertEquals(10.079316088406003, distance.distance)
    }

    @Test
    fun `test pretty print from example`() {
        assertEquals("Starbucks SF,10.0793", distance.toString())
    }

    @Test
    fun `test equality`() {
        val other = CoffeeShopWithDistance(shop, location)
        assert(distance == other)
    }

    @Test
    fun `test inequality`() {
        val otherLocation = Location(20.12, 50.8)
        val other = CoffeeShopWithDistance(shop, otherLocation)
        assert(distance != other)
    }

    @Test
    fun `test list of coffee shop to list of shops with distance (from example)`() {
        val location = Location(47.6, -122.4)
        val rows = listOf(
            "Starbucks Seattle,47.5809,-122.3160",
            "Starbucks SF,37.5209,-122.3340",
            "Starbucks Seattle2,47.5869,-122.3368"
        )
        val shops = rows.toCoffeeShops()
        val distances = shops.toCoffeeShopsWithDistance(location)
        assertEquals("Starbucks Seattle,0.0861", distances[0].toString())
        assertEquals("Starbucks SF,10.0793", distances[1].toString())
        assertEquals("Starbucks Seattle2,0.0645", distances[2].toString())
    }

    @Test
    fun `test list of coffee shops sorting`() {
        val location = Location(47.6, -122.4)
        val rows = listOf(
            "Starbucks Seattle,47.5809,-122.3160",
            "Starbucks SF,37.5209,-122.3340",
            "Starbucks Seattle2,47.5869,-122.3368"
        )
        val shops = rows.toCoffeeShops()
        val distances = shops.toCoffeeShopsWithDistance(location).sortedByDistance()
        assertEquals("Starbucks Seattle2,0.0645", distances[0].toString())
        assertEquals("Starbucks Seattle,0.0861", distances[1].toString())
        assertEquals("Starbucks SF,10.0793", distances[2].toString())
    }
}
