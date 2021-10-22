using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        // get the connection string into constructor 
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options ): base(options)
        {

        }

        // specify Fluent API rules for your Entities 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(CongirueMove);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
        }

        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(m => new { m.UserId, m.RoleId });

            builder.HasOne(m => m.User).WithMany(m => m.RoleOfUser).HasForeignKey(m => m.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserOfRole).HasForeignKey(x => x.RoleId);
        }
        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(20);
        }

        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.TotalPrice).HasColumnType("decimal(3, 2)");
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FirstName).HasMaxLength(128);
            builder.Property(m => m.LastName).HasMaxLength(128);
            //dateofbirth
            builder.Property(m => m.Email).HasMaxLength(256);
            builder.Property(m => m.HashedPassword).HasMaxLength(1024);
            builder.Property(m => m.Salt).HasMaxLength(1024);
            builder.Property(m => m.PhoneNumber).HasMaxLength(16);
            
        }

        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(m => m.Id);
        }


        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(m => new { m.MovieId, m.UserId });
            builder.Property(m => m.Rating).HasColumnType("decimal(3, 2)");

            builder.HasOne(m => m.User).WithMany(m => m.ReviewsFromUser).HasForeignKey(m => m.UserId);
            builder.HasOne(x => x.Movie).WithMany(x => x.ReviewsForMovie).HasForeignKey(x => x.MovieId);
        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(64);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(128);
            builder.Property(m => m.ProfilePath).HasMaxLength(2084);

        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(m => new { m.MovieId, m.CastId, m.Character });
            builder.Property(m => m.Character).HasMaxLength(450);

            builder.HasOne(m => m.Movie).WithMany(m => m.CastForMovie).HasForeignKey(m => m.MovieId);
            builder.HasOne(x => x.Cast).WithMany(x => x.MovieForCast).HasForeignKey(x => x.CastId);
        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(m => new { m.MovieId, m.CrewId, m.Department, m.Job} ); // primary key 
            builder.Property(m =>  m.Department).HasMaxLength(128);
            builder.Property(m => m.Job).HasMaxLength(128);

            builder.HasOne(m => m.Movie).WithMany(m => m.CrewForMovie).HasForeignKey(m => m.MovieId);
            builder.HasOne(x => x.Crew).WithMany(x => x.MovieForCrew).HasForeignKey(x => x.CrewId);

        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(m => m.Id); // primary key 
            builder.Property(m => m.Name).HasMaxLength(128);
            builder.Property(m => m.ProfilePath).HasMaxLength(2084);
        }

        // the method as the Action
        // specify all the constraints and rules for Movie Entity/ Table
        private void CongirueMove(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id); // primary key 
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Budget).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18, 4)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");

            // we wannt tell EF to ignore Rating property and not create the columns
            builder.Ignore(m => m.Rating);
        }

        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId }); // anomnous type 
            builder.HasOne(m => m.Movie).WithMany(m => m.GenresForMovie).HasForeignKey(m => m.MovieId); // FK 
            builder.HasOne(g => g.Genre).WithMany(g => g.MoviesForGenre).HasForeignKey(g => g.GenreId); // FK 


        }



        // entity class are repesented as DbSets
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Role> Role { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Trailer> Trailers { get; set; } 
    }
}
