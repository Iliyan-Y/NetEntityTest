using Microsoft.AspNetCore.Mvc;

namespace NetEntity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Todo : Controller
{
  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var todos = new List<Models.Todo>
      { new() { Id = 0, Description = "test", Done = false, Title = "test title" } };
    return Ok(todos);
  }
}