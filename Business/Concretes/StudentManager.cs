using backend_api.Business.Abstracts;
using backend_api.Entities;
using backend_api.DataAccess.Abstracts;
using backend_api.Business.Dto.Requests;
using backend_api.Business.Dto.Responses;
using System.Collections.Generic;
namespace backend_api.Business.Concretes;

public class StudentManager : IStudentManager
{
    IStudentDal studentDal;

    public StudentManager(IStudentDal studentDal)
    {
        this.studentDal = studentDal;
    }

    public void add(AddStudentRequest student)
    {
        studentDal.add(new Student() {/*Id=8,*/ Name = student.Name,Surname = student.Surname,Email = student.Email});
    }

    public List<GetAllStudentResponse> getAll()
    {
        List <GetAllStudentResponse> GetAllStudentResponses = new List<GetAllStudentResponse>();
        foreach (Student item in studentDal.getAll())
        {
            GetAllStudentResponses.Add(new GetAllStudentResponse() { Id = item.Id, Name = item.Name,Surname = item.Surname, Email = item.Email});
        }
        return GetAllStudentResponses;
    }
}
