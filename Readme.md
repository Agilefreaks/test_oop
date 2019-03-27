## Overview

You have been hired by a company that builds a mobile app for coffee addicts.  You are 
responsible for taking the user’s location and returning a list of the three closest coffee shops.

## Coffee Addict 101

The application for the addicted ones has been created.

## How and what to install to run the application

This magical application was "developed" in Ruby and I did it on a Macbook which means that we have a couple of steps
to follow before being able to use it properly.

For the Ruby On Rails installation, please follow one of the guides below, they definitely explain better than me:
__Mac OS__
`https://gorails.com/setup/osx`
__Windows__
`https://gorails.com/setup/windows`
__Linux/Ubuntu__
`https://gorails.com/setup/ubuntu`

After Ruby On Rails was successfully installed, follow the next steps:
Step 1
Open terminal and go to the path where the application is located:
`$ cd <application path>`
Step 2
Type the following command in the terminal:
`$ gem install haversine`

Haversine is being used to calculate the distance between the coffee addict and the coffee shop (No worries, MIT Licence).

## How to run the application

Open terminal and type the following command:

`$ ruby coffeeShop.rb <user latitude> <user longitude> <coffee shop CSV file name>`

## How to run the tests of the application

Open terminal and type the following command:

`$ ruby runAllTests.rb`

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
