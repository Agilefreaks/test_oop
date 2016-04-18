/// <reference path="scripts/jasmine.js" />
/// <reference path="main.js" />

describe("Location:", function () {
    it("Check - Finding location", function () {
        var r = loc.check();
        expect(r).toBe(1);
    });
});

describe("CSV:", function () {
    it("Read - Check For Errors", function () {
        var r = csv.read;
        expect(r).not.toThrow(error);
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