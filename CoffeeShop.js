class File {
	static Exists(filePath) {
		if (require("fs").existsSync(filePath))
			return true;

		return false;
	}

	static ReadAllLines(filePath) {
		return require("fs").readFileSync(filePath).toString().split('\n')
	}
}

function ParseCSV(filePath) {
	var rawData = File.ReadAllLines(filePath);
	var arrData = Array.from(Array(rawData.length), () => new Array(3));

	try {
		for (var i = 0; i < rawData.length; i++) {
			if ((rawData[i].split(',').length - 1) != 2)
				throw new Error(`Corrupted CSV template (check for the commas) -> row [${i + 1}]`);

			// Retrieves the coffee shop name
			arrData[i][0] = rawData[i].slice(0, rawData[i].indexOf(','));

			// Retrieves the X user coordinate
			arrData[i][1] = rawData[i].slice(rawData[i].indexOf(',') + 1, rawData[i].lastIndexOf(','));

			if (isNaN(arrData[i][1]))
				throw new Error(`Invalid [X] coordinate -> row [${i + 1}]`);
			// Retrieves the Y user coordinate
			arrData[i][2] = rawData[i].slice(rawData[i].lastIndexOf(',') + 1);

			if (isNaN(arrData[i][2]))
				throw new Error(`Invalid [Y] coordinate -> row [${i + 1}]`);
		}
	} catch(e) {
		throw new Error(`Can't parse the selected CSV file!\n   > : {${e}}`);
	}

	return arrData;
}

function CalculateDistance(x, y, x1, y1) {
  const p = 0.017453292519943295; // Math.PI / 180
  const c = Math.cos;
  const a = 0.5 - c((x1 - x) * p) / 2 + 
          c(x * p) * c(x1 * p) * 
          (1 - c((y1 - y) * p)) / 2;

  return 12742 * Math.asin(Math.sqrt(a)); // 2 * R; R = 6371 km
}


function Main() {
	var user_xcoo         = 0.00; // User X coordinates
	var user_ycoo         = 0.00; // User Y coordinates
	var shopCsv_filePath  = "";   // Shops CSV local file path
	var shopCsv_fileData;         // Shops CSV file data

	// # ARGUMENT PARSING # //
	process.argv.forEach(function(val, index, array) {
		switch(index) {
			case 2:
				user_xcoo = parseFloat(val);

				if (isNaN(user_xcoo))
					throw new Error("'User X coordinates' : Not a valid coordinates value!");

			break;

			case 3:
				user_ycoo = parseFloat(val);

				if (isNaN(user_ycoo)) 
					throw new Error("'User Y coordinates' : Not a valid coordinates value!");

			break;

			case 4:
				shopCsv_filePath = val;

				if (File.Exists(shopCsv_filePath) == false)
					throw new Error(`File '${shopCsv_filePath}' not found!`);

			break;
		}
	});


	// # MAIN CODE # //

	// Retrieves the first 3 nearest coffee shop
	(shopCsv_fileData = ParseCSV(shopCsv_filePath)).sort(function(a, b) {
		return CalculateDistance(user_xcoo, user_ycoo, a[1], a[2]) - CalculateDistance(user_xcoo, user_ycoo, b[1], b[2]);
	});

	// Retrieves the individual distance in km for the nearest coffee shop
	console.log("\n\n===OUTPUT===\n")
	for (var i = 0; i < 3; i++) {
		console.log(`${shopCsv_fileData[i][0]}, ${CalculateDistance(shopCsv_fileData[i][1], shopCsv_fileData[i][2], user_xcoo, user_ycoo).toFixed(4)} (km)`);
	}
}

// Entry point
Main();
