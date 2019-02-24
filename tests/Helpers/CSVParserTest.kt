package Helpers

import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

internal class CSVParserTest {

    @Test
    fun `transform valid CSV file into String list`() {
        val expectedOutput = listOf("Starbucks Seattle,47.5809,-122.3160",
                "Starbucks SF,37.5209,-122.3340",
                "Starbucks Moscow,55.752047,37.595242",
                "Starbucks Seattle2,47.5869,-122.3368",
                "Starbucks Rio De Janeiro,-22.923489,-43.234418",
                "Starbucks Sydney,-33.871843,151.206767")
        val actualOutput = CSVParser().parseCsvFileWithName("coffee_shops.csv")

        assertEquals(expectedOutput, actualOutput)
    }

}