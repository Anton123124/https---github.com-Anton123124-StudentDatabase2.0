using StudentDatabase.Data;
using StudentDatabase.Models;
using System;

var repository = new StudentRepository();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ СТУДЕНТАМИ ===");
    Console.WriteLine("1. Добавить студента");
    Console.WriteLine("2. Просмотреть всех студентов");
    Console.WriteLine("3. Найти студента");
    Console.WriteLine("4. Редактировать студента");
    Console.WriteLine("5. Удалить студента");
    Console.WriteLine("6. Выход");
    Console.Write("Выберите действие: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddStudent(repository);
            break;
        case "2":
            ShowAllStudents(repository);
            break;
        case "3":
            FindStudent(repository);
            break;
        case "4":
            EditStudent(repository);
            break;
        case "5":
            DeleteStudent(repository);
            break;
        case "6":
            return;
        default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
    }
}

static void AddStudent(StudentRepository repository)
{
    Console.Clear();
    Console.WriteLine("=== ДОБАВЛЕНИЕ СТУДЕНТА ===");
    
    var student = new Student();
    
    Console.Write("Имя: ");
    student.FirstName = Console.ReadLine();
    
    Console.Write("Фамилия: ");
    student.LastName = Console.ReadLine();
    
    Console.Write("Возраст: ");
    student.Age = int.Parse(Console.ReadLine());
    
    Console.Write("Группа: ");
    student.Group = Console.ReadLine();
    
    repository.AddStudent(student);
    Console.WriteLine("Студент успешно добавлен!");
    Console.ReadKey();
}

static void ShowAllStudents(StudentRepository repository)
{
    Console.Clear();
    Console.WriteLine("=== СПИСОК ВСЕХ СТУДЕНТОВ ===");
    
    var students = repository.GetAllStudents();
    
    if (students.Count == 0)
    {
        Console.WriteLine("Студентов нет в базе данных.");
    }
    else
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
    
    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
    Console.ReadKey();
}

static void FindStudent(StudentRepository repository)
{
    Console.Clear();
    Console.WriteLine("=== ПОИСК СТУДЕНТА ===");
    Console.Write("Введите имя или фамилию: ");
    
    var searchTerm = Console.ReadLine();
    var students = repository.FindStudents(searchTerm);
    
    if (students.Count == 0)
    {
        Console.WriteLine("Студенты не найдены.");
    }
    else
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
    
    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
    Console.ReadKey();
}

static void EditStudent(StudentRepository repository)
{
    Console.Clear();
    Console.WriteLine("=== РЕДАКТИРОВАНИЕ СТУДЕНТА ===");
    Console.Write("Введите ID студента: ");
    
    var id = int.Parse(Console.ReadLine());
    var student = repository.GetStudentById(id);
    
    if (student == null)
    {
        Console.WriteLine("Студент не найден!");
        Console.ReadKey();
        return;
    }
    
    Console.WriteLine($"Редактирование: {student}");
    
    Console.Write("Новое имя (оставьте пустым, чтобы не менять): ");
    var firstName = Console.ReadLine();
    if (!string.IsNullOrEmpty(firstName)) student.FirstName = firstName;
    
    Console.Write("Новая фамилия: ");
    var lastName = Console.ReadLine();
    if (!string.IsNullOrEmpty(lastName)) student.LastName = lastName;
    
    Console.Write("Новый возраст: ");
    var ageInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(ageInput)) student.Age = int.Parse(ageInput);
    
    Console.Write("Новая группа: ");
    var group = Console.ReadLine();
    if (!string.IsNullOrEmpty(group)) student.Group = group;
    
    repository.UpdateStudent(student);
    Console.WriteLine("Данные студента обновлены!");
    Console.ReadKey();
}

static void DeleteStudent(StudentRepository repository)
{
    Console.Clear();
    Console.WriteLine("=== УДАЛЕНИЕ СТУДЕНТА ===");
    Console.Write("Введите ID студента: ");
    
    var id = int.Parse(Console.ReadLine());
    var student = repository.GetStudentById(id);
    
    if (student == null)
    {
        Console.WriteLine("Студент не найден!");
    }
    else
    {
        Console.WriteLine($"Вы уверены, что хотите удалить: {student}? (y/n)");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            repository.DeleteStudent(id);
            Console.WriteLine("\nСтудент удален!");
        }
    }
    
    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
    Console.ReadKey();
}