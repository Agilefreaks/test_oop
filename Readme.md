## Overview

You have been hired by a company that builds a mobile app for coffee addicts.  You are 
responsible for taking the user’s location and returning a list of the three closest coffee shops.

## Coffee Addict 101

The application for the addicted ones has been created.

## How and what to install to run the application

In order to be able to run the application, you will need to install .NET Core:

`https://dotnet.microsoft.com/download`

## How to run the application

After .NET Core was successfully installed, follow the next steps:

__Step 1__

Open terminal and go to the path where the solution is located:

`$ cd <solution path>`

__Step 2__

Inside this folder, you can find another folder called INeedCoffee_ReadyToRun that contains the application's dll file:

`$ cd INeedCoffee_ReadyToRun`

__Step 3__

Open terminal and type the following command:

`$ dotnet INeedCoffee.dll <user latitude> <user longitude> <coffee shop CSV file name>`

__Example__

Using the [coffee_shops.csv](INeedCoffee_ReadyToRun/coffee_shops.csv)

`$ dotnet INeedCoffee.dll 45.7838552 24.1515281 coffee_shops.csv`

__Expected output__

```
Starbucks Sibiu Oituz, 0.408
Starbucks Sibiu Piata Mare, 1.5021
Starbucks Cluj Iulius Mall, 117.1429
```

## How to run tests for the application

Navigate to solution path and type the following command:

`$ dotnet test`

