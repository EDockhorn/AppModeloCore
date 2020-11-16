using Dock.UI.Site.Models;
using Microsoft.EntityFrameworkCore;

namespace Dock.UI.Site.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
