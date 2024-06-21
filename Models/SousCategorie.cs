using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace TP11Core.Models
{
    public class SousCategorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }
        public  Categorie? Categorie { get; set; }

        public List<Produit> Produits { get; set; } = new List<Produit>();

    }
}
