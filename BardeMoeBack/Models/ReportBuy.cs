using System.ComponentModel.DataAnnotations;

namespace BardeMoeBack.Models
{
    public class ReportBuy
    {
        [Key] public int BeerCode { get; set; }
        public string Name { get; set; }
        public int TotalBuy { get; set; }
        public int TotalPrice { get; set; }
    }
}
