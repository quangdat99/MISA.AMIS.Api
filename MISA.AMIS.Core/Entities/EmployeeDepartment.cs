using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Entities
{
    /// <summary>
    /// Đơn vị của nhân viên
    /// CreatedBy: dqdat (12/06/2021)
    /// </summary>
    public class EmployeeDepartment
    {
        /// <summary>
        /// Id của đơn vị nhân viên
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Tên của đơn vị nhân viên
        /// </summary>
        public string EmployeeDepartmentName { get; set; }

        /// <summary>
        /// Mô tả đơn vị
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Trách nhiện đơn vị
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Quyền lợi đơn vị
        /// </summary>
        public string Profit { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
