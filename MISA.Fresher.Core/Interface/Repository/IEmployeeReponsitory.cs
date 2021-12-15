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
        /// <summary>
        /// createBy:Lê thanh Ngọc (15/12/2021)
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees();
        /// <summary>
        /// createBy:Lê thanh Ngọc (15/12/2021)
        /// lấy employee theo mã nhân viên
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns>1 thông tin khách hàng tương ứng</returns>
        public Employee GetEmployeeById(Guid EmployeeId);
        /// <summary>
        /// createBy:Lê thanh Ngọc (15/12/2021)
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">1 obj nhân viên</param>
        /// <returns></returns>
        public object Insert(Employee employee);

        /// <summary>
        /// createBy:Lê thanh Ngọc (15/12/2021)
        /// update nhân viên
        /// </summary>
        /// <param name="employee">1 obj nhân viên</param>
        /// <param name="EmployeeId">1 mã nhân viên</param>
        /// <returns></returns>
        public object Update(Employee employee,Guid EmployeeId);

        /// <summary>
        /// createBy:Lê thanh Ngọc (15/12/2021)
        /// xóa nhân viên
        /// </summary>
        /// <param name="EmployeeId">1 mã nhân viên</param>
        /// <returns>null</returns>
        public int Delete(Guid EmployeeId);


        /// <summary>
        /// createBy:Lê thanh Ngọc (15/12/2021)
        /// Lấy về nhân viên dựa vào mã code 
        /// </summary>
        /// <param name="EmployeeCode">mã code</param>
        /// <returns>Trả nhân viên nếu tìm thấy mã code</returns>
        public Employee GetEmployeeByCode(string EmployeeCode);
        

        
    }
}
