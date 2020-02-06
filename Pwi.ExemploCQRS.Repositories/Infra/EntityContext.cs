using Microsoft.EntityFrameworkCore;
using Pwi.ExemploCQRS.Repositories.Entities;

namespace Pwi.ExemploCQRS.Repositories.Infra
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<UsuarioEntity> UsuarioEntity { get; set; }
    }
}