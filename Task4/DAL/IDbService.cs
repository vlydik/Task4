using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task4.Models;

namespace Task4.DAL
{
    public interface IDbService 
    {
        public IEnumerable<Student> GetStudents();
    }
}
