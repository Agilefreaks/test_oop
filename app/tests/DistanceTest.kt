import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class DistanceTest {

    @Test
    fun `test distance from examples (user - seattle2)`() {
        val user = Location(47.6, -122.4)
        val seattle2 = Location(47.5869, -122.3368)
        val expectedDistanceToSeattle2 = "0.0645"

        assertEquals(expectedDistanceToSeattle2, distance(user, seattle2).roundTo4Digits())
    }

    @Test
    fun `test distance from examples (user - seattle)`() {
        val user = Location(47.6, -122.4)
        val seattle = Location(47.5809, -122.3160)
        val expectedDistanceToSeattle = "0.0861"

        assertEquals(expectedDistanceToSeattle, distance(user, seattle).roundTo4Digits())
    }

    @Test
    fun `test distance from examples (user - sf)`() {
        val user = Location(47.6, -122.4)
        val sf = Location(37.5209, -122.3340)
        val expectedDistanceToSF = "10.0793"

        assertEquals(expectedDistanceToSF, distance(user, sf).roundTo4Digits())
    }

    @Test
    fun `test real distance from examples (user - seattle2)`() {
        val user = Location(47.6, -122.4)
        val seattle2 = Location(47.5869, -122.3368)
        val expectedDistanceToSeattle2 = 0.06454339625400246

        assertEquals(expectedDistanceToSeattle2, distance(user, seattle2))
    }

    @Test
    fun `test real distance from examples (user - seattle)`() {
        val user = Location(47.6, -122.4)
        val seattle = Location(47.5809, -122.3160)
        val expectedDistanceToSeattle = 0.0861441234211632

        assertEquals(expectedDistanceToSeattle, distance(user, seattle))
    }

    @Test
    fun `test real distance from examples (user - sf)`() {
        val user = Location(47.6, -122.4)
        val sf = Location(37.5209, -122.3340)
        val expectedDistanceToSF = 10.079316088406003

        assertEquals(expectedDistanceToSF, distance(user, sf))
    }
}
