using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Task4.Models;
using System.Globalization;

namespace Task4.Controllers
    
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        string[] validFormats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "MM/dd/yyyy hh:mm tt", "yyyy-MM-dd HH:mm:ss, fff" };
        CultureInfo provider = new CultureInfo("en-US");
        [HttpGet]
        public IActionResult GetStudents()
        {
            using(var client = new SqlConnection("Data Source = db-mssql;Initial Catalog = s19183; Integrated Security = True"))
                using(var com = new SqlCommand())
                {
                com.Connection = client;
                com.CommandText = "select * from student";
                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = DateTime.ParseExact(dr["BirthDate"].ToString(), validFormats, provider)
                    st.Studies = dr["Studies.Name"].ToString();
                    return Ok(st);
                }
                return null;
            }
        }
        [HttpPost]
        public IActionResult CreateStudent()
        {
            var s = new Student();
            s.IdStudent = 1;
            s.FirstName = "Jan";
            s.LastName = "Kowalski";
            return Ok(s);
        }
        [HttpPut]
        public IActionResult PutStudent()
        {
            var s = new Student();
            s.IdStudent = 1;
            s.FirstName = "Jan";
            s.LastName = "Kowalski";
            return Ok(s);
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int i)
        {
            return Ok(i);
        }
    }
}