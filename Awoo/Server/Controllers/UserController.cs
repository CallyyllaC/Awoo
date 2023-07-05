using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace Awoo.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public static List<User> Users = new List<User>();
        
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return Ok(Users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetSingleUser(int id)
    {
        var session = Users.FirstOrDefault(x => x.Id == id);

        if (session == null)
        {
            return NotFound("No game session found.");
        }
        return Ok(session);
    }

}