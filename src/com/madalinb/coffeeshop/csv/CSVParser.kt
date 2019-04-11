package com.madalinb.coffeeshop.csv

import com.madalinb.coffeeshop.abstractions.Parser
import com.madalinb.coffeeshop.abstractions.Validator
import com.madalinb.coffeeshop.data.CoffeeShop

class CSVParser(var validator: Validator) :
    Parser<CoffeeShop> {

    @Throws(Exception::class)
    override fun parseLine(line: String): CoffeeShop? {
        val params = line.split(",")

        if (!validator.hasEnoughArguments(params)) {
            throw Exception("Wrong number of parameters in line '$line'")
        }
        if (!validator.isValidName(params[0])) {
            throw Exception("Not a valid name in line '$line'")
        }

        if (!validator.isValidDouble(params[1])) {
            throw Exception("Not a valid X coordinate in line '$line")
        }
        if (!validator.isValidDouble(params[2])) {
            throw Exception("Not a valid Y coordinate in line '$line")
        }

        return CoffeeShop(
            params[0].trim(),
            params[1].toDouble(),
            params[2].toDouble()
        )
    }
}