using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Service
{
    /// <summary>
    /// Interface service Nhân viên
    /// </summary>
    /// CreatedBy: dqdat (12/06/2021)
    public interface IEmployeeService: IBaseService<Employee>
    {
        /// <summary>
        /// Export file Excel danh sách nhân viên.
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/06/2021)
        public Stream ExportExcel();

    }
}
