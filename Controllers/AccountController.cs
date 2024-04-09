using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDBWebAPI.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MongoDBWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private IConfiguration _configuration;
        public AccountController(IAccountService accountService,IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        [HttpGet(Name="GetAllAccounts")]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var result = _accountService.GetAllAccounts();
                return Ok(result);

                //return NotFound(new HttpRequestException());
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        
    }
}
