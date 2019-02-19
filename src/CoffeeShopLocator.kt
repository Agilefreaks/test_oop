

fun main(args: Array<String>) {

    if (args.size != 3) { throw InvalidInput("Incorrect number of arguments") }

}

internal class InvalidInput(message: String): Exception(message)