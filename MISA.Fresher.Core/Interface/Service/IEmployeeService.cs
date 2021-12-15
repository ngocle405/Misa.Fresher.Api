using MISA.Fresher.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interface
{
    public interface IEmployeeService
    {
        public int InsertEmployee(Employee employee);
        public int UpdateEmployee(Employee employee, Guid EmployeeId);
    }
}
