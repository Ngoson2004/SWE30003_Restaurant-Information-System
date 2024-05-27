# SWE30003_Assignment3_Restaurant Information System with ASP.NET Core MVC</h1>
This website is built with ASP.NET Core v7.0. To see the demonstration, please watch this [video](https://www.youtube.com/watch?v=bMnRvEmOjUs)

## 1. Home page
![home](https://drive.google.com/uc?export=view&id=1ok_iTkZSI0OvRHaP8ZAyjOIsWwkmkXTr)

## 2. Menu page
![menu](https://drive.google.com/uc?export=view&id=1TortiwOgJ3s1APOHZaX6SfYtlG7SR313)

## 3. Feedback page
![feedback](https://drive.google.com/uc?export=view&id=19CfyEl8FIHob8gshAlcCNG7YtDz3FXZi)

## 4. Kitchen page
![kitchen](https://drive.google.com/uc?export=view&id=1jysqk55kjiaLKwPXuEd9wYZyu1_EA9rP)

## 5. Reservation page
![reserv](https://drive.google.com/uc?export=view&id=1d7_yVzqBwyHiuvi3QITSWIVDilKCXJGi)

## 6. How to run this system on your machine
- Make sure you have MySQL Workbench and Dotnet SDK on your machine. Otherwise download and install them on [Dotnet website ](https://dotnet.microsoft.com/en-us/download) and [MySQL website](https://www.mysql.com/products/workbench/)
- Create a connection on MySQL Workbench. Add your connection password to the connection string in [appsettings.json](appsettings.json). In [Program.cs](Program.cs), remove `var password` and password tail in `connectionString`
- Install Entity Framework tool using `dotnet tool install --global dotnet-ef`.Then run `dotnet ef database update`. Then the required database will be built on your database workbench
- Finally, run `dotnet build` and `dotnet run`
