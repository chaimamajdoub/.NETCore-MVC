using Microsoft.EntityFrameworkCore;

namespace TP11Core.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :  base(options)
        {
        }
        public DbSet<Categorie> categorie { get; set; }
        public DbSet<SousCategorie> souscategories { get; set; }
        public DbSet<Produit> Produits { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SousCategorie>()
                .HasOne(sc => sc.Categorie)
                .WithMany(c => c.SousCategories)
                .HasForeignKey(sc => sc.CategorieId);
        }

    }

}
