using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace Awoo.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TTRPGController : ControllerBase
{
    public static List<TTRPG> TTRPGs = new List<TTRPG>();
        

    [HttpGet]
    public async Task<ActionResult<List<TTRPG>>> GetTTRPGs()
    {
        return Ok(TTRPGs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TTRPG>> GetSingleTTRPG(int id)
    {
        var session = TTRPGs.FirstOrDefault(x => x.Id == id);

        if (session == null)
        {
            return NotFound("No game session found.");
        }
        return Ok(session);
    }

}