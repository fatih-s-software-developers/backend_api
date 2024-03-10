using backend_api.Business.Abstracts;
using backend_api.Entities;
using backend_api.DataAccess.Abstracts;
namespace backend_api.Business.Concretes;

public class StudentManager : IStudentManager
{
    IStudentDal studentDal;

    public StudentManager(IStudentDal studentDal)
    {
        this.studentDal = studentDal;
    }

    public void add(Student student)
    {
        studentDal.add(student);
    }

    public List<Student> getAll()
    {
        return studentDal.getAll();
    }
}
