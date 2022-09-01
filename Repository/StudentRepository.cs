using API_Revision.Data;
using API_Revision.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Revision.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<object> GetAllInfo(int Id)
        {
           

                var data = await (from student in _studentContext.Students_Info
                           join parents in _studentContext.Parents_Info
                           on student.Student_Id equals parents.Parents_Id
                           where student.Student_Id==Id
                           select new
                           {
                               Student_Age = student.Student_Age,
                               Student_Name = student.Student_Name,
                               address = parents.Parents_Address,
                               phoneNumber = parents.Parents_Phone,
                               ParentsName=parents.Parents_Name
                           }).FirstOrDefaultAsync();

                return data;
           
        }

        public async Task<List<StudentsModel>> GetStudentsInfo()
        {
            var students = await _studentContext.Students_Info.Select(x=> new StudentsModel()
            { 
              Student_Age=x.Student_Age,
              Student_Name=x.Student_Name,
              Student_Id=x.Student_Id
            }).ToListAsync();

            return students;
            
        }


        public async Task<StudentsModel> GetStudentById(int Id)
        {
            try
            {
                var data = await _studentContext.Students_Info.Where(x => x.Student_Id == Id).Select(y => new StudentsModel()
                {
                    Student_Age = y.Student_Age,
                    Student_Name = y.Student_Name
                }).FirstOrDefaultAsync();

                return data;
            }
            catch
            {
                //string error = "Instead of string you should pass int";
                //return error;
                throw new ApplicationException("Instead of string you should pass int");


            }

        }

        public async Task<Students_Info> AddStudent(StudentsModel student)
        {
            var data = new Students_Info()
            {
                Student_Age = student.Student_Age,
                Student_Name = student.Student_Name
            };

            _studentContext.Students_Info.Add(data);
            await _studentContext.SaveChangesAsync();
            return data;
        }

        public async Task<string> updateStudent(int Id, StudentsModel student)
        {
            var check = await _studentContext.Students_Info.FindAsync(Id);
            if (check != null)
            {

                var data = new Students_Info()
                {
                    Student_Age = student.Student_Age,
                    Student_Name = student.Student_Name,
                    Student_Id = Id

                };
                _studentContext.Students_Info.Update(data);
                await _studentContext.SaveChangesAsync();
                return "Success";
            }
            else
            {
                return "Check Your Id before updating: " + Id;
            }
            //var data = await _studentContext.Students_Info.Where(x => x.Student_Id == Id).FirstOrDefaultAsync();
            //if(data != null)
            //{
            //    data.Student_Age = student.Student_Age;
            //    data.Student_Name = student.Student_Name;
            //    data.Student_Id = Id;
            //    await _studentContext.SaveChangesAsync();
            //    return "Success";

            //}
            //else
            //{
            //    return "Check Your Id before updating: "+Id;
            //}




        }

        public async Task<string> DeleteRecord(int Id)
        {
            var data = await _studentContext.Students_Info.FindAsync(Id);

            if (data != null)
            {
                _studentContext.Students_Info.Remove(data);
                await _studentContext.SaveChangesAsync();
                return "The record has deleted successfully";
            }
            else
            {
                return "Check Your Id before deleting: " + Id;
            }
        }
    }
}
