namespace Awoo.Client.Services.TabletopSessionService;

public interface IUserService
{
    List<User> Users { get; set; }
        
    Task GetUsers();

    Task<User> GetUser(int id);
}