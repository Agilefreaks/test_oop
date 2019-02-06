import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class LocationTest {
    @Test
    fun `test location`() {
        val location = Location(12.51, -50.12)
        assertEquals(12.51, location.x)
        assertEquals(-50.12, location.y)
    }

    @Test
    fun `test location equality`() {
        val location1 = Location(12.51, -50.12)
        val location2 = Location(12.51, -50.12)
        assert(location1 == location2)
    }

    @Test
    fun `test location inequality fail`() {
        val location1 = Location(12.51, -50.12)
        val location2 = Location(12.51, -50.13)
        assert(location1 != location2)
    }
}
