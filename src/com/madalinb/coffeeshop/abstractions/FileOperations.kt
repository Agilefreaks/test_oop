package com.madalinb.coffeeshop.abstractions

abstract class FileOperations<T> {
    abstract fun readFile(filename: String): List<T>
}