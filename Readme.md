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

__Example__

Using the [coffee_shops.csv](INeedCoffee/coffee_shops.csv)

`$ ruby coffeeShop.rb 45.7838552 24.1515281 coffee_shops.csv`

__Expected output__

```
Starbucks Sibiu Oituz, 0.4078
Starbucks Sibiu Piata Mare, 1.5017
Starbucks Cluj Iulius Mall, 117.1099
```

## How to run the tests of the application

Open terminal and type the following command:

`$ ruby runAllTests.rb`

