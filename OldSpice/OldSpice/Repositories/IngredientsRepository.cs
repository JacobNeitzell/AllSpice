namespace OldSpice.Repositories;

public class IngredientsRepository : BaseRepository
{

  public IngredientsRepository(IDbConnection db) : base(db)
  {

  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
    string sql = @"
INSERT INTO 
ingredients(name,quantity,creatorId,recipeId)
VALUES(@Name, @Quantity,@CreatorId,@RecipeId);
SELECT LAST_INSERT_ID()
;";
    int id = _db.ExecuteScalar<int>(sql, newIngredient);
    newIngredient.Id = id;
    return newIngredient;

  }

  internal List<Ingredient> GetIngredientByRecipeId(int recipeId)
  {
    string sql = @"
SELECT 
ing.*,
rec.*
FROM ingredients ing 
JOIN recipe rec ON rec.id = ing.recipeId
WHERE ing.recipeId = @recipeId
;";
    return _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
    {
      ingredient.Creator = profile;
      return ingredient;
    }, new { recipeId }).ToList();
  }


  internal Ingredient GetIngRep(int ingredientId)
  {
    string sql = @"
  SELECT 
  ing.*,
  a.*
  FROM ingredients ing
  JOIN accounts a ON a.id = ing.creatorId
  WHERE ing.id = @ingredientId
  ;";
    return _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile)
    =>
    {
      ingredient.Creator = profile;
      return ingredient;
    },
    new { ingredientId }).FirstOrDefault();
  }




  internal void DeleteIngredient(Ingredient foundIngredient)
  {
    string sql = @"
   DELETE 
   FROM ingredients
   WHERE id = @Id
   ;";
    int ingRow = _db.Execute(sql, foundIngredient);
    if (ingRow == 0)
    {
      throw new Exception("Unable to delete Ingredient");
    }
  }



}