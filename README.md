CalorieCore

A full-stack ASP.NET Core MVC web application that allows users to track meals, activities, and recipes while monitoring their daily calorie intake.

This application uses ASP.NET Core MVC, Entity Framework Core, and ASP.NET Identity for secure authentication and user management.

Features
Authentication \& Authorization

User registration and login using ASP.NET Identity

Secure password hashing

Profile completion flow after registration

Settings page with account deletion

Navigation protected with \[Authorize]

User Profile

Users complete profile after registration:

Age

Weight

Height

Gender

Goal

Automatic calorie calculation using custom CalorieCalculator

Daily calorie goal stored in database

Meals

Add, edit, delete meals

Track calories per meal

View all logged meals

Associate meals with logged-in user

&nbsp;Activities

Log activities

Track burned calories

User-specific activity history

Recipes

Create and manage recipes

View recipe details

“Cook \& Log” functionality (adds recipe calories to meals)

Recipe images support

Dashboard

Daily calorie goal progress bar

Visual calorie tracking

Clean card-based layout

Technologies Used

ASP.NET Core MVC

Entity Framework Core

SQL Server

ASP.NET Identity

Bootstrap 5

C#

Razor Views

Database Structure (Simplified)

AspNetUsers (Identity)

UserAccounts

Meals

Activities

Recipes

Each domain entity is linked to the logged-in user through UserAccount.

