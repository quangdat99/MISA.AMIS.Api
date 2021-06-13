using MISA.AMIS.Core.Attributes;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using MISA.AMIS.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    /// <summary>
    /// Base service
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dqdat (12/06/2021)
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region DECLARE
        /// <summary>
        /// Base repository
        /// </summary>
        IBaseRepository<T> _baseRepository;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="baseRepository"> Base repository</param>
        /// CreatedBy: dqdat (12/06/2021)
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Thêm mới một thực thể
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/06/2021)
        public int? Insert(T t)
        {
            // Validate dữ liệu:
            var isValid = ValidateObject(t);
            if (isValid == true)
            {
                return _baseRepository.Insert(t);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Cập nhật một thực thể
        /// </summary>
        /// <param name="t">thông tin đối tượng</param>
        /// <param name="id">id của đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/06/2021)
        public int? Update(T t, Guid id)
        {
            //t.EntityState = Enum.EntityState.Update;
            // Validate dữ liệu:
            var isValid = ValidateObject(t, false);
            if (isValid == true)
            {
                return _baseRepository.Update(t, id);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Phương thức valid dữ liệu
        /// </summary>
        /// <param name="t">Thông tin của thực thể.</param>
        /// CreatedBy: dqdat (12/06/2021)
        private bool ValidateObject(T t, bool isInsert = true)
        {
            var isValid = true;

            // Check các thông tin bắt buộc nhập:
            // - Kiểu tra các property có attribute là PropertyRequired
            // -- Lấy ra các property có attribute là PropertyRequired
            // -- Kiểm tra value

            // lấy ra tất cả các property của class.
            var properties = t.GetType().GetProperties();

            foreach (var prop in properties)
            {
                // Lấy kiểu.
                var propType = prop.PropertyType;

                // Lấy giá trị.
                var propValue = prop.GetValue(t);

                // Lấy tên.
                var propName = prop.Name;


                var propertyRequireds = prop.GetCustomAttributes(typeof(PropertyRequired), true);


                // Check các thông tin không được phép trống:
                if (propertyRequireds.Length > 0)
                {
                    var propertyRequired = propertyRequireds[0] as PropertyRequired;
                    if (propType == typeof(string) && propValue == null || propValue.ToString() == string.Empty)
                    {
                        isValid = false;
                        throw new ValidateException(string.Format(ValidateResources.NotEmpty, propertyRequired._msgError), null);
                    }
                }


            }


            // Validate đặc thù cho từng đối tượng:
            if (isValid == true)
            {
                isValid = ValidateCustom(t,isInsert);
            }
            return isValid;
        }

        /// <summary>
        /// Phương thức dùng để cho valid của các trường hợp riêng biệt.
        /// </summary>
        /// <param name="t">Một thực thể</param>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/06/2021)
        protected virtual bool ValidateCustom(T t, bool isInsert)
        {
            return true;
        }

        #endregion
    }
}
