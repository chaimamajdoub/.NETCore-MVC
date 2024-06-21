using System.ComponentModel.DataAnnotations.Schema;

namespace TP11Core.Models
{
    public class Produit
    {
        public int ProduitId { get; set; }

        public string ProduitName { get; set; }

        public string ProduitDescription { get; set; }

        public decimal ProduitPrice { get; set; }
        
        public IEnumerable<Categorie> categories { get; set; }

        public Produit()
        {
            categories = new HashSet<Categorie>();
        }
    }
}
