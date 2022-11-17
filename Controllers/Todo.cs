using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetEntity.Models;

namespace NetEntity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Todo : Controller
{
  private static List<Models.Todo> todoList = new();

  [HttpGet]
  public async Task<ActionResult<List<Models.Todo>>> Get()
  {
    return Ok(todoList);
  }

  [HttpPost]
  public async Task<ActionResult<CustomApiResponse>> AddTodo(Models.Todo todo)
  {
    todoList.Add(todo);
    return Ok(new CustomApiResponse("Success", todo));
  }
}