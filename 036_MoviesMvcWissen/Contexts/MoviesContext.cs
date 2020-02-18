using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using _036_MoviesMvcWissen.Entities;

namespace _036_MoviesMvcWissen.Contexts
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("MoviesContext")
        {
            // Disable initializer
            Database.SetInitializer<MoviesContext>(null);
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<MovieDirector> MovieDirectors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<vwUser> vwUsers { get; set; }

        public System.Data.Entity.DbSet<_036_MoviesMvcWissen.Models.Demos.Templates.PersonModel> People { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder) // bunu ignore et tablosunu oluşturma demek
        //{
        //    modelBuilder.Ignore<vwUser>();
        //}

        /* birden fazla context in varsa
         enable-migrations -ConntextTypeName _036_MoviesMvcWissen.Context.MovieContext
          add-migration -ConntextTypeName _036_MoviesMvcWissen.Migrations.Configuration
           update-database -SourceMigration _036_MoviesMvcWissen.Migrations.v3.12
         **/
    }
}



