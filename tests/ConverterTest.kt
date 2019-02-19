import org.junit.jupiter.api.Assertions.*
import org.junit.jupiter.api.Test

internal class ConverterTest {

    @Test
    fun convertLineToCoffeeShop() {
        val name = "Starbucks Rio De Janeiro"
        val coordinates = Coordinates(-22.923489,-43.234418)
        val line = "Starbucks Rio De Janeiro,-22.923489,-43.234418"
        val computedCoffeeShop = Converter.convertLineToCoffeeShop(line)
        assertEquals(name, computedCoffeeShop.name)
        assertEquals(coordinates.latitude, computedCoffeeShop.coordinates.latitude)
        assertEquals(coordinates.longitude, computedCoffeeShop.coordinates.longitude)
    }

    @Test
    fun convertBadLineToCoffeeShop() {
        val line = "Starbucks Rio De Janeiro -22.923489,-43.234418"
        org.junit.jupiter.api.assertThrows<InvalidCsvException> { Converter.convertLineToCoffeeShop(line) }
    }

}