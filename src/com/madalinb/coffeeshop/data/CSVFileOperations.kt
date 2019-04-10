package com.madalinb.coffeeshop.data

import com.madalinb.coffeeshop.abstractions.FileOperations
import com.madalinb.coffeeshop.abstractions.Parser
import java.io.File
import java.io.FileNotFoundException
import java.io.IOException

class CSVFileOperations(var parser: Parser<CoffeeShop>) : FileOperations<CoffeeShop>() {
    override fun readFile(filename: String): List<CoffeeShop> {
        val list: List<CoffeeShop>
        list = ArrayList()

        try {
            File(filename).forEachLine {
                val shop = parser.parseLine(it)
                if (shop != null) {
                    list.add(shop)
                }
            }
        } catch (e: FileNotFoundException) {
            println("Error: file $filename wasn't found")
            println("${e.message}")
        } catch (e: IOException) {
            println("Error: I/O exception")
            println("${e.message}")
        } catch (e: Exception) {
            println("Error:")
            println("${e.message}")
        }

        return list
    }

}