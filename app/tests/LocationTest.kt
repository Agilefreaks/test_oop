import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class LocationTest {
    @Test
    fun `test location`() {
        val location = Location(12.51, -50.12)
        assertEquals(12.51, location.x)
        assertEquals(-50.12, location.y)
    }
}
