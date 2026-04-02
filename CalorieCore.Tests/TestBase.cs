using CalorieCore.Data;
using CalorieCore.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalorieCore.Tests.Services
{
    public abstract class TestBase
    {
        protected ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationDbContext(options);


            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
    }
}