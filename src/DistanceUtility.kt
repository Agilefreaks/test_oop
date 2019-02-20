import kotlin.math.pow
import kotlin.math.sqrt

internal object DistanceUtility {

    fun calculateDistance(from: Coordinates, to: Coordinates): Double {
        return sqrt(((to.latitude - from.latitude).pow(2) + (to.longitude - from.longitude).pow(2)))
    }

    fun sortByDistance(list: List<CoffeeShop>, location: Coordinates): List<CoffeeShop> {
        list.forEach { it.distanceFromUser = calculateDistance(it.coordinates, location) }
        return list.sortedBy { it.distanceFromUser }
    }

}