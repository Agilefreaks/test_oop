import kotlin.math.pow
import kotlin.math.sqrt

data class Location(val x: Double, val y: Double)

data class Distance(val value: Double) {
    override fun toString(): String {
        return "%.4f".format(value)
    }
}

fun distance(location1: Location, location2: Location): Distance {
    val (x1, y1) = location1
    val (x2, y2) = location2

    val value = sqrt((x1 - x2).pow(2) + (y1 - y2).pow(2))
    return Distance(value)
}
