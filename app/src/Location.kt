import kotlin.math.pow
import kotlin.math.sqrt

data class Location(val x: Double, val y: Double)

fun distance(location1: Location, location2: Location): Double {
    val (x1, y1) = location1
    val (x2, y2) = location2

    return sqrt((x1 - x2).pow(2) + (y1 - y2).pow(2))
}

fun Double.roundTo4Digits(): String {
    return "%.4f".format(this)
}
