namespace NetEntity.Models;

public class Todo
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public bool Done { get; set; }

  // public Todo(int id = default, string title = null, string description = null, bool done = default)
  // {
  //    Id = id;
  //    Title = title ?? throw new ArgumentNullException(nameof(title));
  //    Description = description ?? throw new ArgumentNullException(nameof(description));
  //    Done = done;
  // }

  public Todo(int id, string title, string description = null, bool done = false)
  {
    Id = id;
    Title = title;
    Description = description;
    Done = done;
  }
}