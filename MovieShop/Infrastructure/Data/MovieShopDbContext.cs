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
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<Favorite>(ConfigureFavorite);
            modelBuilder.Entity<Purchase>(ConfigurePurchase);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Role>(ConfigureRole);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
        }
        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256).IsRequired();
            builder.Property(m => m.Overview);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.Budget).HasColumnType("decimal(18,2)").HasDefaultValue(9.9m);
            builder.Property(m => m.Revenue).HasColumnType("decimal(18,2)").HasDefaultValue(9.9m);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.ReleaseDate).HasColumnType("datetime2").HasDefaultValueSql("getdate()");
            builder.Property(m => m.RunTime).HasColumnType("int").HasDefaultValue(0);
            builder.Property(m => m.Price).HasColumnType("decimal(5,2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasColumnType("datetime2").HasDefaultValueSql("getdate()");
            builder.Property(m => m.UpdatedDate).HasColumnType("datetime2").HasDefaultValueSql("getdate()");
            builder.Property(m => m.UpdatedBy);
            builder.Property(m => m.CreatedBy);
        }
        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
            builder.HasOne(m => m.Movie).WithMany(m => m.GenresOfMovie).HasForeignKey(m => m.MovieId);
            builder.HasOne(m => m.Genre).WithMany(m => m.MoviesOfGenre).HasForeignKey(m => m.GenreId);
        }
        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);
            builder.Property(t => t.Name).HasMaxLength(2084);
        }
        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.MovieId, mc.CastId, mc.Character });
            builder.Property(mc => mc.Character).HasMaxLength(450);
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.CastsOfMovie).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast).WithMany(mc => mc.MoviesOfCast).HasForeignKey(mc => mc.CastId);
        }
        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);

        }
        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new { mc.MovieId, mc.CrewId, mc.Department, mc.Job });
            builder.Property(mc => mc.Department).HasMaxLength(128);
            builder.Property(mc => mc.Job).HasMaxLength(128);
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.CrewsOfMovie).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Crew).WithMany(mc => mc.MoviesOfCrew).HasForeignKey(mc => mc.MovieId);
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.Name).HasMaxLength(128);
            builder.Property(cr => cr.Gender);
            builder.Property(cr => cr.TmdbUrl);
            builder.Property(cr => cr.ProfilePath).HasMaxLength(2084);
        }
        private void ConfigureFavorite(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.MovieId).IsRequired();
            builder.Property(r => r.UserId).IsRequired();
        }
        private void ConfigurePurchase(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.PurchaseNumber).IsRequired();
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18,2)").HasDefaultValue(9.9m).IsRequired();
            builder.Property(p => p.PurchaseDateTime).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.MovieId).IsRequired();


        }
        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new { r.MovieId, r.UserId });
            builder.Property(r => r.MovieId);
            builder.Property(r => r.UserId);
            builder.Property(r => r.Rating).HasColumnType("decimal(3,2)").HasDefaultValue(9.9m).IsRequired();
            builder.Property(r => r.ReviewText);


        }
        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.DateOfBirth).HasColumnType("datetime2");
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.TwoFactorEnabled);
            builder.Property(u => u.LockoutEndDate).HasColumnType("datetime2");
            builder.Property(u => u.LastLoginDateTime).HasColumnType("datetime2");
            builder.Property(u => u.IsLocked);
            builder.Property(u => u.AccessFailedCount);
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
        builder.ToTable("Role");
        builder.HasKey(ro => ro.Id);
        builder.Property(ro =>ro.Name).HasMaxLength(20);
        }
        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.HasOne(ur => ur.User).WithMany(ur => ur.RolesOfUser).HasForeignKey(ur => ur.UserId);
            builder.HasOne(ur => ur.Role).WithMany(ur => ur.UsersOfRole).HasForeignKey(ur =>ur.RoleId);
        }
    }
}
