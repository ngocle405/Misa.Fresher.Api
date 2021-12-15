using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Interface.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
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
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                var sql = $"DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
                DynamicParameters parameters = new DynamicParameters(); // Để tránh lỗi sql injection
                parameters.Add($"@EmployeeId", EmployeeId);
                var rowAffect = mySqlConnection.Execute(sql, param: parameters);
                return rowAffect;
            }
        }

        public Employee GetEmployeeByCode(string EmployeeCode)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                var res = mySqlConnection.QueryFirstOrDefault<Employee>("Proc_GetEmployeeByCode", new { EmployeeCode = EmployeeCode }, commandType: CommandType.StoredProcedure);
                return res;
            }

        }

        public Employee GetEmployeeById(Guid EmployeeId)
        {
            
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                ////thực thi lấy dữ liệu db
                var sql = $"SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
                DynamicParameters parameters = new DynamicParameters();//khơi tạo dynamic để tránh lỗi injection    
                parameters.Add($"@EmployeeId", EmployeeId);
                var customers = mySqlConnection.QueryFirstOrDefault<Employee>(sql, param: parameters);
                return customers;
            }
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

        public object Insert(Employee employee)
        {
           using(MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                var colums = "";
                var columsParams = "";

                DynamicParameters parameters = new DynamicParameters();//khơi tạo dynamic để tránh lỗi injection    
                 // Lấy ra các property của đối tượng:                                               
                var props = typeof(Employee).GetProperties();
                //lấy ra name của đối tượng
                var className = typeof(Employee).Name;

                //duyệt từng property
                foreach (var prop in props)
                {
                    // Lấy ra tên của property
                    var propName = prop.Name;
                    //lấy giá trị của property tương ứng đối tượng.
                    var propValue = prop.GetValue(employee);
                    //tạo ra mã khách hàng mới ngẫu nhiên
                    if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                    {
                        propValue = Guid.NewGuid();
                    }
                    //cập nhập chuỗi lệnh thêm mới và add tham số tương ứng.
                    colums += $"{propName},";
                    columsParams += $"@{propName},";
                    parameters.Add($"@{propName}", propValue);

                }
                //thực hiện trừ đi kí tự (,) ở cuối cùng.
                colums = colums.Substring(0, colums.Length - 1);
                columsParams = columsParams.Substring(0, columsParams.Length - 1);
                //

                var sql = $"INSERT INTO Employee ({colums}) VALUES ({columsParams})";
                // thực thi thêm
                var rowAffect = mySqlConnection.Execute(sql, param: parameters);
                return rowAffect;
            }
        }

        public object Update(Employee employee, Guid EmployeeId)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(_connectionStrings))
            {
                var colums = "";
                var columsParams = "";
                var sqlUpdate = "";
                DynamicParameters parameters = new DynamicParameters();//khơi tạo dynamic để tránh lỗi injection    
                // Lấy ra các property của đối tượng:                                               
                var props = typeof(Employee).GetProperties();
                //lấy ra name của đối tượng
                var className = typeof(Employee).Name;

                //duyệt từng property
                foreach (var prop in props)
                {
                    // Lấy ra tên của property
                    var propName = prop.Name;
                    //lấy giá trị của property tương ứng đối tượng.
                    var propValue = prop.GetValue(employee);
                    //đối chiếu mã khách hàng.
                    if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                    {
                        continue;
                    }
                    //cập nhập chuỗi lệnh thêm mới và add tham số tương ứng.

                    colums = $"{propName}";
                    columsParams = $"@{propName}";
                    parameters.Add($"@{propName}", propValue);
                    sqlUpdate += $"{colums} = {columsParams},";
                }
                //thực hiện trừ đi kí tự (,) ở cuối cùng.

                sqlUpdate = sqlUpdate.Substring(0, sqlUpdate.Length - 1);
                var sql = $"UPDATE Employee SET {sqlUpdate} WHERE EmployeeId = @EmployeeId";
                 parameters.Add($"@EmployeeId", EmployeeId);//lấy id
                // thực thi thêm
                var rowAffect = mySqlConnection.Execute(sql, param: parameters, commandType: System.Data.CommandType.Text);
                return rowAffect;
            }
        }
    }
}
