using Project.Models;
using Project.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project.Dal
{
    public class SqlRepository : IRepository
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void AddStudent(Student student)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.FirstName), student.FirstName);
            cmd.Parameters.AddWithValue(nameof(Student.LastName), student.LastName);
            cmd.Parameters.AddWithValue(nameof(Student.Age), student.Age);
            cmd.Parameters.AddWithValue(nameof(Student.Email), student.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Student.Picture), System.Data.SqlDbType.Binary, student.Picture!.Length)
                {
                    Value = student.Picture
                });
            var id = new SqlParameter(nameof(Student.IDStudent), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            student.IDStudent = (int)id.Value;
        }

        public void DeleteStudent(Student student)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Student.IDStudent), student.IDStudent);
            cmd.ExecuteNonQuery();
        }
        
        private Student ReadStudent(SqlDataReader dr)
        {
            List<Kolegij>? kolegiji = new List<Kolegij>();
            Kolegij? kolegij = GetKolegijZaStudent((int)dr[nameof(Student.IDStudent)]);
            if (kolegij != null)
            {
                kolegiji.Add(kolegij);
            }
            return new Student
            {
                IDStudent = (int)dr[nameof(Student.IDStudent)],
                FirstName = dr[nameof(Student.FirstName)].ToString(),
                LastName = dr[nameof(Student.LastName)].ToString(),
                Age = (int)dr[nameof(Student.Age)],
                Email = dr[nameof(Student.Email)].ToString(),
                Picture = ImageUtils.ByteArrayFromReader(dr, nameof(Student.Picture)),
                Kolegiji = kolegiji
            };
        }

        public IList<Kolegij> GetKolegiji()
        {
            IList<Kolegij> kolegiji = new List<Kolegij>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kolegiji.Add(ReadFullKolegij(dr));
            }

            return kolegiji;
        }

        public IList<Profesor> GetProfesors()
        {
            IList<Profesor> profesori = new List<Profesor>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                profesori.Add(ReadProfesor(dr));
            }

            return profesori;
        }

        private Kolegij ReadFullKolegij(SqlDataReader dr)
        {
            return new Kolegij
            {
                IDKolegij = (int)dr[nameof(Kolegij.IDKolegij)],
                Name = dr[nameof(Kolegij.Name)].ToString(),
                Profesor = GetProfesor((int)dr["ProfesorId"]),
                Studenti = GetStudentiZaKolegij((int)dr[nameof(Kolegij.IDKolegij)])
            };
        }

        public List<Student>GetStudentiZaKolegij(int idKolegij)
        {
            List<Student> studenti = new List<Student>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("idKolegij", idKolegij);

            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read() && dr.HasRows)
            {
                studenti.Add(ReadStudentName(dr));
            }

            return studenti;
        }

        private Student ReadStudentName(SqlDataReader dr)
        {
            return new Student
            {
                FirstName = dr[nameof(Student.FirstName)].ToString(),
                LastName = dr[nameof(Student.LastName)].ToString(),
            };
        }

        public Profesor GetProfesor(int idProfesor)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Profesor.IDProfesor), idProfesor);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadProfesor(dr);
            }


            throw new ArgumentException("Wrong id, no such student");
        }

        private Profesor ReadProfesor(SqlDataReader dr)
        {
            return new Profesor
            {
                IDProfesor = (int)dr[nameof(Profesor.IDProfesor)],
                FirstName = dr[nameof(Profesor.FirstName)].ToString(),
                LastName = dr[nameof(Profesor.LastName)].ToString(),
                Age = (int)dr[nameof(Profesor.Age)],
                Email = dr[nameof(Profesor.Email)].ToString(),
                Picture = ImageUtils.ByteArrayFromReader(dr, nameof(Profesor.Picture))
            };
        }

        public Kolegij? GetKolegijZaStudent(int idStudent)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "GetKolegijiZaStudent";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("idStudent", idStudent);

            using SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() && dr.HasRows)
            {
                return ReadKolegij(dr);
            }
            else
            {
                return null;
            }

            throw new ArgumentException("Wrong id, no such student");
        }

        public List<Kolegij> GetKolegijiZaStudent(int idStudent)
        {
            List<Kolegij> kolegiji = new List<Kolegij>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("idStudent", idStudent);

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kolegiji.Add(ReadKolegij(dr));
            }

            return kolegiji;
        }

        private Kolegij? ReadKolegij(SqlDataReader dr)
        {
            return new Kolegij
            {
                Name = dr[nameof(Kolegij.Name)].ToString()
            };
        }

        public Student GetStudent(int idStudent)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Student.IDStudent), idStudent);

            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadStudent(dr);
            }


            throw new ArgumentException("Wrong id, no such student");
        }

        public IList<Student> GetStudents()
        {
            IList<Student> list = new List<Student>();
            List<Kolegij> kolgiji = new List<Kolegij>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadStudent(dr));
            }

            return list;
        }

        public void UpdateStudent(Student person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Student.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Student.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Student.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Student.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture
                });

            cmd.Parameters.AddWithValue(nameof(Student.IDStudent), person.IDStudent);
            cmd.ExecuteNonQuery();
        }

        public void AddKolegij(Kolegij kolegij)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Kolegij.Name), kolegij.Name);
            cmd.Parameters.AddWithValue("idProfesor", kolegij.Profesor.IDProfesor);
            var id = new SqlParameter(nameof(Kolegij.IDKolegij), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            kolegij.IDKolegij = (int)id.Value;
        }

        public void DeleteKolegij(Kolegij kolegij)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Kolegij.IDKolegij), kolegij.IDKolegij);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStudentKolegij(int idKolegij, int idStudent)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "AddStudentKolegij";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Kolegij.IDKolegij), idKolegij);
            cmd.Parameters.AddWithValue(nameof(Student.IDStudent), idStudent);

            cmd.ExecuteNonQuery();
        }
    }
}
