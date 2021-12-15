using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MISA.Fresher.Core.Entities;
using MISA.Fresher.Core.Interface;
using MISA.Fresher.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Fresher.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;//khai báo biến nội bộ

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;//tiêm
        }
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                var employees = _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }
        [HttpGet("{EmployeeId}")]
        public IActionResult GetEmployeeById(Guid EmployeeId)
        {
            try
            {
                var emp = _employeeService.GetEmployeeById(EmployeeId);
                return Ok(emp);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }

        [HttpGet("EmployeeBycode/{EmployeeCode}")]
        public IActionResult GetEmployeeByCode(string EmployeeCode)
        {
            try
            {
                var emp = _employeeService.GetEmployeeByCode(EmployeeCode);
                return Ok(emp);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                var emp = _employeeService.InsertEmployee(employee);
                return Ok(emp);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }

        [HttpPut("{EmployeeId}")]
        public IActionResult UpdateEmployee(Employee employee,Guid EmployeeId)
        {
            try
            {
                var emp = _employeeService.UpdateEmployee(employee, EmployeeId);
                return Ok(emp);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }

        [HttpDelete("{EmployeeId}")]
        public IActionResult DeleteEmployee(Guid EmployeeId)
        {
            try
            {
                var emp = _employeeService.DeleteEmployee(EmployeeId);
                return Ok(emp);
            }
            catch (Exception ex)
            {

                var result = new
                {
                    devMsg = ex.Message,
                    useMsg = "có lỗi xảy ra,vui lòng liên hệ dev:Lê thanh Ngọc để được hỗ trợ",
                    data = DBNull.Value,
                    moreInfo = ""
                };
                return StatusCode(500, result);
            }
        }

    }
}
