import java.text.DecimalFormat
import kotlin.math.pow
import kotlin.math.sqrt

/**
* Defines a Coordinate object
*
 * created by AlexandraV on 12/25/2018
 */
data class Coordinate(var x: String, var y: String) {
    /**
     * minimum valid latitude
     */
    private val minLatitude = -90.0

    /**
     * maximum valid latitude
     */
    private val maxLatitude = 90.0

    /**
     * minimum valid longitude
     */
    private val minLongitude = -180.0

    /**
     * maximum valid longitude
     */
    private val maxLongitude = 180.0

    val xCoordinate = convertToDouble(x)

    val yCoordinate = convertToDouble(y)

    /**
     * checks if the current coordinate is valid
     */
    fun isCoordinateValid(): Boolean {
        return xCoordinate in minLatitude..maxLatitude && yCoordinate in minLongitude..maxLongitude
    }

    /**
     * calculates the distance between the current coordinate and the one given as an argument
     */
    fun distanceTo(x: Double, y: Double): Double {
        val distance: Double = sqrt((xCoordinate.minus(x)).pow(2) + (yCoordinate.minus(y)).pow(2))
        val df = DecimalFormat("#.####")
        return df.format(distance).toDouble()
    }

    /**
     * converts a String into Double
     *
     **** arg: the String to be converted to a Double
     **** returns the Double corresponding to the given coordinate as a String, if the coordinate is valid,
     *              or an invalid coordinate otherwise
     */
    private fun convertToDouble(arg: String): Double {
        return try {
            arg.toDouble()
        } catch (nfe: NumberFormatException) {
            maxLongitude + 1
        }
    }
}