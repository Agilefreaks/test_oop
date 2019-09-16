function CalculateDistance(x, y, x1, y1) {
  const p = 0.017453292519943295; // Math.PI / 180
  const c = Math.cos;
  const a = 0.5 - c((x1 - x) * p) / 2 + 
          c(x * p) * c(x1 * p) * 
          (1 - c((y1 - y) * p)) / 2;

  return 12742 * Math.asin(Math.sqrt(a)); // 2 * R; R = 6371 km
}


describe("Coffee Shop App | Unit Tests", function() {
    describe("Calculate Distance Between Two Points (Haversine Formula)", function() {
         
        it("Should return '1.1958' km distance", function() {
            expect(CalculateDistance(45.783852, 24.151526, 45.773098, 24.151401).toFixed(4)).toBeCloseTo(1.1958);
        });
         
		it("Should return '1901.1248' km distance", function() {
            expect(CalculateDistance(45.783852, 24.151526, 51.141167, -0.483858).toFixed(4)).toBeCloseTo(1901.1248);
        });

		it("Should return '8984.8552' km distance", function() {
            expect(CalculateDistance(45.783852, 24.151526, 49.228821, -123.083211).toFixed(4)).toBeCloseTo(8984.8552);
        });

		it("Should return '216.2894' km distance", function() {
            expect(CalculateDistance(45.783852, 24.151526, 46.827218, 26.528130).toFixed(4)).toBeCloseTo(216.2894);
        });
    });
});