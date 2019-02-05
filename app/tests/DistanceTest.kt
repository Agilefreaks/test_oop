import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class DistanceTest {
    @Test
    fun `test distance from examples`() {
        val user = Location(47.6, -122.4)
        val seattle2 = Location(47.5869, -122.3368)
        val seattle = Location(47.5809, -122.3160)
        val sf = Location(37.5209, -122.3340)

        val expectedDistanceToSeattle2 = 0.0645
        val expectedDistanceToSeattle = 0.0861
        val expectedDistanceToSF = 10.0793

        assertEquals(expectedDistanceToSeattle2, distance(user, seattle2))
        assertEquals(expectedDistanceToSeattle, distance(user, seattle))
        assertEquals(expectedDistanceToSF, distance(user, sf))
    }
}
