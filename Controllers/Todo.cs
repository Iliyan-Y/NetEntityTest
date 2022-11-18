using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetEntity.Data;
using NetEntity.Models;

namespace NetEntity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Todo : Controller
{
  private readonly DataContext _context;

  public Todo(DataContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<ActionResult<List<Models.Todo>>> Get()
  {
    return Ok(await _context.Todos.ToListAsync());
  }

  [HttpPost]
  public async Task<ActionResult<CustomApiResponse>> AddTodo(Models.Todo todo)
  {
    _context.Todos.Add(todo);
    await _context.SaveChangesAsync();
    return Ok(new CustomApiResponse("Success", todo));
  }

  [HttpPatch]
  public async Task<ActionResult<Models.Todo>> UpdateTodo(Models.Todo todo)
  {
    var existingTodo = await _context.Todos.FindAsync(todo.Id);
    if (existingTodo == null) return BadRequest("Todo not found");
    existingTodo.Description = todo.Description;
    existingTodo.Done = todo.Done;
    existingTodo.Title = todo.Title;
    await _context.SaveChangesAsync();
    return Ok(existingTodo);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Models.Todo>> GetOne(int id)
  {
    var existingTodo = await _context.Todos.FindAsync(id);
    if (existingTodo == null) return BadRequest("Todo not found");
    return Ok(existingTodo);
  }


  [HttpDelete("{id:int}")]
  public async Task<ActionResult<CustomApiResponse>> DeleteOne(int id)
  {
    var existingTodo = await _context.Todos.FindAsync(id);
    if (existingTodo == null) return BadRequest("Todo not found");
    _context.Todos.Remove(existingTodo);
    await _context.SaveChangesAsync();
    return Ok(new CustomApiResponse($"Todo {existingTodo.Title} deleted"));
  }
}