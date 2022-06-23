namespace KeepScore.Models;

public class BaseballModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string GameTitle { get; set; }
    public string HomeTeamName { get; set; }
    public string GuestTeamName { get; set; }
    public int HomeTeamScore { get; set; }
    public int GuestTeamScore { get; set; }
    public int InningNum { get; set; }
    public string InningHalf { get; set; }
    public int Outs { get; set; }
    public int Strikes { get; set; }
    public int Balls { get; set; }
    public string Status { get; set; }
}