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
        /// <summary>
        /// CreateBy:Lê thanh Ngọc (16/12/2021)
        /// lấy tất cả thông tin
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees();

        /// <summary>
        /// CreateBy:Lê thanh Ngọc (16/12/2021)
        /// lấy nhân viên theo id
        /// </summary>
        /// <param name="EmployeeId">truyền đúng id</param>
        /// <returns></returns>
        public Employee GetEmployeeById(Guid EmployeeId);

        /// <summary>
        /// CreateBy:Lê thanh Ngọc (16/12/2021)
        /// thêm mới nhân viên
        /// </summary>
        /// <param name="employee">1 obj nhân viên</param>
        /// <returns></returns>
        public object InsertEmployee(Employee employee);
        /// <summary>
        /// CreateBy:Lê thanh Ngọc (16/12/2021)
        /// cập nhật nhân viên
        /// </summary>
        /// <param name="employee">1 obj nhân viên</param>
        /// <param name="EmployeeId">nhân viên id</param>
        /// <returns></returns>
        public object UpdateEmployee(Employee employee, Guid EmployeeId);

        /// <summary>
        /// CreateBy:Lê thanh Ngọc (16/12/2021)
        /// xóa nhân viên
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DeleteEmployee(Guid EmployeeId);

        /// <summary>
        /// CreateBy:Lê thanh Ngọc (16/12/2021)
        /// Lấy thông tin nhân viên theo mã code
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <returns></returns>
        public Employee GetEmployeeByCode(string EmployeeCode);

    }
}
