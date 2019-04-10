package com.madalinb.coffeeshop.abstractions

interface Validator {
    fun hasEnoughArguments(line: List<String>): Boolean
    fun isValidName(name: String): Boolean
    fun isValidDouble(value: String): Boolean
}