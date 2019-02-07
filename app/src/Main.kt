fun main(args: Array<String>) {
    try {
        val x = args[0].toDouble()
        val y: Double = args[1].toDouble()
        val filename = args[2]

        val app = CoffeeShopApp(x, y, filename)
        val output = app.getOutput()

        System.out.println(output)
    }
    catch (e: Exception) {
        e.printStackTrace()
        System.out.println("Usage: <program name> <user x coordinate> <user y coordinate> <shop data filename>.")
    }
}
