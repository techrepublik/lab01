using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2.model
{
    interface IEmployee
    {
        string NationalIdNumber { get; set; }
        string JobTitle { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }

        IEnumerable<Emp> GetEmployees();
    }
}
