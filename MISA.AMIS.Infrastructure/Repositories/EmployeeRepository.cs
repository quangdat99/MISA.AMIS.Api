using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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
        #region Declare
        DynamicParameters Parameters;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {
            Parameters = new DynamicParameters();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <param name="employeeId">id nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: dqdat (13/06/2021)
        public bool CheckEmployeeCodeExist(string employeeCode, Guid? employeeId = null)
        {

            Parameters.Add("@m_EmployeeCode", employeeCode);
            Parameters.Add("@m_EmployeeId", employeeId);
            var isExist = DbConnection.ExecuteScalar<bool>("Proc_CheckEmployeeCodeExist", param: Parameters, commandType: CommandType.StoredProcedure);
            return isExist;
        }

        /// <summary>
        /// Lấy tổng số nhân viên và danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (13/06/2021)
        public EmployeeFilter GetEmployeeFilter(string employeeFilter, string pageSize, string pageNumber)
        {
            if (employeeFilter == null)
            {
                employeeFilter = "";
            }

            var paramCountEmployees = new
            {
                m_Filter = employeeFilter
            };

            // Tổng nhân viên có lọc
            int? countEmployees = DbConnection.QueryFirstOrDefault<int>("Proc_GetCountEmployees", paramCountEmployees, commandType: CommandType.StoredProcedure);

            var paramEmployees = new
            {
                m_PageIndex = pageNumber,
                m_PageSize = pageSize,
                m_Filter = employeeFilter
            };

            // Danh sách nhân viên có lọc
            var employees = DbConnection.Query<Employee>("Proc_EmployeeFilter", param: paramEmployees, commandType: CommandType.StoredProcedure);

            var res = new EmployeeFilter();
            res.CountEmployees = countEmployees;
            res.Employees = employees as List<Employee>;
            return res;
        }

        /// <summary>
        /// Tạo mã nhân viên mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: dqdat (13/06/2021)
        public string GetNewEmployeeCode()
        {

            // Lấy mã nhân viên lớn nhất trên db.
            string? maxEmployeeCode = DbConnection.QueryFirstOrDefault<string>("Proc_GetEmployeeCodeMax", commandType: CommandType.StoredProcedure);

            if (maxEmployeeCode == null)
            {
                return "NV-00001";
            }

            string employeeCodeNumStr = string.Empty;

            for (var i = 0; i < maxEmployeeCode.Length; i++)
            {
                if (char.IsDigit(maxEmployeeCode[i]))
                {
                    employeeCodeNumStr += maxEmployeeCode[i];
                }
            }

            int employeeCodeNum = int.Parse(employeeCodeNumStr);
            employeeCodeNum++;

            return "NV-" + employeeCodeNum;
        }

        #endregion
    }
}
