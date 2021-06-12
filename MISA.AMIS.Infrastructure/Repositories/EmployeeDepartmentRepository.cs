using Microsoft.Extensions.Configuration;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repositories
{
    /// <summary>
    /// Repository đơn vị nhân viên
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    public class EmployeeDepartmentRepository: BaseRepository<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        public EmployeeDepartmentRepository(IConfiguration configuration): base(configuration)
        {

        }
        #endregion
    }
}
