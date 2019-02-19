import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows

internal class ConverterTest {

    @Test
    fun convertLineToCoffeeShop() {
        val expectedCoffeeShop = CoffeeShop(Coordinates(-22.923489,-43.234418),"Starbucks Rio De Janeiro")
        val line = "Starbucks Rio De Janeiro,-22.923489,-43.234418"
        val computedCoffeeShop = Converter.convertLineToCoffeeShop(line)

        assertEquals(expectedCoffeeShop.name, computedCoffeeShop.name)
        assertEquals(expectedCoffeeShop.coordinates.latitude, computedCoffeeShop.coordinates.latitude)
        assertEquals(expectedCoffeeShop.coordinates.longitude, computedCoffeeShop.coordinates.longitude)
    }

    @Test
    fun convertBadLineToCoffeeShop() {
        val line = "Starbucks Rio De Janeiro -22.923489,-43.234418"

        assertThrows<InvalidCsvException> { Converter.convertLineToCoffeeShop(line) }
    }

    @Test
    fun convertLinesToCoffeeShops() {
        val lines = listOf("Starbucks Rio De Janeiro, -22.923489,-43.234418", "Starbucks San Francisco, 12.923489,123.231418", "Starbucks New York, 2.923489,-44.234128")
        val starbucksRio = CoffeeShop(Coordinates(-22.923489,-43.234418), "Starbucks Rio De Janeiro")
        val starbucksSF = CoffeeShop(Coordinates(12.923489,123.231418), "Starbucks San Francisco")
        val starbucksNY = CoffeeShop(Coordinates(2.923489,-44.234128), "Starbucks New York")
        val computedCoffeeShopsList = Converter.convertLinesToCoffeeShops(lines)

        assertEquals(starbucksRio.name, computedCoffeeShopsList[0].name)
        assertEquals(starbucksSF.coordinates.latitude, computedCoffeeShopsList[1].coordinates.latitude)
        assertEquals(starbucksNY.coordinates.longitude, computedCoffeeShopsList[2].coordinates.longitude)
    }

}