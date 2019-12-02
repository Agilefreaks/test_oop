## Solution description

Like any problem there are many solutions. Here I describe two aproaches.

### First solution

One solution is pretty strighforward:
    read the shops, one by one 
    calculate the distance to provided coordinates
    insert the distance into a sorted structure, sol
    remove last element from sol
        if more than needed elements in solution
    show/return sol

config.py contains refs/links to:
    a shop generator, in this instance a reader from csv
    a distance calculator, this depends on coordinate system, here euclidian distance on a chartesian coordinate system; 
    
    This facilitates changes:
       - to another coordinate system, like plus codes and consuming an API for distance calculation i.e. google maps
       - to another shops generator, i.e. other text file format, databases, APIs etc.

Implementation of shop generator and distance calculator can be found in the lib folder.

The test folder contains the following cases: 
    FindShops_test  it uses the provided csv sample and a case when there are two shops at the same distance
    Location_test   checks if the euclidian distance is correctly calculated
    ShopsCSV_test   checks if shops generator works on provided csv file 

From console the program runs with the command:
```
python find_nearby_shops.py 47.6 -122.4  ./data/starbucks.csv
```

### Second solution

Another solution is really strighforward, in my opinion, since it encodes the logic into one line of code, the select statement bellow.
    
We work with the assumption that the data is accessible to a relational database system/SQL system, whether by import/loading or by linking the csv files to RDS.

Here is an implementation for MariaDB/MySQL:

```
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_nearest_shops`(
	IN `ax` FLOAT,
	IN `ay` FLOAT,
	IN `n` INT  
)
    DETERMINISTIC
BEGIN
		SELECT shop_name, sqrt( POWER(ax-x, 2) + pow(ay-y, 2) ) as dist  FROM shops ORDER BY dist ASC LIMIT n;
END//
DELIMITER ;
```

```
call sp_nearest_shops( 47.6, -122.4, 3 );
```

