using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        IEmployeeReponsitory _employeeReponsitory;
       
        public EmployeesController(IEmployeeReponsitory employeeReponsitory)
        {
           
            _employeeReponsitory = employeeReponsitory;
        }
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                var employees = _employeeReponsitory.GetEmployees();
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

    }
}
