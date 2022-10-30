using OldSpice.Interfaces;

namespace OldSpice.Models;

public class Recipe : ICreated, IRepoItem<int>
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public string title { get; set; }
  public Profile Creator { get; set; }
  public DateTime CreatedAt { get; set; }

  public DateTime UpdatedAt { get; set; }

  public string Img { get; set; }
  public string Category { get; set; }
  public string Instructions { get; set; }


}