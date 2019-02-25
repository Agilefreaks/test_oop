package Helpers

import org.junit.jupiter.api.Test
import org.junit.jupiter.api.assertThrows
import java.io.FileNotFoundException
import kotlin.test.assertEquals

internal class CSVParserTest {

    @Test
    fun `transform valid CSV file into String list should work`() {
        val expectedOutput = listOf("Starbucks Seattle,47.5809,-122.3160",
                "Starbucks SF,37.5209,-122.3340",
                "Starbucks Moscow,55.752047,37.595242",
                "Starbucks Seattle2,47.5869,-122.3368",
                "Starbucks Rio De Janeiro,-22.923489,-43.234418",
                "Starbucks Sydney,-33.871843,151.206767")
        val actualOutput = CSVParser().parseCsvFileWithName("coffee_shops.csv")

        assertEquals(expectedOutput, actualOutput)
    }

    @Test
    fun `transform missing CSV file into String list should throw error`() {
        assertThrows<FileNotFoundException> { CSVParser().parseCsvFileWithName("random.csv") }
    }

    @Test
    fun `retrieve list of closest coffee shops from empty CSV should throw error`() {
        assertThrows <EmptyCsvException> { CSVParser().parseCsvFileWithName("coffee_shops_empty.csv") }
    }

}