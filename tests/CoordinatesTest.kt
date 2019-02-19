import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

internal class CoordinatesTest {

    @Test
    fun createCoordinates() {
        val coordinates = Coordinates(144.5, 12.4)
        assertEquals(144.5, coordinates.latitude)
        assertEquals(12.4, coordinates.longitude)
    }

}