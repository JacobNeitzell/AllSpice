namespace OldSpice.Controllers;
[ApiController]
[Route("api/[controller]")]

public class RecipesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;
  private readonly RecipesService _rs;


  public RecipesController(Auth0Provider auth0Provider, RecipesService rs)
  {
    _auth0provider = auth0Provider;
    _rs = rs;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newRecipe.CreatorId = userInfo.Id;
      Recipe createdRecipe = _rs.CreateRecipe(newRecipe);
      createdRecipe.Creator = userInfo;
      return Ok(createdRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }


  }

  [HttpGet]
  public ActionResult<List<Recipe>> GetAllRecipe()
  {
    try
    {
      List<Recipe> recipes = _rs.GetAllRecipe();
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}")]
  [Authorize]

  public ActionResult<Recipe> GetById(int recipeId)
  {
    try
    {
      Recipe foundRecipe = _rs.GetById(recipeId);
      return Ok(foundRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPut("{recipeId}")]
  [Authorize]

  public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe recipeData, int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.Creator = userInfo;
      recipeData.CreatorId = userInfo.Id;
      recipeData.Id = recipeId;
      Recipe recipe = _rs.EditRecipe(recipeData, userInfo.Id);
      return Ok(recipe);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpDelete("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _rs.DeleteRecipe(recipeId, userInfo.Id);
      return Ok("Recipe was deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}