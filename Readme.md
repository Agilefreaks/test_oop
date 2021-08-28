## Copyright notice

While the code itself is MIT licensed, the coding challenge itself, and its description,
included in this `Readme.md` file belongs to Agile Freaks et al.


## Coffee Place 

This is an attempt at solving the closest coffee shop coding challenge. 

All good software starts with making flawed assumptions.  

To make things easier on ourselves, we will assume that the Earth is flat.  
We all know this to be true - all of those satellite pictures are hoaxes!  

Furthermore, walking over the edge of the Earth teleports you to the opposing  
side - like in Snake, or other old school video games.

This only works for the "left-right" sides, as crossing the 180 meridian takes  
you to the other hemisphere. This does **not** work for the "up-down" sides,  
as we don't have a good way of teleporting from the North Pole to the South Pole yet.

```

                        ↑
                        Oy
   -180_______-90_______|________90_______180     ____  90 latitude
     |                  |                 |
     |                  |                 |
     |                  |                 |
     |------------------0-----------------|-Ox->  ----   0 latitude
     |                  |                 |
     |                  |                 |
     |                  |                 |
     |__________________|_________________|       ____ -90 latitude


```


This project will use the Ruby programming languge to implement the CLI application.

Let's do this!


## Coding challenge Overview

You have been hired by a company that builds a mobile app for coffee addicts.  You are 
responsible for taking the user’s location and returning a list of the three closest coffee shops.

## Input

The coffee shop list is a comma separated file with rows of the following form:
`Name,Y Coordinate,X Coordinate`

The quality of data in this list of coffee shops may vary.  Malformed entries should cause the 
program to exit appropriately. 

Your program will be executed directly from the command line and will be provided three 
arguments in the following order:
`<user x coordinate> <user y coordinate> <shop data url>`

Notice that the data file will be read from an network location (ex: https://raw.githubusercontent.com/Agilefreaks/test_oop/master/coffee_shops.csv)

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

