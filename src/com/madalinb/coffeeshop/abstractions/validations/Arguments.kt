package com.madalinb.coffeeshop.abstractions.validations

interface Arguments {
    fun hasEnoughArguments(line: List<String>): Boolean
}