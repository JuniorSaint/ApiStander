using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private static string Host = "localhost";
    private static string User = "postgres";
    private static string DBname = "ApiStander";
    private static string Password = "m2166446JR";
    private static string Port = "5432";

    public ApplicationDbContext CreateDbContext(string[] args)   // Usado para criar as migrations
    {
        var connectionString = $"Server={Host}; Port={Port}; Database={DBname}; Uid={User}; Pwd={Password}";
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}