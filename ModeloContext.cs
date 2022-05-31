using Microsoft.EntityFrameworkCore;
using ApiComMysql.Models;

public class ModeloContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ModeloContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = Configuration.GetConnectionString("ModeloConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Modelo> Modelo { get; set; }
}