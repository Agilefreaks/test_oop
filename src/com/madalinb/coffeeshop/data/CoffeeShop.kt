package com.madalinb.coffeeshop.data

data class CoffeeShop(var name: String, var x: Double, var y: Double) {
    fun distanceTo(x2: Double, y2: Double): Double {
        return Math.sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y))
    }
}