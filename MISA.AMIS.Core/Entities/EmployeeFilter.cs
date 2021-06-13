using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    /// <summary>
    /// Thông tin gồm tổng số nhân viên và danh sách nhân viên có lọc 
    /// </summary>
    /// CreatedBy: dqdat (13/06/2021)
    public class EmployeeFilter
    {
        /// <summary>
        /// Tổng số nhân viên
        /// </summary>
        public int? CountEmployees { get; set; }

        /// <summary>
        /// Danh sách nhân viên
        /// </summary>
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
