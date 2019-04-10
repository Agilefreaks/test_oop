package com.madalinb.coffeeshop.abstractions

import com.madalinb.coffeeshop.abstractions.validations.Arguments
import com.madalinb.coffeeshop.abstractions.validations.ValidDouble
import com.madalinb.coffeeshop.abstractions.validations.ValidString

interface Validator: Arguments, ValidString, ValidDouble {
}