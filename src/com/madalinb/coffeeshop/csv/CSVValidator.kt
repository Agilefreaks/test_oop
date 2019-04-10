package com.madalinb.coffeeshop.csv

import com.madalinb.coffeeshop.abstractions.Validator


class CSVValidator : Validator {
    override fun hasEnoughArguments(line: List<String>): Boolean {
        return line.size == 3
    }

    override fun isValidName(name: String): Boolean {
        return name.trim().isNotEmpty()
    }

    override fun isValidDouble(value: String): Boolean {
        return value.toDoubleOrNull() != null
    }
}