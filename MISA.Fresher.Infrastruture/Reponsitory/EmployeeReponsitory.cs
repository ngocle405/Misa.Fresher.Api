using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Interface.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Infrastruture.Reponsitory
{
    public class EmployeeReponsitory : IEmployeeReponsitory
    {
        string _connectionStrings = string.Empty;
        public EmployeeReponsitory(IConfiguration configuration)
        {
            _connectionStrings = configuration.GetConnectionString("CukCuk");
        }
        public int Delete(Guid EmployeeId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            //khởi tạo chuỗi kết nối
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                ////thực thi lấy dữ liệu db
                var customers = mySqlConnection.Query<Employee>(sql: "SELECT * FROM Employee");
                return customers;
            }
        }

        public int Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee employee, Guid EmployeeId)
        {
            throw new NotImplementedException();
        }
    }
}
