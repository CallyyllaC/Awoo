using Awoo.Shared;
using System.Net.Http.Json;

namespace Awoo.Client.Services.TabletopSessionService
{
    public class TabletopSessionService : ITabletopSessionService
    {
        private List<TabletopSession> _sessions = new List<TabletopSession>();
        private readonly HttpClient _http;

        public TabletopSessionService(HttpClient http)
        {
            _http = http;
        }

        public List<TabletopSession> Sessions
        {
            get => _sessions;
            set => _sessions = value;
        }

        public async Task GetSessions()
        {
            var result = await _http.GetFromJsonAsync<List<TabletopSession>>("api/TabletopSession");

            if (result != null)
            {
                Sessions = result;
            }
        }
        public async Task<TabletopSession> GetSession(int id)
        {
            var result = await _http.GetFromJsonAsync<TabletopSession>($"api/TabletopSession/{id}");

            if (result != null)
            {
                return result;
            }

            throw new Exception("Session not found");
        }
    }
    public class TTRPGService : ITTRPGService
    {
        private List<TTRPG> _ttrpgs = new List<TTRPG>();
        private readonly HttpClient _http;

        public TTRPGService(HttpClient http)
        {
            _http = http;
        }

        public List<TTRPG> TTRPGs
        {
            get => _ttrpgs;
            set => _ttrpgs = value;
        }

        public async Task GetTTRPGs()
        {
            var result = await _http.GetFromJsonAsync<List<TTRPG>>("api/TabletopSession");

            if (result != null)
            {
                TTRPGs = result;
            }
        }
        public async Task<TTRPG> GetTTRPG(int id)
        {
            var result = await _http.GetFromJsonAsync<TTRPG>($"api/TabletopSession/{id}");

            if (result != null)
            {
                return result;
            }

            throw new Exception("Session not found");
        }
    }
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>();
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public List<User> Users
        {
            get => _users;
            set => _users = value;
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<User>>("api/TabletopSession");

            if (result != null)
            {
                Users = result;
            }
        }
        public async Task<User> GetUser(int id)
        {
            var result = await _http.GetFromJsonAsync<User>($"api/TabletopSession/{id}");

            if (result != null)
            {
                return result;
            }

            throw new Exception("Session not found");
        }
    }
}
