using KeepScore.Models;
using Microsoft.AspNetCore.SignalR;

namespace KeepScore.Hubs;


public interface IScoreHub
{
    //public Task SendMessage(GamePreview game);
    Task GameAdded(BaseballModel game); //GameModel game
    Task GameDeleted(IEnumerable<BaseballModel> games);
    Task GameUpdated(BaseballModel game);
}
public class ScoreHub : Hub<IScoreHub>
{

}
