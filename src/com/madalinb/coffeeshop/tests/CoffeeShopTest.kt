package com.madalinb.coffeeshop.tests

import com.madalinb.coffeeshop.data.CoffeeShop
import org.junit.Before
import org.junit.Test

class CoffeeShopTest {
    var coffeeShop: CoffeeShop? = null

    @Before
    fun setUp() {
        coffeeShop = CoffeeShop("Starbucks Seattle", 47.5809, -122.3160)
    }

    @Test
    fun testComputeDistanceToAPoint() {
        assert(coffeeShop?.distanceTo(47.6, -122.4) == 0.0861441234211632)
    }

    @Test
    fun testCheckCoffeeShopName() {
        assert(coffeeShop?.name == "Starbucks Seattle")
    }

    @Test
    fun testCheckXCoordinate() {
        assert(coffeeShop?.x == 47.5809)
    }

    @Test
    fun testCheckYCoordinate() {
        assert(coffeeShop?.y == -122.3160)
    }
}