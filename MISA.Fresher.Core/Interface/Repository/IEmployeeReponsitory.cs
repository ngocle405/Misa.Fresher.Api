using MISA.Fresher.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Interface.Repository
{
    public interface IEmployeeReponsitory
    {
        public IEnumerable<Employee> GetEmployees();
        public Employee GetEmployeeById();
        public int Insert(Employee employee);
        public int Update(Employee employee,Guid EmployeeId);
        public int Delete( Guid EmployeeId);
    }
}
