namespace OldSpice.Models;

public class Favorite : Account
{
  public new int Id { get; set; }
  public string AccountId { get; set; }
  public int RecipeId { get; set; }


}