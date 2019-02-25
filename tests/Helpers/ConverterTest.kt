import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows

internal class ConverterTest {

    private val testUserLocation = Coordinates(122.4, 10.2)

    @Test
    fun `transform CSV line into CoffeeShop object should work`() {
        val expectedCoffeeShop = CoffeeShop(Coordinates(-22.923489,-43.234418),"Starbucks Rio De Janeiro", 154.8358920991249)
        val line = "Starbucks Rio De Janeiro,-22.923489,-43.234418"
        val actualCoffeeShop = Converter().lineToCoffeeShop(line, testUserLocation)

        assertEquals(expectedCoffeeShop.name, actualCoffeeShop.name)
        assertEquals(expectedCoffeeShop.coordinates, actualCoffeeShop.coordinates)
        assertEquals(expectedCoffeeShop.distanceFromUser, actualCoffeeShop.distanceFromUser)
    }

    @Test
    fun `transform invalid CSV line into CoffeeShop object should throw error`() {
        val line = "Starbucks Rio De Janeiro -22.923489,-43.234418"

        assertThrows<InvalidCsvException> { Converter().lineToCoffeeShop(line, testUserLocation) }
    }

    @Test
    fun `transform list of CSV lines into CoffeeShop list should work`() {
        val lines = listOf("Starbucks Rio De Janeiro, -22.923489,-43.234418", "Starbucks San Francisco, 12.923489,123.231418", "Starbucks New York, 2.923489,-44.234128")
        val starbucksRio = CoffeeShop(Coordinates(-22.923489,-43.234418), "Starbucks Rio De Janeiro",154.8358920991249)
        val starbucksSF = CoffeeShop(Coordinates(12.923489,123.231418), "Starbucks San Francisco", 157.356944288531)
        val starbucksNY = CoffeeShop(Coordinates(2.923489,-44.234128), "Starbucks New York", 131.2924634998274)
        val actualCoffeeShopsList = Converter().linesToCoffeeShops(lines, testUserLocation)

        assertEquals(starbucksRio.name, actualCoffeeShopsList[0].name)
        assertEquals(starbucksSF.coordinates, actualCoffeeShopsList[1].coordinates)
        assertEquals(starbucksNY.distanceFromUser, actualCoffeeShopsList[2].distanceFromUser)
    }

    @Test
    fun `transform list of CoffeeShops into string should work`() {
        val list = listOf(CoffeeShop(Coordinates(32.4,122.3), "Costa", 10.0),
            CoffeeShop(Coordinates(42.3, 52.3), "Dunkin Donuts", 20.0),
            CoffeeShop(Coordinates(123.5, 89.0), "Monk's Cafe", 30.0))

        val actualOutput = Converter().listToString(list, 3)
        val expectedOutput = "Costa,10.0000\n" + "Dunkin Donuts,20.0000\n" + "Monk's Cafe,30.0000"

        assertEquals(expectedOutput, actualOutput)
    }

}