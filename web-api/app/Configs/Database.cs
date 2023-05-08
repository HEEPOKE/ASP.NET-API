using Microsoft.EntityFrameworkCore;
using Npgsql;
using app.Models;

namespace app.Configs;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}