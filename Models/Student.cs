namespace StudentDatabase.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }

    public override string ToString()
    {
        return $"{Id}: {LastName} {FirstName}, {Age} лет, группа {Group}";
    }
}