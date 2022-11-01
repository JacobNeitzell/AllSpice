namespace OldSpice.Models;

public class FavoriteRecipe : Recipe
{
  public int FavoriteId { get; set; }
  public int RecipeId { get; set; }
  public string AccountId { get; set; }

}