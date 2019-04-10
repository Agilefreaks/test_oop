package com.madalinb.coffeeshop

import com.madalinb.coffeeshop.csv.CSVParser
import com.madalinb.coffeeshop.csv.CSVValidator
import com.madalinb.coffeeshop.data.CSVFileOperations
import java.math.RoundingMode
import java.text.DecimalFormat

fun main(args: Array<String>) {
    val validator = CSVValidator()
    val parser = CSVParser(validator)
    val fileOps = CSVFileOperations(parser)

    val map = mutableMapOf<Double, String>()
    val df = DecimalFormat("#.####")
    df.roundingMode = RoundingMode.CEILING

    val x: Double? = args[0].toDoubleOrNull()
    val y: Double? = args[1].toDoubleOrNull()
    val filename = args[2]

    if (args.size != 3) {
        println("Error: incorrect number of application arguments")
        showAppUsage()
        return
    }

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

    var distance:Double
    coffeeShops.forEach {
        distance = it.distanceTo(x, y)
        map[distance] = it.name
    }

    val sortedMap = map.toSortedMap()
    var counter = 0

    for ((dist, name) in sortedMap) {
        if (counter < 3) {
            println("$name, ${df.format(dist)}")
            counter++
        } else
            return
    }
}

fun showAppUsage() {
    println()
    println("Usage:")
    println("CoffeeShop user_X_coordinate user_Y_coordinate filename")
    println()
}