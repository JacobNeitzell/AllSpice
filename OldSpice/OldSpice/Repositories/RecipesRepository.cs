namespace OldSpice.Repositories;

public class RecipesRepository : BaseRepository
{
  public RecipesRepository(IDbConnection db) : base(db)
  {
  }


  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    string sql = @"
  INSERT INTO recipe(creatorId, title, img, category, instructions)
  VALUES(@CreatorId, @Title, @Img, @Category, @Instructions);
  SELECT LAST_INSERT_ID();";
    int recipeId = _db.ExecuteScalar<int>(sql, newRecipe);
    newRecipe.Id = recipeId;
    return newRecipe;
  }



  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT 
    rec.*, 
    a.* 
    FROM recipe rec
    JOIN accounts a on a.id = rec.creatorId
    ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }).ToList();
  }

  internal Recipe GetByRecipeId(int recipeId)
  {
    string sql = @"
SELECT 
rec.*,
a.*
FROM recipe rec
JOIN accounts a ON a.id = rec.creatorId
WHERE rec.id = @recipeId
;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
  }



  internal Recipe EditRecipe(Recipe recipeData)
  {
    string sql = @"
  UPDATE recipe SET
  instructions = @instructions
  WHERE id = @Id
  ;";
    int recipeRow = _db.Execute(sql, recipeData);
    if (recipeRow == 0)
    {
      throw new Exception("Unable to Change the Recipe");
    }
    return recipeData;
  }

  internal void DeleteRecipe(Recipe foundRecipe)
  {
    string sql = @"
  DELETE FROM recipe 
  WHERE 
  id = @Id 
  LIMIT 1
  ;";
    int recipeRow = _db.Execute(sql, foundRecipe);
    if (recipeRow == 0)
    {
      throw new Exception("Not Able to Delete");
    }
  }


}