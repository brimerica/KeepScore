using KeepScore.Models;
using Newtonsoft.Json;

namespace KeepScore.Data;

public interface IGameData
{
    IEnumerable<BaseballModel> GetGames();
    BaseballModel GetGame(Guid Id);
    void AddGame(BaseballModel newGame);
    void DeleteGame(Guid Id);
    void UpdateGame(BaseballModel updatedGame);
}

public class GameData : IGameData
{
    private IEnumerable<BaseballModel> games = new List<BaseballModel>();

        public IEnumerable<BaseballModel> GetGames()
        {
            string file = System.IO.File.ReadAllText("Data/games.json");
            games = JsonConvert.DeserializeObject<IEnumerable<BaseballModel>>(file);
            return games;
        }
        public BaseballModel GetGame(Guid Id)
        {
            string file = System.IO.File.ReadAllText("Data/games.json");
            games = JsonConvert.DeserializeObject<IEnumerable<BaseballModel>>(file);
            BaseballModel game = games.SingleOrDefault(t => t.Id == Id);
            return game;
        }

        public void AddGame(BaseballModel newGame)
        {
            string file = System.IO.File.ReadAllText("Data/games.json");
            var gameList = JsonConvert.DeserializeObject<List<BaseballModel>>(file) ?? new List<BaseballModel>();
            gameList.Add(newGame);
            string games = JsonConvert.SerializeObject(gameList);
            System.IO.File.WriteAllText("Data/games.json", games);
        }

        public void DeleteGame(Guid Id)
        {
            string file = System.IO.File.ReadAllText("Data/games.json");
            var gameList = JsonConvert.DeserializeObject<List<BaseballModel>>(file) ?? new List<BaseballModel>();
            BaseballModel xGame = gameList.FirstOrDefault(g => g.Id == Id);
            gameList.Remove(xGame);
            string games = JsonConvert.SerializeObject(gameList);
            System.IO.File.WriteAllText("Data/games.json", games);
        }

        public void UpdateGame(BaseballModel updatedGame)
        {
            string file = System.IO.File.ReadAllText("Data/games.json");
            var gameList = JsonConvert.DeserializeObject<List<BaseballModel>>(file) ?? new List<BaseballModel>();
            foreach (var game in gameList.Where(g => g.Id == updatedGame.Id))
            {
                //only scores...for now
                game.HomeTeamName = updatedGame.HomeTeamName;
                game.GuestTeamName = updatedGame.GuestTeamName;
                game.GameTitle = updatedGame.GameTitle;
                game.HomeTeamScore = updatedGame.HomeTeamScore;
                game.GuestTeamScore = updatedGame.GuestTeamScore;
                game.InningHalf = updatedGame.InningHalf;
                game.InningNum = updatedGame.InningNum;
                game.Outs = updatedGame.Outs;
                game.Strikes = updatedGame.Strikes;
                game.Balls = updatedGame.Balls;
            }
            string games = JsonConvert.SerializeObject(gameList);
            System.IO.File.WriteAllText("Data/games.json", games);
        }
}