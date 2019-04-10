package com.madalinb.coffeeshop.abstractions.validations

interface StringValidator {
    fun isValidName(name: String): Boolean
}