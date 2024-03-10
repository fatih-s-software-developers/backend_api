using backend_api.Entities;

namespace backend_api.DataAccess.Abstracts;

public interface IStudentDal
{
    void add(Student student);
    List<Student> getAll();


}
