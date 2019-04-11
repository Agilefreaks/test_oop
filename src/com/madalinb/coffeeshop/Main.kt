package com.madalinb.coffeeshop

import com.madalinb.coffeeshop.csv.CSVParser
import com.madalinb.coffeeshop.csv.CSVValidator
import com.madalinb.coffeeshop.data.CSVFileOperations
import com.madalinb.coffeeshop.data.CoffeeShop

fun main(args: Array<String>) {
    val validator = CSVValidator()
    val parser = CSVParser(validator)
    val fileOps = CSVFileOperations(parser)

    if (args.size != 3) {
        println("Error: incorrect number of application arguments")
        showAppUsage()
        return
    }

    val x: Double? = args[0].toDoubleOrNull()
    val y: Double? = args[1].toDoubleOrNull()
    val filename = args[2]

    if (x == null || y == null) {
        println("Error: the coordinates for X and/or Y are incorrect")
        showAppUsage()
        return
    }

    if (filename.isEmpty()) {
        println("Error: file name with the coffee shops data is missing")
        showAppUsage()
        return
    }

    val coffeeShops = fileOps.readFile(filename)

    if (coffeeShops.isEmpty()) {
        println("Processing the file '$filename' has found no valid entries")
        return
    }

    val sortedShops = CoffeeShopFinder.findClosest3Shops(coffeeShops, x, y)

    CoffeeShopFinder.printShops(sortedShops)
}

fun showAppUsage() {
    println()
    println("Usage:")
    println("CoffeeShop user_X_coordinate user_Y_coordinate filename")
    println()
}

