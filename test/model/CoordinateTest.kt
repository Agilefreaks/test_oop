import org.testng.annotations.Test
import kotlin.test.assertEquals

/**
 * created by AlexandraV on 12/25/2018
 */
@Test
fun isCoordinateValid_bothInvalid() {
    val coordinate = Coordinate("877.0", "956.256")
    assert(!coordinate.isCoordinateValid()) { "x in [-90, 90], y in [-180, 180]" }
}

@Test
fun isCoordinateValid_xInvalid() {
    val coordinate = Coordinate("877.0", "23.0")
    assert(!coordinate.isCoordinateValid()) { "x in [-90, 90]" }
}

@Test
fun isCoordinateValid_yInvalid() {
    val coordinate = Coordinate("45.8", "180.02")
    assert(!coordinate.isCoordinateValid()) { "y in [-180, 180]" }
}

@Test
fun isCoordinateValid_Valid() {
    val coordinate1 = Coordinate("45.0", "30.02")
    val coordinate2 = Coordinate("0.0", "0.3")
    val coordinate3 = Coordinate("-90.0", "180.0")
    val coordinate4 = Coordinate("90.0", "-180.0")

    assert(coordinate1.isCoordinateValid())
    assert(coordinate2.isCoordinateValid())
    assert(coordinate3.isCoordinateValid())
    assert(coordinate4.isCoordinateValid())
}

@Test
fun calculateDistanceTo() {
    val coordinate = Coordinate("10", "15")
    assertEquals(coordinate.distanceTo(7.0, 11.0), 5.0)
}