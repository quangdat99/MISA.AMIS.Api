using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Repository Nhân viên
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    public interface IEmployeeRepository: IBaseRepository<Employee>
    {
        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <param name="employeeId">id nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: dqdat (13/06/2021)
        public bool CheckEmployeeCodeExist(string employeeCode, Guid? employeeId = null);

        /// <summary>
        /// Tạo mã nhân viên mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: dqdat (13/06/2021)
        public string GetNewEmployeeCode();

        /// <summary>
        /// Lấy tổng số nhân viên và danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (13/06/2021)
        public EmployeeFilter GetEmployeeFilter(string employeeFilter, string pageSize, string pageNumber);
    }
}
