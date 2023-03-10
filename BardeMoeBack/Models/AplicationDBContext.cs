using Microsoft.EntityFrameworkCore;

namespace BardeMoeBack.Models
{
    public class AplicationDBContext : DbContext
    {
        public string CadenaSQl = string.Empty;
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Beers> Beers { get; set; }
        public DbSet<BuyBeers> BuyBeers { get; set; }
        public DbSet<ReportBuy> ReportBuy { get; set; } 
        public DbSet<Users> Users { get; set; }
        public DbSet<Utilities> Utilities { get; set; }


        public void Conexion() { 
            var Builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSQl = Builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string  GetCadenaSQL() {
            return CadenaSQl;
        }
   }
}
