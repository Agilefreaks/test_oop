import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
import java.io.FileNotFoundException

internal class CoffeeShopFinderTest {

    @Test
    fun createCoffeeShopFinder() {
        val finder = CoffeeShopFinder(Coordinates(123.4, 42.4), "random.csv")

        assertEquals("random.csv", finder.filename)
        assertEquals(123.4, finder.userLocation.latitude)
        assertEquals(42.4, finder.userLocation.longitude)
    }

    @Test
    fun getClosestCoffeeShops() {
        val computedOutput = CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops.csv").findClosestLocations()
        val expectedOutput = "Starbucks Seattle2,0.0645\n" + "Starbucks Seattle,0.0861\n" + "Starbucks SF,10.0793"

        assertEquals(expectedOutput, computedOutput)
    }

    @Test
    fun getClosestCoffeeShopsFromEmptyList() {
        assertThrows <EmptyCsvException> { CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops_empty.csv").findClosestLocations() }
    }

    @Test
    fun getClosestCoffeeShopsFromSingleList() {
        val computedOutput = CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops_just_one.csv").findClosestLocations()
        val expectedOutput = "Starbucks Seattle,0.0861"

        assertEquals(expectedOutput, computedOutput)
    }

    @Test
    fun getClosestCoffeeShopsFromMalformedList() {
        assertThrows <InvalidCsvException> { CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops_malformed.csv").findClosestLocations() }
    }

    @Test
    fun getClosestCoffeeShopsFromListWithDuplicates() {
        val computedOutput = CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops_duplicates.csv").findClosestLocations()
        val expectedOutput = "Starbucks Seattle2,0.0645\n" + "Starbucks Seattle,0.0861\n" + "Starbucks SF,10.0793"

        assertEquals(expectedOutput, computedOutput)
    }

    @Test
    fun processNonexistentFile() {
        val finder = CoffeeShopFinder(Coordinates(123.4, 42.4), "random.csv")

        assertThrows <FileNotFoundException> { finder.findClosestLocations() }
    }

}