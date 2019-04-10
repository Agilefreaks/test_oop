package com.madalinb.coffeeshop.abstractions

import com.madalinb.coffeeshop.abstractions.validations.ArgumentsValidator
import com.madalinb.coffeeshop.abstractions.validations.DoubleValidator
import com.madalinb.coffeeshop.abstractions.validations.StringValidator

interface Validator: ArgumentsValidator, StringValidator, DoubleValidator {
}