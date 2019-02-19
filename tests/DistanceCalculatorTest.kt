import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

internal class DistanceCalculatorTest {

    val testLocation = Coordinates(47.6, -122.4)

    @Test
    fun distanceFromSfStarbucks() {
        val sfStarbucks = Coordinates(37.5209,-122.3340)
        val computedDistance = DistanceCalculator.calculateDistance(sfStarbucks, testLocation)
        assertEquals(10.079316088406003, computedDistance)
    }

    @Test
    fun distanceFromSydneyStarbucks() {
        val sydneyStarbucks = Coordinates(-33.871843,151.206767)
        val computedDistance = DistanceCalculator.calculateDistance(sydneyStarbucks, testLocation)
        assertEquals(285.47911333407376, computedDistance)
    }

}