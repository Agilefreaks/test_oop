/**
 * Parses the given args
 * @return [0] User X Coordinates, [1] User Y Coordinates, [2] CSV File Path
 */
function ParseArgs(args) {
	let user_xcoo;
	let user_ycoo;
	let csvFile_path;

	args.forEach(function(val, index, array) {
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
				csvFile_path = val;

				if (require("fs").existsSync(csvFile_path) == false)
					throw new Error(`File '${csvFile_path}' not found!`);

			break;
		}
	});

	return [user_xcoo, user_ycoo, csvFile_path];
}

/**
 * Parses the CSV file row by row and returns the data into an array which structure is the below:
 * arr[i][0] = Shop's name
 *       [1] = User X coordinates
 *	     [2] = User Y coordinates
 */
function ParseCSV(filePath) {
	let rawCsvData       = require("fs").readFileSync(filePath).toString().split('\n');
	let processedCsvData = Array.from(Array(rawCsvData .length), () => new Array(3));

	try {
		for (let i = 0; i < rawCsvData.length; i++) {
			// Checks if the CSV template is corrupted
			// We do this by knowing that every row in the CSV must have 3 columns -> 2 commas per row
			if ((rawCsvData[i].split(',').length - 1) != 2)
				throw new Error(`Corrupted CSV template (check for missing commas between the columns) -> row [${i + 1}]`);

			// Retrieves the coffee shop name
			processedCsvData[i][0] = rawCsvData[i].slice(0, rawCsvData[i].indexOf(','));

			// Retrieves the X user coordinate
			processedCsvData[i][1] = rawCsvData[i].slice(rawCsvData[i].indexOf(',') + 1, rawCsvData[i].lastIndexOf(','));

			if (isNaN(processedCsvData[i][1]))
				throw new Error(`Invalid [X] coordinate -> row [${i + 1}]`);

			// Retrieves the Y user coordinate
			processedCsvData[i][2] = rawCsvData[i].slice(rawCsvData[i].lastIndexOf(',') + 1);

			if (isNaN(processedCsvData[i][2]))
				throw new Error(`Invalid [Y] coordinate -> row [${i + 1}]`);
		}
	} catch(e) {
		throw new Error(`Can't parse the selected CSV file!\n   > : {${e}}`);
	}

	return processedCsvData;
}

function GetDistanceBetweenTwoPointsFlatSurface(x, y, x1, y1) {
	return Math.sqrt(Math.pow(x - x1, 2) + Math.pow(y - y1, 2));
}

function Main() {
	//user_xcoo;    // User X coordinates (float)
	//user_ycoo;    // User Y coordinates (float)
	//csvFile_path; // Shops CSV local file path (str)
	//csvFile_data; // Shops CSV file data (multidimensional array)
	const [user_xcoo, user_ycoo, csvFile_path] = ParseArgs(process.argv);

	(csvFile_data = ParseCSV(csvFile_path)).sort(function(a, b) {
		return GetDistanceBetweenTwoPointsFlatSurface(user_xcoo, user_ycoo, a[1], a[2]) - GetDistanceBetweenTwoPointsFlatSurface(user_xcoo, user_ycoo, b[1], b[2]);
	});

	console.log("\n\n===OUTPUT===\n")
	for (let i = 0; i < 3; i++) {
		console.log(`${csvFile_data[i][0]}, ${GetDistanceBetweenTwoPointsFlatSurface(csvFile_data[i][1], csvFile_data[i][2], user_xcoo, user_ycoo).toFixed(4)}`);
	}
}
Main();
