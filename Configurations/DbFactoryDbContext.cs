using DIO.Cursos.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DIO.Cursos.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        private readonly IConfiguration _configuration;

        public DbFactoryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CursoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnections"));
            CursoDbContext context = new CursoDbContext(optionsBuilder.Options);
            return context;
        }
    }
}
