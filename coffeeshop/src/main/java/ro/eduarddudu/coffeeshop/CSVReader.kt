package ro.eduarddudu.coffeeshop

import android.location.Location
import android.util.Log
import ro.eduarddudu.coffeeshop.Objects.Shop
import java.io.File

internal object CSVReader {

    @Throws(Exception::class)
    fun parseCSV(input: String?): List<Shop>? {

        val csvSplitter = ","
        var array: List<Shop>?
        array = ArrayList()

        File(input).forEachLine {
            if (it.contains(",")) {
                val vars = it.split(csvSplitter.toRegex()).dropLastWhile({ it.isEmpty() }).toTypedArray()
                if (isValidLine(vars)) {
                    if (isValidName(vars)) {
                        if (isValidDouble(vars[1]) && isValidDouble(vars[2])) {

                                array.add(getShop(vars))

                        } else {
                            Log.e("ReadingFile", "Line: $it. Latitude or Longitude invalid.")
                        }
                    } else {
                        Log.e("ReadingFile", "Line: $it. Name of the location invalid.")
                    }
                } else {
                    /* Invalid line, continue with next one*/
                    Log.e("ReadingFile", "Line: $it does not contains all 3 mandatory elements or invalid delimitator.")
                }
            } else {
                Log.e("ReadingFile", "Line: $it does not contains comma delimitator.")
                /* Invalid line, continue with next one*/
            }
        }
        return array
    }


    fun isValidLine(vars: Array<String>): Boolean{
        return (vars.size == 3)
    }

    fun isValidName(vars: Array<String>): Boolean{
        return vars[0].isNotEmpty()
    }

    fun isValidDouble(value: String): Boolean{
        return value.toDoubleOrNull()!=null
    }


    fun getShop(vars: Array<String>): Shop{
        val shop = Shop()

        val location = Location(vars[0])

        location.latitude = vars[1].toDouble()
        location.longitude = vars[2].toDouble()

        shop.name = vars[0]
        shop.location = location

        return shop
    }

}
