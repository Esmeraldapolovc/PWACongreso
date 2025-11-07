using AppCongreso.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCongreso.Data
{
    public class CongresoDBContext : DbContext
    {

        public CongresoDBContext() { }


        public CongresoDBContext(DbContextOptions<CongresoDBContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
