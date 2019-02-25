import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

internal class DistanceUtilityTest {

    private val testLocation = Coordinates(47.6, -122.4)

    @Test
    fun `calculate Distance from user to SF Starbucks should work`() {
        val sfStarbucks = Coordinates(37.5209,-122.3340)
        val actualDistance = DistanceUtility().calculateDistance(sfStarbucks, testLocation)

        assertEquals(10.079316088406003, actualDistance)
    }

    @Test
    fun `calculate distance from user to Sydney Starbucks should work`() {
        val sydneyStarbucks = Coordinates(-33.871843,151.206767)
        val actualDistance = DistanceUtility().calculateDistance(sydneyStarbucks, testLocation)

        assertEquals(285.47911333407376, actualDistance)
    }

    @Test
    fun `sort CoffeeShop list according to closest distance to user should work`() {
        val list = listOf(CoffeeShop(Coordinates(32.4,122.3), "Costa", 30.0),
                          CoffeeShop(Coordinates(42.3, 52.3), "Dunkin Donuts", 10.0),
                          CoffeeShop(Coordinates(123.5, 89.0), "Monk's Cafe", 20.0))
        val expectedSortedList = listOf(list[1], list[2], list[0])
        val actualSortedList = DistanceUtility().sortByDistance(list)

        assertEquals(expectedSortedList, actualSortedList)
    }

}