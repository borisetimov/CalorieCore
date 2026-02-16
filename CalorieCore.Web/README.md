Project Overview

CalorieCore is a personal calorie tracker and recipe manager designed to help users log meals, track calorie intake, and maintain a collection of recipes. The application allows users to:

Add, edit, and delete personal recipes.

Browse global recipes provided by the system.

Log meals and activities for personal tracking.

View calorie information and difficulty levels for recipes.

The application is built using ASP.NET Core MVC, following SOLID principles, OOP best practices, and MVC architecture. It includes both server-side and client-side validation and uses responsive design through Bootstrap.

Features
Recipes

Create, edit, and delete personal recipes.

View global recipes (system-provided) with Edit/Delete buttons disabled.

Display recipe details: ingredients, instructions, calories, type, difficulty, and tags.

Search, filter, and sort recipes by calories, type, or difficulty.

Mark recipes as favorite.

Add recipe meals directly to daily logs.

Meals

Log meals with name, calories, and date.

Edit or delete logged meals.

View all meals in a tabular format, sorted by date.

Avoid repeated form submissions using proper POST-Redirect-GET pattern.

User Activities

Log physical activities with name, calories burned, and date.

Edit or delete activities.

View all logged activities for personal tracking.

Technologies Used

ASP.NET Core MVC (.NET 8) – Web application framework

Entity Framework Core – ORM for SQL Server database operations

SQL Server – Relational database

Bootstrap 5 – Responsive front-end styling

Razor Views – Layouts, partials, sections

Dependency Injection – For database context and services

Server & Client-side Validation – Data annotations & validation scripts

Git & GitHub – Version control with multiple commits and activity logs

Setup & Installation

Clone the repository

git clone https://github.com/<your-username>/CalorieCore.git


Open in Visual Studio 2022 (or higher)

Open the .sln file.

Install Dependencies

NuGet packages will restore automatically.

Ensure Entity Framework Core and SQL Server provider are installed.

Apply Migrations & Create Database

Update-Database


Run the Application

Start debugging (F5) or run without debugging (Ctrl + F5).

The application will launch on the default port (usually https://localhost:5001).

Environmental Variables

Connection string is defined in appsettings.json.

Example:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=CalorieCoreDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}

Project Architecture

Models: Recipe, Meal, UserActivity, UserAccount

Controllers: RecipesController, MealsController, UserActivitiesController

Views: Razor views with layouts and partials

Database: Entity Framework Core with SQL Server

Validation: Data annotations with client-side scripts

Entities & Relationships
Recipe

Id, Title, Ingredients, Instructions, Calories, Type, Difficulty, Tags, IsGlobal, IsFavorite

Global recipes cannot be edited/deleted by users

Meal

Id, Name, Calories, Date, UserAccountId

Linked to UserAccount (1-to-many)

UserActivity

Id, Name, CaloriesBurned, Date, UserAccountId

Linked to UserAccount (1-to-many)

UserAccount

Id, IdentityUserId, UserName

Linked to Meals and UserActivities

Controllers & Views

RecipesController

CRUD operations for personal recipes

View global recipes (read-only for users)

Search, filter, sort functionalities

MealsController

Create, Edit, Delete logged meals

Add meals from recipes

POST-Redirect-GET pattern prevents form resubmission errors

UserActivitiesController

Create, Delete activities

Only current user’s data is visible

Validation & Security

Server-side validation: Data annotations ensure required fields and proper ranges.

Client-side validation: Razor _ValidationScriptsPartial for real-time feedback.

Authorization: All controllers require authentication ([Authorize]).

Data isolation: Users can only view and modify their own meals and activities.

GitHub Repository & Commits

Minimum 10 commits across at least 3 different days.

Clear commit messages describing features and fixes.

Repository is public for evaluation.

Future Enhancements

Implement user roles for admin and standard users.

Add activity analytics dashboard (charts for calories burned and intake).

Allow recipe sharing and ratings.

Mobile-first UI optimization.

Integrate optional front-end framework (React or Blazor).

Notes

This project is fully original, built following the SoftUni ASP.NET Fundamentals requirements.
All CRUD operations, data validations, MVC architecture, responsive design, and user tracking features are implemented as specified