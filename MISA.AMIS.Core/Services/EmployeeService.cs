using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    /// <summary>
    /// Service nhân viên
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
        #region DECLARE
        /// <summary>
        /// Repository nhân viên
        /// </summary>
        private IEmployeeRepository _employeeRepository;
        #endregion

        #region CONSTRUCTOER
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="employeeRepository">Repository nhân viên</param>
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {

        }
        #endregion
    }
}
