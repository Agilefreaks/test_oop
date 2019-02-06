import org.junit.jupiter.api.Test

class CoffeeShopAppTest {
    @Test
    fun `test coffee shop app instance`() {
        val app = CoffeShopApp(47.6, -122.4, "coffee_shop.csv")
        app.x = 47.6
        app.y = -122.4
        app.filename = "coffee_shop.csv"
    }
}