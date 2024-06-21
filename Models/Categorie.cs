using System.ComponentModel.DataAnnotations.Schema;

namespace TP11Core.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<SousCategorie> SousCategories { get; set; }
        public IEnumerable<Produit> produit { get; set; }

        public Categorie() {

            produit = new HashSet<Produit>();

        }
    }
}