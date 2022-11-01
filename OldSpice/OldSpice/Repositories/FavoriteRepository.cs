namespace OldSpice.Repositories;

public class FavoritesRepository : BaseRepository
{
  public FavoritesRepository(IDbConnection db) : base(db)
  {
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    string sql = @"
INSERT INTO favorites(recipeId,accountId)
VALUES(@RecipeId, @AccountId);
SELECT LAST_INSERT_ID()
;";
    int id = _db.ExecuteScalar<int>(sql, newFavorite);
    newFavorite.Id = id;
    return newFavorite;
  }


  internal Favorite GetFavoriteByAccountAndRecipe(Favorite newFavorite)
  {
    string sql = @"
SELECT * FROM favorites
WHERE recipdeId = @recipeId AND accountId = @accountId
;";
    return _db.Query<Favorite>(sql, newFavorite).FirstOrDefault();
  }





}