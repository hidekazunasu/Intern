using ToDoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controller;
[ApiController]
[Route("api/todolist")]
public class ToDoController : ControllerBase
{
    private static readonly List<ToDo> ToDoList = new();
    private static int nextId = 1;

    [HttpGet]
    public IActionResult GetToDoList()
    {
        return Ok(ToDoList);
    }

    [HttpPost]
    public IActionResult AddToDoItem([FromBody] ToDo item)
    {
        if (string.IsNullOrWhiteSpace(item.Name))
        {
            return BadRequest("Item name cannot be empty");
        }
        item.Id = nextId++;
        ToDoList.Add(item);
        return Created("api/todolist", item);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateToDoItem(int id, [FromBody] ToDo updatedItem)
    {
        var item = ToDoList.FirstOrDefault(t => t.Id == id);
        if (item == null)
        {
            return NotFound("Item not found");
        }
        item.Name = updatedItem.Name;
        item.IsCompleted = updatedItem.IsCompleted;
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteToDoItem(int id)
    {
        var item = ToDoList.FirstOrDefault(t => t.Id == id);
        if (item == null)
        {
            return NotFound("Item not found");
        }
        ToDoList.Remove(item);
        return Ok(item);
    }
}
