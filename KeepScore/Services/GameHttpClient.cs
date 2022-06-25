using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using KeepScore.Models;

namespace KeepScore.Services;

public class GameHttpClient
{
    private readonly HttpClient _httpClient;

    public GameHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BaseballModel[]> GetGames()
    {
        //Calls GameController GetGames() method
        return await _httpClient.GetFromJsonAsync<BaseballModel[]>("api/game");
    }

    public async Task<BaseballModel> GetGame(Guid gameId)
    {
        //Calls GameController GetGame(Guid Id) method
        return await _httpClient.GetFromJsonAsync<BaseballModel>($"api/game/{gameId}");
    }

    public async Task<HttpResponseMessage> AddGame(AddBaseballModel game)
    {
        //Calls GameController AddGame(AddGameModel game) method
        return await _httpClient.PostAsJsonAsync<AddBaseballModel>("api/game", game);
    }

    public async Task<HttpResponseMessage> DeleteGame(Guid Id)
    {
        //Calls GameController DeleteGame(Guid Id) method
        return await _httpClient.DeleteAsync($"api/game/{Id}");
    }

    public async Task<HttpResponseMessage> UpdateGame(BaseballModel game)
    {
        return await _httpClient.PutAsJsonAsync<BaseballModel>($"api/game/", game);
    }
}
