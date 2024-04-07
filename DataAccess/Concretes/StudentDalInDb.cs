using backend_api.DataAccess.Abstracts;
using backend_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_api.DataAccess.Concretes;


// Data Base Classes


//DbContext Class

public class StudentDbContext:DbContext
{


    public DbSet<StudentDbModel> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        options.UseNpgsql(Configuration.GetConnectionString("PostgreDbConnection"));
    }
}


//DataBase Model Class
public class StudentDbModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public TeacherDbModel teacher { get; set; }

    public int teacherId { get; set; }
}

public class TeacherDbModel
{

    public StudentDbModel student { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Branch { get; set; }

}



//Data Acess Class
public class StudentDalInDb : IStudentDal
{

    private readonly StudentDbContext _studentDbContext;


    public StudentDalInDb()
    {
        _studentDbContext = new StudentDbContext();
    }

    public void add(Student student)
    {
        //StudentDbContext _studentDbContext = new StudentDbContext();
        //Error HERE
        _studentDbContext.Students.Add(new StudentDbModel() { Name = student.Name, Surname = student.Surname, Email = student.Email });
        _studentDbContext.SaveChanges();
    }


    public List<Student> getAll()
    {
        //StudentDbContext _studentDbContext = new StudentDbContext();
        List<StudentDbModel> studentDbModels = _studentDbContext.Students.ToList();
        List<Student> students = new List<Student>();
        foreach (StudentDbModel item in studentDbModels)
        {
            students.Add(new Student() { Id = item.Id,Name= item.Name,Surname = item.Surname,Email=item.Email});
        }
        return students;

    }
}
