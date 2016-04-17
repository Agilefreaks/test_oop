

var csv = {
    read: function (location) {

        var user_lat = location.coords.latitude;
        var user_lon = location.coords.longitude;

        var rawFile = new XMLHttpRequest();
        rawFile.open("GET", "coffee_shops.csv", true);
        rawFile.onreadystatechange = function () {
            if (rawFile.readyState === 4) {
                if (rawFile.status === 200 || rawFile.status == 0) {
                    var line = rawFile.responseText.split("\n");
                    var zzz = [];
                    for (var i in line) {
                        var x = line[i].split(",");
                        if (x.length != 3) {
                            throw Error("Invalid record in CSV");
                            break;
                        }

                        zzz[i] = [];
                        zzz[i]["name"] = x[0];
                        zzz[i]["km"] = mats.transformToKM(user_lat, user_lon, x[1], x[2]);

                        zzz.sort(function (a, b) { return a.km - b.km });

                    }

                    for (var i = 0; i < 3; i++) {
                        console.log(zzz[i]["name"] + "," + zzz[i]["km"].toFixed(4));
                    }

                }
            }
        }
        rawFile.send(null);

    }
}


function error(message) {
    console.warn(message);
}

var mats = {

    transformToKM: function (lat1, lon1, lat2, lon2) {
        var R = 6371;
        var dLat = mats.deg2rad(lat2 - lat1);
        var dLon = mats.deg2rad(lon2 - lon1);
        var a =
          Math.sin(dLat / 2) * Math.sin(dLat / 2) +
          Math.cos(mats.deg2rad(lat1)) * Math.cos(mats.deg2rad(lat2)) *
          Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c;
        return d;
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