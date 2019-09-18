## How to run the code

You must have installed [Node.js](https://nodejs.org/en/download/) and [Jasmine](https://jasmine.github.io/setup/nodejs.html)

Just open a terminal session in the same directory where the project is and run [CoffeeShop.js](CoffeeShop.js) through Node.

```
node CoffeeShop.js 47.6 -122.4 coffee_shops.csv
```

To launch the unit tests just execute this command in the terminal session.

```
jasmine spec/CoffeeShop_spec.js
```

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
`<user x coordinate> <user y coordinate> <shop data filename>`

## Output

Write a program that takes the user’s coordinates encoded as listed above and prints out a 
newline­separated list of the three closest coffee shops (including distance from the user) in 
order of closest to farthest.  These distances should be rounded to four decimal places. 

Assume all coordinates lie on a plane.

## Example

Using the [coffee_shops.csv](coffee_shops.csv)

__Input__

`47.6 -122.4 coffee_shops.csv`

__Expected output__

```
Starbucks Seattle2,0.0645
Starbucks Seattle,0.0861
Starbucks SF,10.0793
```

