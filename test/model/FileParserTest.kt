import org.testng.annotations.Test

/**
 * created by AlexandraV on 12/25/2018
 */
@Test
fun isCVSLineValid_EmptyLine() {
    val coordinate = Coordinate("50", "50")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line: List<String> = listOf()
    assert(!fileParser.isCSVLineValid(line)) { "Empty line" }
}

@Test
fun isCVSLineValid_BlankLine() {
    val coordinate = Coordinate("50", "50")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line: List<String> = listOf("", "", "")
    assert(!fileParser.isCSVLineValid(line)) { "Empty strings" }
}

@Test
fun isCSVLineValid_EmptyCoffeeShopName() {
    val coordinate = Coordinate("50", "50")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line: List<String> = listOf("", "50", "50")
    assert(!fileParser.isCSVLineValid(line)) { "No coffee shop name" }
}

@Test
fun insertShopIntoList_InsertFirstElement() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line: List<String> = listOf("Starbucks Seattle", "47.5809", "-122.316")
    fileParser.insertShopIntoList(CoffeeShop(line[0], Coordinate(line[1], line[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)
    assert(fileParser.coffeeShopsList.size == 1)
    assert(fileParser.coffeeShopsList[0].shopName == line[0])
}

@Test
fun insertShopIntoList_InsertSecondElementBeforeFirst() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line1: List<String> = listOf("Starbucks Seattle", "47.5809", "-122.316")
    fileParser.insertShopIntoList(CoffeeShop(line1[0], Coordinate(line1[1], line1[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    val line2: List<String> = listOf("Starbucks Seattle 2", "47.5869", "-122.3368")
    fileParser.insertShopIntoList(CoffeeShop(line2[0], Coordinate(line2[1], line2[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    assert(fileParser.coffeeShopsList.size == 2)
    assert(fileParser.coffeeShopsList[0].shopName == line2[0])
    assert(fileParser.coffeeShopsList[1].shopName == line1[0])
}

@Test
fun insertShopIntoList_InsertSecondElementAfterFirst() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line1: List<String> = listOf("Starbucks Seattle", "47.5809", "-122.316")
    fileParser.insertShopIntoList(CoffeeShop(line1[0], Coordinate(line1[1], line1[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    val line2: List<String> = listOf("Starbucks Moscow", "55.752047", "37.595242")
    fileParser.insertShopIntoList(CoffeeShop(line2[0], Coordinate(line2[1], line2[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    assert(fileParser.coffeeShopsList.size == 2)
    assert(fileParser.coffeeShopsList[0].shopName == line1[0])
    assert(fileParser.coffeeShopsList[1].shopName == line2[0])
}

@Test
fun insertShopIntoList_InsertElementsBetweenOther2Elements() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line1: List<String> = listOf("Starbucks Seattle 2", "47.5869", "-122.3368")
    fileParser.insertShopIntoList(CoffeeShop(line1[0], Coordinate(line1[1], line1[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    val line2: List<String> = listOf("Starbucks Moscow", "55.752047", "37.595242")
    fileParser.insertShopIntoList(CoffeeShop(line2[0], Coordinate(line2[1], line2[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    val line3: List<String> = listOf("Starbucks Seattle", "47.5809", "-122.316")
    fileParser.insertShopIntoList(CoffeeShop(line3[0], Coordinate(line3[1], line3[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    assert(fileParser.coffeeShopsList.size == 3)
    assert(fileParser.coffeeShopsList[0].shopName == line1[0])
    assert(fileParser.coffeeShopsList[1].shopName == line3[0])
    assert(fileParser.coffeeShopsList[2].shopName == line2[0])
}

@Test
fun insertShopIntoList_InsertElementAtTheEndOfList() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line1: List<String> = listOf("Starbucks Seattle 2", "47.5869", "-122.3368")
    fileParser.insertShopIntoList(CoffeeShop(line1[0], Coordinate(line1[1], line1[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 4)

    val line2: List<String> = listOf("Starbucks Moscow", "55.752047", "37.595242")
    fileParser.insertShopIntoList(CoffeeShop(line2[0], Coordinate(line2[1], line2[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 4)

    val line3: List<String> = listOf("Starbucks Seattle", "47.5809", "-122.316")
    fileParser.insertShopIntoList(CoffeeShop(line3[0], Coordinate(line3[1], line3[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 4)

    val line4: List<String> = listOf("Starbucks Sydney", "-33.871843", "151.206767")
    fileParser.insertShopIntoList(CoffeeShop(line4[0], Coordinate(line4[1], line4[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 4)

    assert(fileParser.coffeeShopsList.size == 4)
    assert(fileParser.coffeeShopsList[0].shopName == line1[0])
    assert(fileParser.coffeeShopsList[1].shopName == line3[0])
    assert(fileParser.coffeeShopsList[2].shopName == line2[0])
    assert(fileParser.coffeeShopsList[3].shopName == line4[0])
}

@Test
fun insertShopIntoList_InsertNothingAfterTheLimitWasReached() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    val line1: List<String> = listOf("Starbucks Seattle 2", "47.5869", "-122.3368")
    fileParser.insertShopIntoList(CoffeeShop(line1[0], Coordinate(line1[1], line1[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    val line2: List<String> = listOf("Starbucks Moscow", "55.752047", "37.595242")
    fileParser.insertShopIntoList(CoffeeShop(line2[0], Coordinate(line2[1], line2[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    val line3: List<String> = listOf("Starbucks Seattle", "47.5809", "-122.316")
    fileParser.insertShopIntoList(CoffeeShop(line3[0], Coordinate(line3[1], line3[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    val line4: List<String> = listOf("Starbucks Sydney", "-33.871843", "151.206767")
    fileParser.insertShopIntoList(CoffeeShop(line4[0], Coordinate(line4[1], line4[2]).distanceTo(coordinate.xCoordinate, coordinate.yCoordinate)), 3)

    assert(fileParser.coffeeShopsList.size == 3)
    assert(fileParser.coffeeShopsList[0].shopName == line1[0])
    assert(fileParser.coffeeShopsList[1].shopName == line3[0])
    assert(fileParser.coffeeShopsList[2].shopName == line2[0])
}

@Test
fun parseCoffeeShopsList_CheckOrderedList() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate)
    fileParser.parseCoffeeShopsList(3)

    for (i in 0..fileParser.coffeeShopsList.size - 2) {
        assert(fileParser.coffeeShopsList[i] < fileParser.coffeeShopsList[i + 1])
    }
}

@Test
fun parseCoffeeShopsList_N_isGreaterThanTheNumberOfValidLinesInTheFile() {
    val coordinate = Coordinate("47.6", "-122.4")
    val fileParser = FileParser("coffee_shops.csv", coordinate) // if coffee_shops.csv will contain more than 200 valid lines, this test will fail
    val n = 200
    fileParser.parseCoffeeShopsList(n)

    for (i in 0..fileParser.coffeeShopsList.size - 2) {
        assert(fileParser.coffeeShopsList[i] < fileParser.coffeeShopsList[i + 1])
    }
    assert(fileParser.coffeeShopsList.size < 200)
}