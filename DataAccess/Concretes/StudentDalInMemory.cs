using backend_api.DataAccess.Abstracts;
using backend_api.Entities;

namespace backend_api.DataAccess.Concretes;

public class StudentDalInMemory : IStudentDal
{
    List<Student> _students;
    public StudentDalInMemory()
    {
        _students = new List<Student>();
        _students.Add(new Student() { Id = 1,Name = "Fatih", Surname = "KILINÇ", Email = "fatih@test.com" });
        _students.Add(new Student() { Id = 2, Name = "Samet ", Surname = "TURAN", Email = "samet@test.com" });
        _students.Add(new Student() { Id = 3, Name = "Rümeysa ", Surname = "YILMAZ", Email = "rumeysa@test.com" });
        _students.Add(new Student() { Id = 4, Name = "Asiye ", Surname = "ARSLAN", Email = "asiye@test.com" });
    }

    public void add(Student student)
    {

        _students.Add(student);
    }

    public List<Student> getAll()
    {
        return _students;
    }
}
