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
    /// Service đơn vị nhân viên
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    public class EmployeeDepartmentService: BaseService<EmployeeDepartment>, IEmployeeDepartmentService
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="employeeDepartmentRepository">Repository đơn vị nhân viên</param>
        public EmployeeDepartmentService(IEmployeeDepartmentRepository employeeDepartmentRepository):base(employeeDepartmentRepository)
        {

        }
        #endregion
    }
}
