package com.madalinb.coffeeshop

import com.madalinb.coffeeshop.data.CoffeeShop
import java.math.RoundingMode
import java.text.DecimalFormat

object CoffeeShopFinder {

    fun distanceTo(x1: Double, y1: Double, x2: Double, y2: Double): Double {
        return Math.sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1))
    }

    fun findClosest3Shops(shops: List<CoffeeShop>, x: Double, y: Double): List<CoffeeShop> {
        shops.forEach {
            it.distance = CoffeeShopFinder.distanceTo(it.x, it.y, x, y)
        }

        return shops.sortedBy { it.distance }.take(3)
    }

    fun printShops(shops: List<CoffeeShop>) {
        val df = DecimalFormat("#.####")
        df.roundingMode = RoundingMode.CEILING

        for (shop in shops) {
            println("${shop.name}, ${df.format(shop.distance)}")
        }
    }
}