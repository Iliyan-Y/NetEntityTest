using Microsoft.AspNetCore.Mvc;
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

  [HttpPatch]
  public async Task<ActionResult<Models.Todo>> UpdateTodo(Models.Todo todo)
  {
    var existingTodo = todoList.Find(t => t.Id == todo.Id);
    if (existingTodo == null) return BadRequest("Todo not found");
    existingTodo.Description = todo.Description;
    existingTodo.Done = todo.Done;
    existingTodo.Title = todo.Title;

    return Ok(existingTodo);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Models.Todo>> GetOne(int id)
  {
    var existingTodo = todoList.Find(t => t.Id == id);
    if (existingTodo == null) return BadRequest("Todo not found");
    return Ok(existingTodo);
  }


  [HttpDelete("{id}")]
  public async Task<ActionResult<CustomApiResponse>> DeleteOne(int id)
  {
    var existingTodo = todoList.Find(t => t.Id == id);
    if (existingTodo == null) return BadRequest("Todo not found");
    return Ok(new CustomApiResponse($"Todo {existingTodo.Title} deleted"));
  }
}