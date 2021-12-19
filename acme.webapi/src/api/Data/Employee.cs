using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public string EmployeeNum { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? Terminated { get; set; }

        public virtual Person Person { get; set; }
    }
}
