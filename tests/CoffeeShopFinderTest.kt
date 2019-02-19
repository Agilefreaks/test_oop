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
    fun processNonexistentFile() {
        val finder = CoffeeShopFinder(Coordinates(123.4, 42.4), "random.csv")
        assertThrows <FileNotFoundException> { finder.findClosestLocations() }
    }

}