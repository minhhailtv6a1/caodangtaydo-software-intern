using Demo.Application.Commands;
using Demo.Application.Queries;
using Demo.Models;

using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers;


[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentCommands? _studentCommands;
    private readonly StudentQueries? _studentQueries;

    public StudentController(StudentCommands? studentCommands, StudentQueries? studentQueries)
    {
        _studentCommands = studentCommands;
        _studentQueries = studentQueries;
    }

    [HttpGet]
    public IActionResult GetAllStudents()
    {
        var students = _studentQueries?.GetAllStudents();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        var student = _studentQueries?.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        _studentCommands?.AddStudent(student);
        return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }

        _studentCommands?.UpdateStudent(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        _studentCommands?.DeleteStudent(id);
        return NoContent();
    }
}
