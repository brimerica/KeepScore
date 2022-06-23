using KeepScore.Data;
using KeepScore.Hubs;
using KeepScore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace KeepScore.Controllers;

public class GameController
{
    private readonly IHubContext<ScoreHub, IScoreHub> _hubContext;
        private readonly IGameData _gameData;

        //private IEnumerable<GameModel> games = new List<GameModel>();

        public GameController(IHubContext<ScoreHub, IScoreHub> hubContext, IGameData gameData)
        {
            _hubContext = hubContext;
            _gameData = gameData;
        }

        [HttpGet]
        public IEnumerable<BaseballModel> GetGames()
        {
            //Calls data access class method GetGames()
            return _gameData.GetGames();
        }


        [HttpPost]
        public async void AddGame(AddBaseballModel newGame)
        {
            BaseballModel game = new BaseballModel
            {
                HomeTeamName = newGame.HomeTeamName,
                GuestTeamName = newGame.GuestTeamName,
                GameTitle = newGame.GameTitle,
                HomeTeamScore = 0,
                GuestTeamScore = 0,
                InningNum = 1,
                InningHalf = "Top",
                Outs = 0,
                Strikes = 0,
                Balls = 0,
                Status = "In Progress"
            };
            //Calls data access class method AddGame(AddGameModel game)
            _gameData.AddGame(game);
            //Calls connection Hub to notify clients of the update
            await _hubContext.Clients.All.GameAdded(game);
        }

        [HttpDelete("{id}")]
        public async void DeleteGame(Guid Id)
        {
            //Calls data access class method DeleteGame(Guid Id)
            _gameData.DeleteGame(Id);
            IEnumerable<BaseballModel> games = _gameData.GetGames();
            //Calls connection Hub to notify clients of the update
            await _hubContext.Clients.All.GameDeleted(games);
        }

        [HttpGet("{id}")]
        public BaseballModel GetGame(Guid Id)
        {
            //Calls data access class method GetGame(Guid Id)
            return _gameData.GetGame(Id);
        }

        [HttpPut]
        public async void UpdateGame(BaseballModel game)
        {
            //GameModel game;
            _gameData.UpdateGame(game);
            BaseballModel updatedGame = _gameData.GetGame(game.Id);
            await _hubContext.Clients.All.GameUpdated(updatedGame);
        }
}