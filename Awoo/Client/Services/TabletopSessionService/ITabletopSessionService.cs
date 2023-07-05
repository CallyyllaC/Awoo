using System.Drawing;

namespace Awoo.Client.Services.TabletopSessionService
{
    public interface ITabletopSessionService
    {
        List<TabletopSession> Sessions { get; set; }
        
        Task GetSessions();

        Task<TabletopSession> GetSession(int id);
    }
}
