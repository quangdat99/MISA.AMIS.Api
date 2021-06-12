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
    /// Controller đơn vị nhân viên
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    [Route("api/v1/[controller]s")]
    public class EmployeeDepartmentController : BaseController<EmployeeDepartment>
    {
        #region DECLARE
        /// <summary>
        /// service đơn vị nhân viên
        /// </summary>
        IEmployeeDepartmentService _employeeDepartmentService;

        /// <summary>
        /// repository đơn vị nhân viên
        /// </summary>
        IEmployeeDepartmentRepository _employeeDepartmentRepository;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="employeeDepartmentService">service đơn vị nhân viên</param>
        /// <param name="employeeDepartmentRepository">repository đơn vị nhân viên</param>
        public EmployeeDepartmentController(IEmployeeDepartmentService employeeDepartmentService, IEmployeeDepartmentRepository employeeDepartmentRepository):base(employeeDepartmentService, employeeDepartmentRepository)
        {
            _employeeDepartmentService = employeeDepartmentService;
            _employeeDepartmentRepository = employeeDepartmentRepository;
        }
        #endregion
    }
}
