package com.madalinb.coffeeshop.abstractions.validations

interface ArgumentsValidator {
    fun hasEnoughArguments(line: List<String>): Boolean
}