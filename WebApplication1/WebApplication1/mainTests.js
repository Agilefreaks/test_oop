/// <reference path="scripts/jasmine.js" />
/// <reference path="main.js" />

describe("Location:", function () {
    it("Check - Finding location", function () {
        var r = loc.check();
        expect(r).toBe(1);
    });
});

describe("CSV:", function () {

    var location = { coords: { latitude: 46.7667, longitude: 23.6 } };

    function Location(name, km) {
        this.name = name;
        this.km = km;
    }


    it("Read - Check For Errors", function () {
        var r = csv.read;
        expect(r).not.toThrow(error);
    });


    it("Read - Check Output", function () {

        Location1 = new Location("Starbucks Moscow", "1390.2453"); // name and distance in km
        Location2 = new Location("Starbucks Seattle2", "9014.8788");
        Location3 = new Location("Starbucks Seattle", "9014.8875");

        var results = csv.check(location);

        expect(results[0]["name"]).toEqual(Location1.name);
        expect(results[0]["km"]).toBe(Location1.km);

        expect(results[1]["name"]).toEqual(Location2.name);
        expect(results[1]["km"]).toBe(Location2.km);

        expect(results[2]["name"]).toEqual(Location3.name);
        expect(results[2]["km"]).toBe(Location3.km);


    });

});

describe("Mats:", function () {
    it("Transform To KM - Returning a value", function () {
        var r = mats.transformToKM;
        expect(r).toBeDefined();
    });
    it("DEG2RAD - Returning a value", function () {
        var r = mats.deg2rad;
        expect(r).toBeDefined();
    });
});
