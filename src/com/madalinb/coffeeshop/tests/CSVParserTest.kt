package com.madalinb.coffeeshop.tests

import com.madalinb.coffeeshop.csv.CSVParser
import com.madalinb.coffeeshop.csv.CSVValidator
import org.junit.Assert.assertNotNull
import org.junit.Assert.assertNull
import org.junit.Before
import org.junit.Test

class CSVParserTest {
    var validator: CSVValidator? = null
    var parser: CSVParser? = null

    @Before
    fun setUp() {
        validator = CSVValidator()
        parser = CSVParser(validator!!)
    }

    @Test
    fun testParseLineIncorrect() {
        assertNotNull(parser?.parseLine("Starbucks Seattle,47.5809,-122.3160"))
    }

    @Test
    fun testParseLineMissingArguments() {
        assertNull(parser?.parseLine("Starbucks Sydney,-33.871843"))
    }

    @Test
    fun testParseLineExtraArguments() {
        assertNull(parser?.parseLine("Starbucks SF,37.5209,-122.3340,100.4567"))
    }

    @Test
    fun testParseLineMissingName() {
        assertNull(parser?.parseLine(",47.5809,-122.3160"))
    }

    @Test
    fun testParseLineMissingFirstCoordinate() {
        assertNull(parser?.parseLine("Starbucks Seattle2,,-122.3368"))
    }

    @Test
    fun testParseLineMissingSecondCoordinate() {
        assertNull(parser?.parseLine("Starbucks Seattle2,47.5869,"))
    }

    @Test
    fun testParseLineWrongCoordinate() {
        assertNull(parser?.parseLine("Starbucks Seattle2,47.5869,-1A2.3B68"))
    }
}