
namespace OldSpice.Services;

public class IngredientsService
{
  private IngredientsRepository _iRepo;

  public IngredientsService(IngredientsRepository ingredientsRepo)
  {
    _iRepo = ingredientsRepo;
  }
  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {

    return _iRepo.CreateIngredient(newIngredient);
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    return _iRepo.GetIngredientByRecipeId(recipeId);
  }


  internal Ingredient GetIngId(int ingredientId)
  {
    Ingredient foundIngredient = _iRepo.GetIngRep(ingredientId);
    if (foundIngredient == null)
    {
      throw new Exception("No Ingredient here");
    }
    return foundIngredient;
  }


  internal void DeleteIngredient(int ingredientId, string accountId)
  {
    Ingredient foundIngredient = GetIngId(ingredientId);
    if (foundIngredient == null)
    {
      throw new Exception("Ingredient is not availabe");
    }
    if (foundIngredient.CreatorId != accountId)
    {
      throw new Exception("Unathorized");
    }
    _iRepo.DeleteIngredient(foundIngredient);
  }



}