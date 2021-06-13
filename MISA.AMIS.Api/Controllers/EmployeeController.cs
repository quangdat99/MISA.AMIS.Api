using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    /// <summary>
    /// Controller nhân viên
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    [Route("api/v1/[controller]s")]
    public class EmployeeController : BaseController<Employee>
    {
        #region DECLARE
        /// <summary>
        /// Service nhân viên
        /// </summary>
        IEmployeeService _employeeService;

        /// <summary>
        /// Repository nhân viên
        /// </summary>
        IEmployeeRepository _employeeRepository;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="employeeService">service nhân viên</param>
        /// <param name="employeeRepository">repository nhân viên</param>
        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository):base(employeeService, employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns>
        /// 200 - Có dữ liệu trả về.
        /// 500 - Lỗi server.
        /// </returns>
        /// CreatedBy: dqdat (13/06/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            return Ok(_employeeRepository.GetNewEmployeeCode());
        }

        /// <summary>
        /// Check mã nhân viên có trùng với nhân viên trên hệ thống.
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeId"></param>
        /// <returns>True - Đã tồn tại, false - Chưa tồn tại</returns>
        [HttpGet("CheckEmployeeCodeExist")]
        public IActionResult CheckEmployeeCodeExist(string employeeCode, Guid? employeeId)
        {
            return Ok(_employeeRepository.CheckEmployeeCodeExist(employeeCode, employeeId));
        }

        /// <summary>
        /// Lấy tổng số nhân viên và danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (13/06/2021)
        [HttpGet("EmployeeFilter")]
        public EmployeeFilter GetEmployeeFilter(string employeeFilter, string pageSize, string pageNumber)
        {
            return _employeeRepository.GetEmployeeFilter(employeeFilter, pageSize, pageNumber);
        }
        #endregion
    }
}
