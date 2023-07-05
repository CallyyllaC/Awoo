using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Awoo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabletopSessionController : ControllerBase
    {
        public static List<TabletopSession> Sessions = new List<TabletopSession>();


        [HttpGet]
        public async Task<ActionResult<List<TabletopSession>>> GetSessions()
        {
            return Ok(Sessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TabletopSession>> GetSingleSession(int id)
        {
            var session = Sessions.FirstOrDefault(x => x.Id == id);

            if (session == null)
            {
                return NotFound("No game session found.");
            }
            return Ok(session);
        }

    }
}
