import java.io.File

/**
 * Defines a FileParser object, containing different operations on the content of a given .csv file
 *
 * created by AlexandraV on 12/25/2018
 */
data class FileParser(var fileName: String, var userCoordinate: Coordinate) {
    val coffeeShopsList: MutableList<CoffeeShop> = mutableListOf()
    private val lines: List<String>? = File(fileName).useLines { it.toList() } // the reader is closed automatically

    /**
     *  parses the lines of the .csv file and converts them into CoffeeShops objects, if possible
     *  All the lines that cannot be converted to CoffeeShops objects will be written into  invalid_coffee_shops.txt file
     */
    fun parseCoffeeShopsList(n: Int) {
        val invalidCoffeeShopsList: MutableList<String> = mutableListOf()
        if (lines != null) {
            var lineNumber = 1
            lines.forEach { it ->
                val result: List<String> = it.split(",").map { it.trim() }
                if (isCSVLineValid(result)) {
                    val shopCoordinate = Coordinate(result[1], result[2])
                    insertShopIntoList(CoffeeShop(result[0], shopCoordinate.distanceTo(userCoordinate.xCoordinate, userCoordinate.yCoordinate)), n)
                } else {
                    invalidCoffeeShopsList.add("Line $lineNumber: $it \n")
                }
                lineNumber++
            }

            if (n <= coffeeShopsList.size) {
                coffeeShopsList.subList(0, n).forEach {
                    println("${it.shopName}, ${it.shopDistanceToUser}")
                }
            } else {
                coffeeShopsList.forEach { println("${it.shopName}, ${it.shopDistanceToUser}") }
                println("\nThe number of CoffeeShops you requested ($n) exceeds the number of valid shops in the .csv file. Only ${coffeeShopsList.size} were printed")
            }
        }
        // write all invalid lines (if there are any) in a file
        if (!invalidCoffeeShopsList.isEmpty()) {
            println("All invalid lines found in $fileName are written in invalid_coffee_shops.txt")
            File("invalid_coffee_shops.txt").bufferedWriter().use { out ->
                invalidCoffeeShopsList.forEach {
                    out.write(it)
                }
            }
        }
    }

    /**
     * inserts a CoffeeShop object into the list. The first ${n} elements of the list must be the first ${n} closest shops to the user
     * and they must be ordered by distance, from the closest to the furthest
     *
     * *** coffeeShop: the coffee shop to be inserted in the list
     * *** n : the number of elements from the beginning of the list, ordered by their distance to the user
     */
    fun insertShopIntoList(coffeeShop: CoffeeShop, n: Int) {
        var coffeeShopInserted = false
        // check if the current coffee shop enters the "top n" coffee shops according to their distance and insert it on the right position
        for (i in 0..(minOf(n, coffeeShopsList.size) - 1)) {
            if (coffeeShop < coffeeShopsList[i]) {
                coffeeShopsList.add(i, coffeeShop)
                coffeeShopInserted = true
                break
            }
        }
        // if the list of first n elements is not complete, and the current coffee shop was not added, we'll add it at the end of the list
        if (n > coffeeShopsList.size && !coffeeShopInserted) {
            coffeeShopsList.add(coffeeShop)
        }
    }

    /**
     * Checks if a line is valid, of the form: CoffeeShopName, X ShopCoordinate, Y ShopCoordinate
     */
    fun isCSVLineValid(line: List<String>): Boolean {
        if (line.size != 3) {
            return false
        } else {
            val shopCoordinate = Coordinate(line[1], line[2])
            // the shop coordinate must be valid
            if (!shopCoordinate.isCoordinateValid()) {
                return false
            }
            // the name of the shop shouldn't be empty
            if (line[0].trim().isEmpty()) {
                return false
            }
        }
        return true
    }
}