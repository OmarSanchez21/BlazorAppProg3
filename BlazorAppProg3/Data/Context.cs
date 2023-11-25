using BlazorAppProg3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppProg3.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { }
        public DbSet<PersonasModel> Personas { get; set; }
    }
}
