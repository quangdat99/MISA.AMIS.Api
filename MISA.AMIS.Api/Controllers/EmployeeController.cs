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
    }
}
