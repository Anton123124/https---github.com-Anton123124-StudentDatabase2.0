using StudentDatabase.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentDatabase.Data;

public class StudentRepository
{
    private readonly StudentContext _context;

    public StudentRepository()
    {
        _context = new StudentContext();
        _context.Database.EnsureCreated();
    }

    // Добавление студента
    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    // Удаление студента по ID
    public void DeleteStudent(int id)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }

    // Поиск студентов по имени/фамилии
    public List<Student> FindStudents(string searchTerm)
    {
        return _context.Students
            .Where(s => s.FirstName.Contains(searchTerm) || s.LastName.Contains(searchTerm))
            .ToList();
    }

    // Получение всех студентов
    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    // Получение студента по ID
    public Student GetStudentById(int id)
    {
        return _context.Students.FirstOrDefault(s => s.Id == id);
    }

    // Обновление данных студента
    public void UpdateStudent(Student updatedStudent)
    {
        var student = _context.Students.FirstOrDefault(s => s.Id == updatedStudent.Id);
        if (student != null)
        {
            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Age = updatedStudent.Age;
            student.Group = updatedStudent.Group;
            _context.SaveChanges();
        }
    }
}