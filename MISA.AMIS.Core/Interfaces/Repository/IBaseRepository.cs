using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Repository chung
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dqdat (12/06/2021)
    public interface IBaseRepository<T> where T: class
    {
        /// <summary>
        /// Lấy toàn bộ danh sách thực thể T
        /// </summary>
        /// <returns>Danh sách thực thể T</returns>
        /// CreatedBy: dqdat (12/06/2021)
        IEnumerable<T> GetAll();

        /// <summary>
        /// Lấy thông tin một thực thể T theo id.   
        /// </summary>
        /// <param name="id">id của thực thể cần lấy.</param>
        /// <returns>Thông tin thực thể T</returns>
        /// CreatedBy: dqdat (12/06/2021)
        T GetById(Guid id);

        /// <summary>
        /// Thêm mới một thực thể T.
        /// </summary>
        /// <param name="t">Thông tin thực thể T.</param>
        /// <returns>Số thực thể được thêm vào.</returns>
        /// CreatedBy: dqdat (12/06/2021)
        int Insert(T t);

        /// <summary>
        /// Cập nhật thông tin một thực thể.
        /// </summary>
        /// <param name="t">Thông tin thực thể cần cập nhật.</param>
        /// <returns>Số thực thể được cập nhật.</returns>
        /// CreatedBy: dqdat (12/06/2021)
        int Update(T t, Guid id);

        /// <summary>
        /// Xóa một thực thể T.
        /// </summary>
        /// <param name="id">id thực thể cần xóa.</param>
        /// <returns>Số thực thể bị xóa.</returns>
        /// CreatedBy: dqdat (12/06/2021)
        int Delete(Guid id);
    }
}
