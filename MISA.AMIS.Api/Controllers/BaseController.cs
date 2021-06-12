using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dqdat (12/06/2021)
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        #region DECLARE
        /// <summary>
        /// Base service
        /// </summary>
        IBaseService<T> _baseService;

        /// <summary>
        /// Base Repository
        /// </summary>
        IBaseRepository<T> _baseRepository;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="baseService"></param>
        public BaseController(IBaseService<T> baseService, IBaseRepository<T> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy tất cả thực thể T
        /// </summary>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/06/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _baseRepository.GetAll();
            if (res.Any())
            {
                return Ok(res);
            }
            return NoContent();
        }

        /// <summary>
        /// Lấy thông tin thực thể t
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/06/2021)
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var res = _baseRepository.GetById(id);

            if (res == null)
            {
                return NoContent();
            }
            return Ok(res);
        }

        /// <summary>
        /// Insert một thực thể t
        /// </summary>
        /// <param name="t">Thông tin thực thể t</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/06/2021)
        [HttpPost]
        public IActionResult Insert(T t)
        {
            var rowsAffect = _baseService.Insert(t);
            if (rowsAffect > 0)
            {
                return StatusCode(201, rowsAffect);
            }
            return NoContent();
        }

        /// <summary>
        /// Update một thực thể t
        /// </summary>
        /// <param name="t">Thông tin thực thể t</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/06/2021)
        [HttpPut("{id}")]
        public IActionResult Update(T t, Guid id)
        {
            var rowsAffect = _baseService.Update(t, id);
            if (rowsAffect > 0)
            {
                return Ok(rowsAffect);
            }
            return NoContent();
        }

        /// <summary>
        /// Delete một thực thể t
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/06/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rowsAffect = _baseRepository.Delete(id);
            if (rowsAffect > 0)
            {
                return Ok(rowsAffect);
            }
            return NoContent();
        }
        #endregion
    }

}
