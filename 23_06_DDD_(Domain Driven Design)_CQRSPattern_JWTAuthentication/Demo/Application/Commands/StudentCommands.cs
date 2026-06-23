using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Application.Commands;

public class StudentCommands
{
    private readonly DemoWebApiContext _context;

    public StudentCommands(DemoWebApiContext context)
    {
        _context = context;
    }

    public void AddStudent(Student student)
    {
        _context.Set<Student>().Add(student);
        _context.SaveChanges();
    }

    public void UpdateStudent(Student student)
    {
        _context.Set<Student>().Update(student);
        _context.SaveChanges();
    }
    
    public void DeleteStudent(int id)
    {
        var student = _context.Set<Student>().Find(id);
        if (student != null)
        {
            _context.Set<Student>().Remove(student);
            _context.SaveChanges();
        }
    }
}