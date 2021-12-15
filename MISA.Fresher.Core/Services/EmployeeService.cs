using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Interface;
using MISA.Fresher.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeReponsitory _employeeReponsitory;
        public EmployeeService(IEmployeeReponsitory employeeReponsitory)
        {
            _employeeReponsitory = employeeReponsitory;//tiêm
        }
        public int DeleteEmployee(Guid EmployeeId)
        {
            var emp = _employeeReponsitory.Delete(EmployeeId);
            return emp;
        }

        public Employee GetEmployeeByCode(string EmployeeCode)
        {
            var emp = _employeeReponsitory.GetEmployeeByCode(EmployeeCode);
            return emp;
        }

        public Employee GetEmployeeById(Guid EmployeeId)
        {
            var emp = _employeeReponsitory.GetEmployeeById(EmployeeId);
            return emp;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var emp = _employeeReponsitory.GetEmployees();
            return emp;
        }

        public object InsertEmployee(Employee employee)
        {
            var employeeCode = employee.EmployeeCode;
            if (string.IsNullOrEmpty(employeeCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "mã khách hàng không để trống" },
                    useMsg = "mã khách hàng không được để trống",
                    Code = 999,
                };
                return msg;
            }
            // Check trùng mã
            var res = _employeeReponsitory.GetEmployeeByCode(employeeCode);
            if (res != null)
            {
                var msg = new
                {
                    devMsg = new
                    {
                        fieldName = "EmployeeCode",
                        msg = "Mã nhân viên đã tồn tại"
                    },
                    userMsg = "Mã nhân viên đã tồn tại",
                };
                return msg;
            }
          
            var addEmp = _employeeReponsitory.Insert(employee);
            return addEmp;
        }

        public object UpdateEmployee(Employee employee, Guid EmployeeId)
        {
            var employeId = _employeeReponsitory.GetEmployeeById(EmployeeId);
            //var employeeCode = employee.EmployeeCode;
            if (employeId == null)
            {
                var msg = new
                {
                    devMsg = new
                    {
                        fieldName = "EmployeeId",
                        msg = "Id nhân viên bạn tìm không tồn tại"
                    },
                    userMsg = "Id nhân viên bạn tìm không tồn tại",
                };
                return msg;
            }
          
            var emp = _employeeReponsitory.Update(employee, EmployeeId);
            return emp;
        }
    }
}
