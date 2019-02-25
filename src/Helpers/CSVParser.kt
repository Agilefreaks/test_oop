package Helpers

import java.io.File
import java.io.FileNotFoundException

internal class CSVParser {

    fun parseCsvFileWithName(name: String): List<String> = try {
        val lines = File(name).readLines().distinct()
        if (lines.isEmpty()) { throw EmptyCsvException("$name is empty") }
        lines
    } catch (error: FileNotFoundException) {
        throw FileNotFoundException("$name was not found")
    }

}

internal class EmptyCsvException(message: String): Exception(message)