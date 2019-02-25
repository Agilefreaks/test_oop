import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows

internal class CoffeeShopFinderTest {

    @Test
    fun `retrieve list of closest coffee shops from CSV should work`() {
        val actualOutput = CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops.csv").findClosestLocations()
        val expectedOutput = "Starbucks Seattle2,0.0645\n" + "Starbucks Seattle,0.0861\n" + "Starbucks SF,10.0793"

        assertEquals(expectedOutput, actualOutput)
    }

    @Test
    fun `retrieve list of closest coffee shops from single entry CSV should work`() {
        val actualOutput = CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops_just_one.csv").findClosestLocations()
        val expectedOutput = "Starbucks Seattle,0.0861"

        assertEquals(expectedOutput, actualOutput)
    }

    @Test
    fun `retrieve list of closest coffee shops from malformed CSV should throw error`() {
        assertThrows <InvalidCsvException> { CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops_malformed.csv").findClosestLocations() }
    }

    @Test
    fun `retrieve list of closest coffee shops from CSV with duplicates should work`() {
        val actualOutput = CoffeeShopFinder(Coordinates(47.6, -122.4), "coffee_shops_duplicates.csv").findClosestLocations()
        val expectedOutput = "Starbucks Seattle2,0.0645\n" + "Starbucks Seattle,0.0861\n" + "Starbucks SF,10.0793"

        assertEquals(expectedOutput, actualOutput)
    }

}