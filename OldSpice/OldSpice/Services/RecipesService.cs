namespace OldSpice.Services;

public class RecipesService
{

  private readonly RecipesRepository _repo;


  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }


  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    return _repo.CreateRecipe(newRecipe);
  }

  internal List<Recipe> GetAllRecipe()
  {
    return _repo.GetAllRecipes();
  }

  internal Recipe GetById(int recipeId)
  {
    Recipe foundRecipe = _repo.GetByRecipeId(recipeId);
    if (foundRecipe == null)
    {
      throw new Exception("Recipe Does Not Exist");
    }
    return foundRecipe;
  }

  internal Recipe EditRecipe(Recipe recipeData, string accountId)
  {
    if (recipeData.CreatorId != accountId)
    {
      throw new Exception("Not Your Account");
    }
    Recipe FirstRec = GetById(recipeData.Id);
    FirstRec.Instructions = recipeData.Instructions ?? FirstRec.Instructions;
    Recipe recipe = _repo.EditRecipe(FirstRec);
    return recipe;
  }

  internal void DeleteRecipe(int recipeId, string accountId)
  {
    Recipe foundRecipe = _repo.GetByRecipeId(recipeId);
    if (foundRecipe.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to remove recipe");
    }
    _repo.DeleteRecipe(foundRecipe);
  }

}