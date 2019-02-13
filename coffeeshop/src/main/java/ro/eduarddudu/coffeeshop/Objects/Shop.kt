package ro.eduarddudu.coffeeshop.Objects

import android.location.Location

class Shop {
    var name: String? = null
    var location: Location? = null
    var distance = 0f
        get() = field / 1000
}
