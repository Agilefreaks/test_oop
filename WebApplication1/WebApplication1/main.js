
var csv = {

    check: function (location) {

        var ReadSucces = false;
        var rawFile = new XMLHttpRequest();
        rawFile.open("GET", "coffee_shops.csv", false);
        rawFile.onreadystatechange = function () {
            if (rawFile.readyState === 4 && rawFile.status === 200 || rawFile.readyState === 4 && rawFile.status === 0) {
                ReadSucces = true;
            }
        }
        
        rawFile.send(null);

        if (ReadSucces) {
            return csv.read(location, rawFile.responseText);
        }
        else {
            throw Error("Can't open CSV file");
        }

        
    },

    read: function (location, file) {

        var user_lat = location.coords.latitude;
        var user_lon = location.coords.longitude;

        var line = file.split("\n");
        var output = [];
        for (var i in line) {
            var el = line[i].split(",");
            if (el.length != 3) {
                throw Error("Invalid record in CSV");
            }

            output[i] = [];

            output[i]["name"] = el[0];
            output[i]["lat"] = el[1];
            output[i]["lon"] = el[2];

            output[i]["km"] = mats.transformToKM(user_lat, user_lon, el[1], el[2]);
            output[i]["dist"] = mats.getdistance(user_lat, user_lon, el[1], el[2]);

        }

        output.sort(function (a, b) { return a.km - b.km });

        var results = [];
        for (var i = 0; i < 3; i++) {
            results[i] = [];

            results[i]["name"] = output[i]["name"];
            results[i]["lat"] = output[i]["lat"];
            results[i]["lon"] = output[i]["lon"];

            results[i]["km"] = output[i]["km"];
            results[i]["dist"] = output[i]["dist"];

            //console.log(output[i]["name"] + "," + output[i]["km"]);
        }

        return results;

    }
}


function error(message) {
    console.warn(message);
}

var mats = {

    // Classic formula 
    getdistance: function (lat1, lon1, lat2, lon2) {

        var lat = Math.pow(lat2 - lat1, 2);
        var lon = Math.pow(lon2 - lon1, 2);

        var r = Math.sqrt(lat + lon);

        return r.toFixed(4);
    },


    // Haversine formula
    // URL: www.en.wikipedia.org/wiki/Haversine_formula
    // return real distance between 2 points in KM

    transformToKM: function (lat1, lon1, lat2, lon2) {

        var R = 6371;
        var dLat = this.deg2rad(lat2 - lat1);
        var dLon = this.deg2rad(lon2 - lon1);
        var a =
          Math.sin(dLat / 2) * Math.sin(dLat / 2) +
          Math.cos(this.deg2rad(lat1)) * Math.cos(this.deg2rad(lat2)) *
          Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c;

        return d.toFixed(4);
    },

    deg2rad: function(deg) {
        return deg * (Math.PI / 180);
    }

}


var loc = {
    check: function() {
        if (navigator.geolocation) {
            return 1;
        }
        else {
            return 0;
        }

    }
}

