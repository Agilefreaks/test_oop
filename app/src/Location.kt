import kotlin.math.abs

data class Location(val x: Double, val y: Double)

fun distance(location1: Location, location2: Location): Double {
    var (x1, y1) = location1
    var (x2, y2) = location2

    return abs(x1 - x2) + abs(y1 - y2)
}
