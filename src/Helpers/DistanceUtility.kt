import kotlin.math.pow
import kotlin.math.sqrt

internal class DistanceUtility {

    fun calculateDistance(from: Coordinates, to: Coordinates): Double {
        return sqrt(((to.latitude - from.latitude).pow(2) + (to.longitude - from.longitude).pow(2)))
    }

    fun sortByDistance(list: List<CoffeeShop>): List<CoffeeShop> {
        return list.sortedBy { it.distanceFromUser }
    }

}