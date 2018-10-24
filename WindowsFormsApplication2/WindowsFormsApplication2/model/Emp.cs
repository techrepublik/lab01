using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication2.dat;

namespace WindowsFormsApplication2.model
{
    public class Emp : IEmployee
    {
        public string NationalIdNumber { get; set; }
        public string JobTitle { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public IEnumerable<Emp> GetEmployees()
        {
            using (var d = new AdventureWorks2014Entities())
            {
                var listPerson = from q0 in d.People
                    join q1 in d.Employees on q0.BusinessEntityID equals 
                        q1.BusinessEntityID
                    select new Emp
                    {
                        FirstName = q0.FirstName,
                        LastName = q0.LastName,
                        MiddleName = q0.MiddleName,
                        NationalIdNumber = q1.NationalIDNumber,
                        JobTitle = q1.JobTitle
                    };

                return listPerson.ToList();
            }
        } 
        
    }
}
