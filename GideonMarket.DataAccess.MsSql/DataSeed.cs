using GideonMarket.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace GideonMarket.DataAccess.MsSql
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasData
                (
                    new Role(1, "admin")
                );

            //builder.Entity<User>()
            //    .HasData
            //    (
            //        new User("admin", "admin", 1)
            //    );
        }
    }
}
