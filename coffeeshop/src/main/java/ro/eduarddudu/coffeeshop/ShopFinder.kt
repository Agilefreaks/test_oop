package ro.eduarddudu.coffeeshop

import android.location.Location
import ro.eduarddudu.coffeeshop.Objects.Shop
import java.util.*

object ShopFinder {

    @Throws(Exception::class)
    fun findClosestLocations(latitude: Double, longitude: Double, path: String): List<Shop> {

        val shops = CSVReader.parseCSV(path)
                ?: throw Exception("Input file can not be parsed.")

        if (shops.size == 0) {
            throw Exception("Invalid input file.")
        }

        if (shops.size == 1) {
            return shops
        } else {
            val userLocation = Location("userLocation")

            userLocation.latitude = latitude
            userLocation.longitude = longitude

            for (shop in shops) {
                shop.distance = calculateDistance(userLocation, shop.location)
            }

            val sortedshops = shops.sortedWith(compareBy { it.distance })

            printForTest(getfirstMax3Elements(sortedshops))

            return getfirstMax3Elements(sortedshops)
        }
    }

    fun calculateDistance(src: Location, dest: Location?): Float{
        return src.distanceTo(dest)
    }

    fun getfirstMax3Elements(list: List<Shop>): ArrayList<Shop> {
        val firstShops = ArrayList<Shop>()

        val min = Math.min(2, list.size)

        for (i in 0..min) {
            firstShops.add(list[i])
        }

        return firstShops
    }

    fun printForTest(list: List<Shop>){
        for (shop in list) {
            println(shop.name + " -> " + shop.distance + " km")
        }
    }

}
