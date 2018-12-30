import org.testng.annotations.Test

/**
 * created by AlexandraV on 12/25/2018
 */
@Test
fun checkArguments_LessThan3Arguments() {
    val args1 = arrayOf("anything")
    assert(!areCommandLineArgumentsValid(args1)) { "1 argument isn't enough" }

    val args2 = arrayOf("something", "something else")
    assert(!areCommandLineArgumentsValid(args2)) { "2 arguments aren't enough" }
}

@Test
fun checkArguments_3Arguments_InvalidXCoordinate() {
    val args = arrayOf("2.00p89", "2", "fileName")
    assert(!areCommandLineArgumentsValid(args)) { "The x coordinate must be valid" }
}

@Test
fun checkArguments_3Arguments_InvalidYCoordinate() {
    val args = arrayOf("2.0089", "2*", "fileName")
    assert(!areCommandLineArgumentsValid(args)) { "The y coordinate must be valid" }
}

@Test
fun checkArguments_3ArgumentsInvalidFileName() {
    val args = arrayOf("2.0089", "2", "three.ocsv")
    assert(!areCommandLineArgumentsValid(args)) { "The file must be existent & valid" }
}

@Test
fun checkArguments_3ArgumentsNoFileNameJustExtension() {
    val args = arrayOf("2.0089", "2", ".csv")
    assert(!areCommandLineArgumentsValid(args)) { "The file must have a name, not just an extension" }
}

@Test
fun checkArguments_3ArgumentsFileDoesNotExist() {
    val args = arrayOf("5", "127", "file.csv")
    assert(!areCommandLineArgumentsValid(args)) { "The file should exist" }
}

@Test
fun checkArguments_3ValidArguments() {
    val args = arrayOf("5", "127", "coffee_shops.csv")
    assert(areCommandLineArgumentsValid(args))
}

@Test
fun checkArguments_MoreThan3Arguments() {
    val args = arrayOf("5", "127", "coffee_shops.csv", "something")
    assert(areCommandLineArgumentsValid(args))
}