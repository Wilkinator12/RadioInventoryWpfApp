# The Radio Inventory App

This is a WPF app that simulates an inventory of radios as they are used and labelled in the Vancouver Film Industry. It uses a SQL Server database to store the radio data.


## Current Features
- Add radios in bulk in the "Create New Radios" tab
- View existing radios in the "View Radios" tab


## Programming Concepts Used
- WPF (MVVM)
- SQL Server
- Dependency Injection
- 


## Before Building on Your Machine
- Publish the SQL Server database to your local server using the provided "RadioInventoryDB" project.
- Create your own "appsettings.json" file that follows the provided "appsettings.json.example" file and replace "YourConnectionStringHere" with the connection string to your newly publish, local SQL Server database.
