namespace Awoo.Client.Services.TabletopSessionService;

public interface ITTRPGService
{
    List<TTRPG> TTRPGs { get; set; }
        
    Task GetTTRPGs();

    Task<TTRPG> GetTTRPG(int id);
}