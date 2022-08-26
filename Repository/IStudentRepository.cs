using API_Revision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Revision.Repository
{
    public interface IStudentRepository
    {
        Task<List<StudentsModel>> GetStudentsInfo();
        Task<StudentsModel> GetStudentById(int Id);
        Task<string> AddStudent(StudentsModel student);
        Task<string> updateStudent(int Id, StudentsModel student);
        Task<string> DeleteRecord(int Id);
        Task<object> GetAllInfo(int Id);
    }
}
