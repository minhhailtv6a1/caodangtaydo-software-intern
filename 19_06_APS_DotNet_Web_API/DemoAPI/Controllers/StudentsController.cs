using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly DemoWebApiContext _context;

    public StudentsController(DemoWebApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _context.Students.
            OrderBy(s => s.Id).
            Select(s => new { s.Id, s.Name, s.Age }).ToList();

        return Ok(students);
    }

    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        if (student == null || string.IsNullOrEmpty(student.Name) || student.Age <= 0)
        {
            return BadRequest("Invalid student data.");
        }

        _context.Students.Add(student);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        var student = _context.Students.Where(s => s.Id == id).FirstOrDefault();
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        if (id != student.Id || student == null || string.IsNullOrEmpty(student.Name) || student.Age <= 0)
        {
            return BadRequest("Invalid student data.");
        }

        var existingStudent = _context.Students.Find(id);
        if (existingStudent == null)
        {
            return NotFound();
        }

        existingStudent.Name = student.Name;
        existingStudent.Age = student.Age;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);
        _context.SaveChanges();

        return NoContent();
    }
}