import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class CoffeeShopWithDistanceTest {
    @Test
    fun `test coffee shop with distance instance`() {
        val shop = CoffeeShop("Starbucks SF", 37.5209, -122.3340)
        val location = Location(47.6, -122.4)
        val distance = CoffeeShopWithDistance(shop, location)
        assertEquals(shop, distance.shop)
        assertEquals(location, distance.location)
    }

    @Test
    fun `test coffee shop with distance from example`() {
        val shop = CoffeeShop("Starbucks SF", 37.5209, -122.3340)
        val location = Location(47.6, -122.4)
        val distance = CoffeeShopWithDistance(shop, location)
        assertEquals(10.079316088406003, distance.distance)
    }

    @Test
    fun `test pretty print from example`() {
        val shop = CoffeeShop("Starbucks SF", 37.5209, -122.3340)
        val location = Location(47.6, -122.4)
        val distance = CoffeeShopWithDistance(shop, location)
        assertEquals("Starbucks SF,10.0793", distance.toString())
    }
}