using BardeMoeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace BardeMoeBack.Logica
{
    public class logica
    {

        private readonly AplicationDBContext _context;


        public logica(AplicationDBContext context)
        {
            _context = context;
        }
        bool Rpt = false; 

        public logica()
        {
        }

            public bool buybeers(BuyBeers buybeer)
            {
                try
                {
                    var @Cuantity = buybeer.Cuantity;
                    var @BeerCode = buybeer.BeerCode;
                    _= _context.Database.ExecuteSqlRawAsync($@" EXEC BuyBeer
                                           {@BeerCode} ,{@Cuantity}");
                    return Rpt = true;
                }
                catch
                {
                    return Rpt;

                }

            }


            public async Task<bool> UserValidation(Users users)
            {
                try
                {
                    var @UserName = users.UserName;
                    var @Password = users.Password;
                    var @Email = users.Email;

                    var  verify =  await 
                    _context
                    .Database.ExecuteSqlRawAsync($@"EXEC VerifyUser
                       { @UserName}, { @Email}, { @Password}");

                    if (verify==1) { 
                     Rpt = true;
                    }
                Console.WriteLine(verify);
                Console.WriteLine(verify.GetType());
                return Rpt;
                }
                catch
                {
                    return Rpt;
                }
            }


        }
 }   
