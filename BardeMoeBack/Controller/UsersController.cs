using BardeMoeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BardeMoeBack.Logica;
using System.Reflection;

namespace BardeMoeBack.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly AplicationDBContext _context;



        public UsersController(AplicationDBContext context ) {
            _context = context;
           
        }


        /*  public async Task<ActionResult> UserValidation(Users users) {
              try {
                  bool lgRept;
                  lgRept =await LG.UserValidation(users);
                  if (lgRept)
                  {
                    return Ok(users);
                  }
                  return BadRequest("Fail in validation user chekout credentials");
              }
              catch(Exception ex) { 
                  return BadRequest(ex.Message);
              }
          }*/
        [HttpPost]
        public async Task<IActionResult> UserValidation(Users users)
        {
            try
            {
                var @UserName = users.UserName;
                var @Password = users.Password;
                var @Email = users.Email;
                
                var verify = _context.Users.FromSqlInterpolated($@" EXEC VerifyUser
                      {@UserName},{@Email},{@Password}");

                if(verify is null){
                    return Ok(verify);
                }
                else
                {
                    return BadRequest("Error in user validation");
                }

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
