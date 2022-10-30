
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


}