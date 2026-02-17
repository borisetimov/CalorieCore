🍏 CalorieCore – Personal Calorie Tracker & Recipe Manager

Overview

CalorieCore is a web application designed to help you track your meals, monitor calories, and manage recipes easily. It's simple, interactive, and secure, giving users the ability to:
Log meals and calories
Track daily activity
Browse and manage recipes
Maintain a complete personal profile
Whether you're trying to eat healthier or just stay organized with your nutrition, CalorieCore keeps all your data in one place.

Features
🥗 Recipes
Create, edit, and delete your personal recipes
Browse global recipes shared by the system
View recipe details: ingredients, instructions, calories, type, difficulty, and tags
Mark recipes as favorite
Sort and filter recipes by calories, type, or difficulty
Cook & log meals directly from a recipe

🍽 Meals
Log meals with name, calories, and date
Edit or delete logged meals
View all meals in a table, sorted by most recent
Prevent repeated form submissions using POST-Redirect-GET pattern

🏃 Activities
Log your physical activities with calories burned
Edit or delete activities
View your personal activity history

🔒 Account & Profile
Custom registration and login pages
Complete profile with age, weight, height, gender, and goals
Only logged-in users can access personal data

Technologies Used
ASP.NET Core MVC – Web framework
Entity Framework Core – Database ORM
SQL Server – Relational database
Bootstrap 5 – Responsive UI
Razor Views – Templating engine
Server & client-side validation – Ensures safe, correct data
Authentication – Identity-based login

Setup & Installation
Clone the repository
git clone https://github.com/<your-username>/CalorieCore.git
Open the project in Visual Studio 2022 or higher.
Install dependencies
NuGet packages restore automatically.
Set up the database
Ensure DefaultConnection in appsettings.json points to your SQL Server instance.
Run EF Core migrations:
Update-Database
Run the app
Press F5 or Ctrl+F5 to start. The app will open in your default browser.

Architecture
Models: UserAccount, Recipe, Meal, UserActivity
Controllers: RecipesController, MealsController, UserActivitiesController, AccountController
Views: Razor pages with Bootstrap for responsive design
Database: SQL Server with EF Core migrations
Validtion & Security: Data annotations and identity-based authentication

How to Use
Register / Log In
Only logged-in users can log meals, activities, or create recipes.
Complete Profile
Fill in your age, weight, height, gender, and goals to unlock full app functionality.
Manage Recipes
Add personal recipes or browse global recipes.
Edit/Delete only your recipes; global recipes are read-only.
Log Meals & Activities
Log daily meals and activities.
Track calories and see your progress over time.

Database Structure
Table	Key Fields	Relationships
UserAccount	Id, IdentityUserId	Meals, Activities (1-to-many)
Recipe	Id, UserAccountId, IsGlobal	UserAccount (optional)
Meal	Id, UserAccountId	UserAccount (required)
UserActivity	Id, UserAccountId	UserAccount (required)
Validation & Security

Only authenticated users can access their data.
All forms use server-side and client-side validation.
Meals, activities, and recipes are linked to the currently logged-in user.
Global recipes cannot be modified or deleted by normal users.

Future Improvements
Add user roles for admin and standard users
Analytics dashboard for calories and activity trends
Better Views with more css/js 
Recipe sharing and rating system
Mobile-first responsive enhancements

Notes
This project is fully original, built following SoftUni ASP.NET Fundamentals requirements.
It demonstrates MVC architecture, CRUD operations, user authentication, and responsive front-end design.
