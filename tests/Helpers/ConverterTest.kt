import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows

internal class ConverterTest {

    @Test
    fun convertLineToCoffeeShop() {
        val expectedCoffeeShop = CoffeeShop(Coordinates(-22.923489,-43.234418),"Starbucks Rio De Janeiro")
        val line = "Starbucks Rio De Janeiro,-22.923489,-43.234418"
        val computedCoffeeShop = Converter.lineToCoffeeShop(line)

        assertEquals(expectedCoffeeShop.name, computedCoffeeShop.name)
        assertEquals(expectedCoffeeShop.coordinates.latitude, computedCoffeeShop.coordinates.latitude)
        assertEquals(expectedCoffeeShop.coordinates.longitude, computedCoffeeShop.coordinates.longitude)
    }

    @Test
    fun convertBadLineToCoffeeShop() {
        val line = "Starbucks Rio De Janeiro -22.923489,-43.234418"

        assertThrows<InvalidCsvException> { Converter.lineToCoffeeShop(line) }
    }

    @Test
    fun convertLinesToCoffeeShops() {
        val lines = listOf("Starbucks Rio De Janeiro, -22.923489,-43.234418", "Starbucks San Francisco, 12.923489,123.231418", "Starbucks New York, 2.923489,-44.234128")
        val starbucksRio = CoffeeShop(Coordinates(-22.923489,-43.234418), "Starbucks Rio De Janeiro")
        val starbucksSF = CoffeeShop(Coordinates(12.923489,123.231418), "Starbucks San Francisco")
        val starbucksNY = CoffeeShop(Coordinates(2.923489,-44.234128), "Starbucks New York")
        val computedCoffeeShopsList = Converter.linesToCoffeeShops(lines)

        assertEquals(starbucksRio.name, computedCoffeeShopsList[0].name)
        assertEquals(starbucksSF.coordinates.latitude, computedCoffeeShopsList[1].coordinates.latitude)
        assertEquals(starbucksNY.coordinates.longitude, computedCoffeeShopsList[2].coordinates.longitude)
    }

    @Test
    fun convertListToString() {
        val testLocation = Coordinates(47.6, -122.4)
        val list = listOf(CoffeeShop(Coordinates(32.4,122.3), "Costa"),
            CoffeeShop(Coordinates(42.3, 52.3), "Dunkin Donuts"),
            CoffeeShop(Coordinates(123.5, 89.0), "Monk's Cafe"))
        list.forEach { it.distanceFromUser = DistanceUtility.calculateDistance(it.coordinates, testLocation) }
        val computedOutput = Converter.listToString(list, 3)
        val expectedOutput = "Costa,245.1716\n" + "Dunkin Donuts,174.7804\n" + "Monk's Cafe,224.6125"
        assertEquals(expectedOutput, computedOutput)
    }

}