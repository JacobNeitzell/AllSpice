namespace OldSpice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _fr;
  public FavoritesService(FavoritesRepository favoritesRepository)
  {
    _fr = favoritesRepository;
  }


  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    Favorite favoriteRecipe = _favoritesRecipe.GetFavoriteByAccountAndRecipe(newFavorite);

  }


}