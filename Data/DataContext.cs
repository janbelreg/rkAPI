using Microsoft.EntityFrameworkCore;
using rkprodAPIx.Model;
using System.Collections.Generic;

namespace rkprodAPIx.Data
{   //datovy context pre definovanie databazovej implementacie
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        //urcenie tabuliek pre implementaciu do databazy
        public DbSet<User> Users => Set<User>();
        public DbSet<Spis> Spisy => Set<Spis>();
        public DbSet<Zaznam> Zaznamy => Set<Zaznam>();

    }
}
