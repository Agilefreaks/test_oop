import org.junit.jupiter.api.Test

class CoffeeShopWithDistanceTest {
    @Test
    fun `test coffee shop with distance instance`() {
        val shop = CoffeeShop("Starbucks SF", 37.5209, -122.3340)
        val location = Location(47.6, -122.4)
        val distance = CoffeeShopWithDistance(shop, location)
    }
}