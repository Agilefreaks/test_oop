import parser.FileParser
import java.io.File

/**
 * created by AlexandraV on 12/25/2018
 */
fun main(args: Array<String>) {
    if (!areCommandLineArgumentsValid(args)) {
        return
    } else {
        // read the coordinate of the user
        val userCoordinate = Coordinate(args[0], args[1])

        // read content of .csv file
        val fileParser = FileParser(args[2], userCoordinate)
        fileParser.parseCoffeeShopsList(3)
    }
}

/**
 * checks if the arguments passed in the command line are valid
 *
 * the conditions are:
 *    * at least 3 arguments
 *    * the first 2 represent a valid user coordinate
 *    * the 3rd is a string representing a csv file name
 */
fun areCommandLineArgumentsValid(args: Array<String>): Boolean {
    if (args.size < 3) {
        println("Please provide 3 command-line arguments: <User X Coordinate>, <User Y Coordinate>, <Shop Data Filename (.csv)>")
        return false
    } else {
        if (!Coordinate(args[0], args[1]).isCoordinateValid()) {
            println("At least one shop coordinate is not valid. Make sure that all coordinates are Double numbers, [-90 <= x <= 90], [-180 <= y <= 180]")
            return false
        } else {
            if (!args[2].endsWith(".csv", true) || args[2].length <= 4 || !File(args[2]).exists()) {
                println("Please provide a valid & existing .csv filename!")
                return false
            }
        }
    }
    return true
}