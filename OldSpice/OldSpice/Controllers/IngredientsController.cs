namespace OldSpice.Controllers;
[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;

  private readonly IngredientsService _is;

  public IngredientsController(Auth0Provider auth0Provider, IngredientsService @is)
  {
    _auth0provider = auth0Provider;
    _is = @is;
  }


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Ingredient>> CreateRecipe([FromBody] Ingredient newIngredient)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newIngredient.CreatorId = userInfo.Id;
      Ingredient createdIngredient = _is.CreateIngredient(newIngredient);
      createdIngredient.Creator = userInfo;
      return Ok(createdIngredient);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }



  [HttpDelete("{ingredientId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      _is.DeleteIngredient(ingredientId, userInfo.Id);
      return Ok("Ingredient Deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }






}