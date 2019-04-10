package com.madalinb.coffeeshop.tests

import com.madalinb.coffeeshop.csv.CSVValidator
import org.junit.Before
import org.junit.Test


class CSVValidatorTest {
    var validator: CSVValidator? = null

    @Before
    fun setUp() {
        validator = CSVValidator()
    }

    @Test
    fun testEnoughArguments() {
        assert(validator?.hasEnoughArguments(listOf("Starbucks Rio De Janeiro", "-22.923489", "-43.234418")) == true)
    }

    @Test
    fun testValidName() {
        assert(validator?.isValidName("Starbucks Rio De Janeiro") == true)
    }

    @Test
    fun testInvalidName() {
        assert(validator?.isValidName(" ") == false)
    }

    @Test
    fun testValidDouble() {
        assert(validator?.isValidDouble("-22.923489") == true)
    }

    @Test
    fun testInvalidDouble() {
        assert(validator?.isValidDouble("-2A.923489") == false)
    }
}