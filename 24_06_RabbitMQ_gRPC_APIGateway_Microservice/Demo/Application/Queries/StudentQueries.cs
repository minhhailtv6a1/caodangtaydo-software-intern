using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Queries;

public class StudentQueries
{
    private readonly DemoWebApiContext _context;

    public StudentQueries(DemoWebApiContext context)
    {
        _context = context;
    }

    public List<Student>? GetAllStudents()
    {
        return _context.Set<Student>()?.ToList();
    }

    public Student? GetStudentById(int id)
    {
        return _context.Set<Student>().Find(id);
    }
}