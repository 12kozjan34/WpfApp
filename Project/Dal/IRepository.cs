using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal
{
    public interface IRepository
    {
        void AddStudent(Student student);
        void UpdateStudent(Student person);
        void DeleteStudent(Student person);
        Student GetStudent(int idStudent);
        IList<Student> GetStudents();
        List<Student>GetStudentiZaKolegij(int idKolegij);

        List<Kolegij> GetKolegijiZaStudent(int idStudent);
        Kolegij? GetKolegijZaStudent(int idStudent);
        IList<Kolegij> GetKolegiji();
        void AddKolegij(Kolegij kolegij);
        void DeleteKolegij(Kolegij kolegij);

        Profesor GetProfesor(int idProfesor);
        IList<Profesor> GetProfesors();
        void UpdateStudentKolegij(int kolegijId, int studentId);
    }
}
