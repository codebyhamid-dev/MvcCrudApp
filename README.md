MVC CRUD App – Category & Product

A simple ASP.NET Core MVC 8 app demonstrating CRUD operations for Category and Product tables with a one-to-many relationship. Uses Entity Framework Core and Bootstrap/Bootswatch for UI.

Features


Manage Categories and Products

One-to-Many: Each category can have multiple products

Responsive UI with Bootswatch theme

Server-side and client-side validation

Tech Stack


ASP.NET Core MVC 8

Entity Framework Core

SQL Server

Bootstrap 5 + Bootswatch


Database

Category: CategoryId (PK), Name, Description

Product: ProductId (PK), Name, Price, CategoryId (FK)
