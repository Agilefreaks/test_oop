import kotlin.math.pow
import kotlin.math.sqrt

internal object DistanceCalculator {

    fun calculateDistance(from: Coordinates, to: Coordinates): Double {
        return sqrt(((to.latitude - from.latitude).pow(2) + (to.longitude - from.longitude).pow(2)))
    }

}