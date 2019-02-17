using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Crk.Dominio;



namespace Crk.Repositorio
{
    public class DatabaseContext: DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cd> Cds { get; set; }
        public DbSet<GeneroMusical> GeneroMusicais { get; set; }
        public DbSet<CdMusicas> CdMusicais { get; set; }




    }
}
