package com.madalinb.coffeeshop.abstractions

interface Parser<T> {
    fun parseLine(line: String): T?
}