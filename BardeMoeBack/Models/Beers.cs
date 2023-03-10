using System.ComponentModel.DataAnnotations;

namespace BardeMoeBack.Models
{
    public class Beers
    {
        [Key] public int BeerCode { get; set; }
        public string Name{ get; set; }
        public int Price{ get; set; }
        public int Quantity { get; set; }
        public string  Content { get; set; }
        public string LinkIMG { get; set; }     
    }
}

