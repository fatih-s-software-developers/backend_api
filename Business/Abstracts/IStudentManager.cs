using backend_api.Entities;

namespace backend_api.Business.Abstracts;

public interface IStudentManager
{
    void add(Student student);
    List<Student> getAll();
}
