﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TelegramAspMvcDotnetBotDb
{
    public class LibraryDesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<MainDbContext>
    {
        private const string  connectionString =
            @"Server=.\SQLEXPRESS;Database=telegrambot;
                Trusted_Connection=True;MultipleActiveResultSets=true";
        public MainDbContext CreateDbContext(params string[] args)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();
            
            builder.UseSqlServer(connectionString);
            return new MainDbContext(builder.Options);
        }
    }
}
