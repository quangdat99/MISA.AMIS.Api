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
    /// Repository nhân viên.
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {

        }
        #endregion
    }
}
