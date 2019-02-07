import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
import java.io.FileNotFoundException
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
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops.csv")
        val shops: List<CoffeeShopWithDistance> = app.getNearestShops()
        assertEquals(3, shops.size)
        assertEquals("Starbucks Seattle2,0.0645", shops[0].toString())
        assertEquals("Starbucks Seattle,0.0861", shops[1].toString())
        assertEquals("Starbucks SF,10.0793", shops[2].toString())
    }

    @Test
    fun `test console output with example`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops.csv")
        val output  = app.getOutput()

        val ls = System.lineSeparator()
        assertEquals("Starbucks Seattle2,0.0645${ls}Starbucks Seattle,0.0861${ls}Starbucks SF,10.0793", output)
    }

    @Test
    fun `test app with inexistent csv file`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_not_found.csv")
        assertThrows <FileNotFoundException> { app.getNearestShops() }
    }

    @Test
    fun `test output with inexistent csv file`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_not_found.csv")
        assertEquals("coffee_shops_not_found.csv was not found.", app.getOutput())
    }

    @Test
    fun `test app with bad csv rows`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_bad_csv_rows.csv")
        assertThrows <IllegalArgumentException> { app.getNearestShops() }
    }

    @Test
    fun `test output with bad csv rows`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_bad_csv_rows.csv")
        assertEquals("coffee_shops_bad_csv_rows.csv is not a valid file.", app.getOutput())
    }

    @Test
    fun `test output with 2 coffee shops`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_only_2.csv")
        val output  = app.getOutput()

        val ls = System.lineSeparator()
        assertEquals("Starbucks Seattle,0.0861${ls}Starbucks SF,10.0793", output)
    }

    @Test
    fun `test output with 1 coffee shop`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_only_1.csv")
        val output  = app.getOutput()

        val ls = System.lineSeparator()
        assertEquals("Starbucks SF,10.0793", output)
    }

    @Test
    fun `test output with an empty file`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_empty.csv")
        val output  = app.getOutput()

        assertEquals("No coffee shops was found in coffee_shops_empty.csv.", output)
    }

    @Test
    fun `test output when many coffee shops are in the same location`() {
        val app = CoffeeShopApp(47.6, -122.4, "coffee_shops_same_place.csv")
        val output  = app.getOutput()

        val ls = System.lineSeparator()
        assertEquals("Starbucks Seattle,0.0861${ls}Starbucks SF,0.0861${ls}Starbucks Moscow,0.0861", output)
    }

}
