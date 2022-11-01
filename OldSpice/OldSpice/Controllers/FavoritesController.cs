namespace OldSpice.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class FavoritesController : ControllerBase
{
  private readonly Auth0Provider _auth0provider;

  private readonly FavoritesService _fs;

  public FavoritesController(Auth0Provider auth0Provider, FavoritesService fs)
  {
    _auth0provider = auth0Provider;
    _fs = fs;
  }




}