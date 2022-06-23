using System.ComponentModel.DataAnnotations;

namespace KeepScore.Models;

public class AddBaseballModel
{
    [Required]
    public string HomeTeamName { get; set; }
    [Required]
    public string GuestTeamName { get; set; }
    [Required]
    public string GameTitle { get; set; }
    [Required]
    public int FinalInning { get; set; }
}