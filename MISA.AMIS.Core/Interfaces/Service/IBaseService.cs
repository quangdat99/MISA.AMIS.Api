using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Service
{
    /// <summary>
    /// Interface Service chung
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dqdat (12/06/2021)
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="t">Thông tin đối tượng thêm mới</param>
        /// <returns>Số bản ghi thêm mới được vào database</returns>
        /// CreatedBy: dqdat (12/06/2021)
        int? Insert(T t);


        /// <summary>
        /// Sửa 
        /// </summary>
        /// <param name="t">Thông tin đối tượng cần sửa</param>
        /// <param name="id">Id của đối tượng cần sửa</param>
        /// <returns>Số bản ghi thêm mới được vào database</returns>
        /// CreatedBy: dqdat (12/06/2021)
        int? Update(T t, Guid id);
    }
}
