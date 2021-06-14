using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        /// 
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>
        /// 200 - Có dữ liệu: True - Đã tồn tại, false - Chưa tồn tại     
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        [HttpGet("CheckEmployeeCodeExist")]
        public IActionResult CheckEmployeeCodeExist(string employeeCode, Guid? employeeId)
        {
            return Ok(_employeeRepository.CheckEmployeeCodeExist(employeeCode, employeeId));
        }

        /// <summary>
        /// Lấy tổng số nhân viên và danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter">filter tìm kiếm</param>
        /// <param name="pageSize">kích thước trang</param>
        /// <param name="pageNumber">chỉ số trang</param>
        /// <returns>        
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (13/06/2021)
        [HttpGet("EmployeeFilter")]
        public EmployeeFilter GetEmployeeFilter(string employeeFilter, string pageSize, string pageNumber)
        {
            return _employeeRepository.GetEmployeeFilter(employeeFilter, pageSize, pageNumber);
        }

        /// <summary>
        /// Export file excel danh sách nhân viên
        /// </summary>
        /// <returns>        
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (14/06/2021)
        [HttpGet("ExportExcel")]
        public IActionResult ExportExcel()
        {
            var stream = _employeeService.ExportExcel();
            string excelName = $"Danh-sach-nhan-vien {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}.xlsx"; 
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        #endregion
    }
}
