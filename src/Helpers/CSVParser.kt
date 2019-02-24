package Helpers

import java.io.File
import java.io.FileNotFoundException

internal class CSVParser {

    fun parseCsvFileWithName(name: String): List<String> = try {
        File(name).readLines().distinct()
    } catch (error: FileNotFoundException) {
        throw FileNotFoundException("$name was not found")
    }

}