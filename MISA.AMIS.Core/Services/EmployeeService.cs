using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using MISA.AMIS.Core.Properties;
using System;
using System.Collections;
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
        IEmployeeRepository _employeeRepository;
        #endregion

        #region CONSTRUCTOER
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="employeeRepository">Repository nhân viên</param>
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Phương thức dùng để cho valid của các trường hợp riêng biệt.
        /// </summary>
        /// <param name="t">Một thực thể</param>
        /// <param name="isInsert">Xác định insert hoặc update</param>
        /// CreatedBy: dqdat (13/06/2021)
        protected override bool ValidateCustom(Employee employee, bool isInsert = true)
        {
            bool isExist = false;
            var isValid = true;
            employee.EmployeeCode = employee.EmployeeCode.Trim();
            if (isInsert == true)
            {
                isExist = _employeeRepository.CheckEmployeeCodeExist(employee.EmployeeCode);
            }
            else
            {
                isExist = _employeeRepository.CheckEmployeeCodeExist(employee.EmployeeCode, employee.EmployeeId);
            }

            if (isExist == true)
            {
                isValid = false;
                IDictionary dictionary = new Dictionary<string, string>
                {
                    { "EmployeeCode", employee.EmployeeCode }
                };
                throw new ValidateException(string.Format(ValidateResources.MsgErrorEmployeeCodeExists, employee.EmployeeCode), dictionary);
                
            }
            return isValid;
        }
        #endregion
    }
}
