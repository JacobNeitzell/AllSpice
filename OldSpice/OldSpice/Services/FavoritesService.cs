namespace OldSpice.Services;


public class FavoritesService
{
  private readonly RecipesRepository _recRep;
  private readonly FavoritesRepository _fr;
  public FavoritesService(FavoritesRepository favoritesRepository, RecipesRepository recRep)
  {
    _recRep = recRep;
    _fr = favoritesRepository;
  }


  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    Favorite favoriteRecipe = _fr.GetFavoriteByAccountAndRecipe(newFavorite);
    if (favoriteRecipe != null)
    {
      throw new Exception("already your fav");
    }
    Favorite favorite = _fr.CreateFavorite(newFavorite);
    return favorite;
  }


  internal void RemoveFavorite(int favoriteId, string accountId)
  {
    Favorite foundFavorite = GetFavoriteById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("Invalid Id");
    }
    if (foundFavorite.AccountId != accountId)
    {
      throw new Exception("Unauthroized");
    }

    _fr.RemoveFavorite(foundFavorite);
  }

  internal Favorite GetFavoriteById(int favoriteId)
  {
    Favorite foundFavorite = _fr.GetFavoriteById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("Invalid Id");
    }
    if (foundFavorite.Id == 0)
    {
      throw new Exception("Invalid Id");
    }
    return foundFavorite;
  }







}