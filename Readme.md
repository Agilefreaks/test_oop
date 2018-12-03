## Overview

You have been hired by a company that builds a mobile app for coffee addicts.  You are 
responsible for taking the user’s location and returning a list of the three closest coffee shops.

## Input

The coffee shop list is a comma separated file with rows of the following form:
`Name,Y Coordinate,X Coordinate`

The quality of data in this list of coffee shops may vary.  Malformed entries should cause the 
program to exit appropriately. 

Your program will be executed directly from the command line and will be provided three 
arguments in the following order:
`<user y coordinate> <user x coordinate> <shop data filename>`

## Output

Write a program that takes the user’s coordinates encoded as listed above and prints out a 
newline­separated list of the three closest coffee shops (including distance from the user) in 
order of closest to farthest.  These distances should be rounded to four decimal places. 

Assume all coordinates lie on a plane.

## Example

Using the [coffee_shop.csv](coffee_shop.csv)

__Input__

`47.6 -122.4 coffee_shop.csv`

__Expected output__

```
Starbucks Seattle2,0.0645
Starbucks Seattle,0.0861
Starbucks SF,10.0793
```

## Test application

To test the application you need to provide the coffee shop input file in user documents Shared Playground Data folder (~/Documents/Shared Playground Data).

To run the playground with unit tests you need to open the playground in Xcode, uncomment the unit tests related code and run the playground. To provide different input data, you can edit the command line arguments provided under "run from within playground, not command line" comment.

To run the playground from terminal provide the following command:
swift <path_to_coffee_shop_playground>/CoffeeShop.playground/Contents.swift <user y coordinate> <user x coordinate> <shop data filename>
The unit tests related code needs to be commented in this case.