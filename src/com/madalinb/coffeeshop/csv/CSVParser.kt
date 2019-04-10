package com.madalinb.coffeeshop.csv

import com.madalinb.coffeeshop.abstractions.Parser
import com.madalinb.coffeeshop.abstractions.Validator
import com.madalinb.coffeeshop.data.CoffeeShop

class CSVParser(var validator: Validator) :
    Parser<CoffeeShop> {
    override fun parseLine(line: String): CoffeeShop? {
        val params = line.split(",")

        if (validator.hasEnoughArguments(params)) {
            if (validator.isValidName(params[0])) {
                if (validator.isValidDouble(params[1]) &&
                    validator.isValidDouble(params[2])
                ) {
                    return CoffeeShop(
                        params[0].trim(),
                        params[1].toDouble(),
                        params[2].toDouble()
                    )
                } else
                    println("Error: not a valid X and/or Y coordinate in line '$line'")
            } else
                println("Error: not a valid name in line '$line'")
        } else
            println("Error: wrong number of parameters in line '$line'")

        return null
    }
}