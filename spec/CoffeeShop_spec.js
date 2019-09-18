describe("Coffee Shop App | Unit Tests", function() {
	var test = require("../spec/CoffeeShop_src.js");

    describe("CSV Parsing", function() {
         
		describe("Valid CSV File", function() {
			it("Should successfully parse the file", function() {
				expect(test.ParseCSV("coffee_shops.csv")).nothing();
			});
		});
    });

	describe("Calculate Distance Between Two Points On A Flat Surface", function() {
         

		describe("Starbucks Seattle2", function() {
			it("Should return: 0.0645", function() {
				expect(test.GetDistanceBetweenTwoPointsFlatSurface(47.6, -122.4, 47.5869, -122.3368).toFixed(4)).toBe("0.0645");
			});
		});

		describe("Starbucks Seattle", function() {
			it("Should return: 0.0861", function() {
				expect(test.GetDistanceBetweenTwoPointsFlatSurface(47.6, -122.4, 47.5809, -122.3160).toFixed(4)).toBe("0.0861");
			});
		});

		describe("Starbucks SF", function() {
			it("Should return: 10.0793", function() {
				expect(test.GetDistanceBetweenTwoPointsFlatSurface(47.6, -122.4, 37.5209, -122.3340).toFixed(4)).toBe("10.0793");
			});
		});
    });
});
