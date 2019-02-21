import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

internal class DistanceUtilityTest {

    val testLocation = Coordinates(47.6, -122.4)

    @Test
    fun distanceFromSfStarbucks() {
        val sfStarbucks = Coordinates(37.5209,-122.3340)
        val computedDistance = DistanceUtility().calculateDistance(sfStarbucks, testLocation)

        assertEquals(10.079316088406003, computedDistance)
    }

    @Test
    fun distanceFromSydneyStarbucks() {
        val sydneyStarbucks = Coordinates(-33.871843,151.206767)
        val computedDistance = DistanceUtility().calculateDistance(sydneyStarbucks, testLocation)

        assertEquals(285.47911333407376, computedDistance)
    }

    @Test
    fun sortAccordingToLocation() {
        val list = listOf(CoffeeShop(Coordinates(32.4,122.3), "Costa"),
                          CoffeeShop(Coordinates(42.3, 52.3), "Dunkin Donuts"),
                          CoffeeShop(Coordinates(123.5, 89.0), "Monk's Cafe"))
        val expectedSortedList = listOf(list[1], list[2], list[0])
        val computedSortedList = DistanceUtility().sortByDistance(list, testLocation)

        assertEquals(expectedSortedList, computedSortedList)
    }

}