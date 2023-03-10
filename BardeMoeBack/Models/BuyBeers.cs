using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace BardeMoeBack.Models
{
    public class BuyBeers
    {
        [Key]public int BeerCode { get; set; }   
        public string Cuantity { get; set; }
                    
    }
}
