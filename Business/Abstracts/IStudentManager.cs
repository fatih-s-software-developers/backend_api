using backend_api.Entities;
using backend_api.Business.Dto.Requests;
using backend_api.Business.Dto.Responses;

namespace backend_api.Business.Abstracts;

public interface IStudentManager
{
    void add(AddStudentRequest student);
    List<GetAllStudentResponse> getAll();
}
