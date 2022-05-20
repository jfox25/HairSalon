# HairSalon System

By James Fox

An MVC application written in C# to help organize Stylists and their Clients. All data is stored on a SQL database.

## Technologies Used

- C#
- GIT
- DotNet MVC Architecture
- HTML
- CSS
- MySql
- Entity Framework Core

## Info

A site to help organize Vendors and their orders.

## Project Requirements

1. .Net 5 SDK
2. MySQL
3. MySQLWorkbench

## Project Setup

1. Clone this repository to your desktop using git clone

```
git clone https://github.com/jfox25/HairSalon
```

2. cd into Directive

```
cd HairSalon
```

3. cd into the Project

```
cd HairSalon
```

4. Run dotnet restore in the terminal

```
dotnet restore
```

### Setting up the Database

1. Go To Import Options from Data Import/Restore
2. Click Import from Self-Contained File
3. Navigate to the james_fox.sql file in the root of the project solution
4. Click Start Import
5. Create an appsettings.json in the HairSalon/HairSalon directive.
6. Configure the following code snippet for your database, then add it to your appsettings.json file

```

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database={DATABASE NAME};uid=root;pwd={PASSWORD};"
  }
}

```

### To Run the Project

1. Make sure you are in the HairSalon/HairSalon folder
2. Make sure you have your mySql server running
3. Start the project

```

dotnet run

```

4. Go to the localhost and you should be able to view the application

## GitHub Link

[Link to Code on GitHub](https://github.com/jfox25/HairSalon)

## Bugs

The revenue system is buggy, working on a fix.

## Future Improvements

- Plan to add Javascript to project & make appointment system better.

## License

MIT
Copyright (c) 2022 James Fox

```

```
