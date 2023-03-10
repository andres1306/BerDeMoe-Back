using System.ComponentModel.DataAnnotations;

namespace BardeMoeBack.Models
{
    public class Utilities
    {
        [Key]public int UtilityID { get; set; }
        public string Message { get; set; }       
        public string text { get; set; }
    }
}
