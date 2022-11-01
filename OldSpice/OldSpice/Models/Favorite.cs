using OldSpice.Interfaces;

namespace OldSpice.Models;

public class Favorite : IRepoItem<int>
{
  public int Id { get; set; }
  public string AccountId { get; set; }
  public int RecipeId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}