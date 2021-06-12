using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AMIS.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Infrastructure.Repositories
{
    /// <summary>
    /// Repository chung 
    /// </summary>
    /// <typeparam name="T">Một đối tượng </typeparam>
    /// CreatedBy: dqdat (12/06/2021)
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region DECLARE
        /// <summary>
        /// truy vấn DB
        /// </summary>
        public DbConnection DbConnection { get => new MySqlConnection(_connectionString); }

        /// <summary>
        /// Chuỗi thông tin kết nối
        /// </summary>
        string _connectionString;
        /// <summary>
        /// Config của project
        /// </summary>
        IConfiguration _configuration;

        /// <summary>
        /// Parameters
        /// </summary>
        DynamicParameters Parameters;

        /// <summary>
        /// Tên của lớp
        /// </summary>
        string _className;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            Parameters = new DynamicParameters();
            _className = typeof(T).Name;
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy toàn bộ danh sách đối tượng T
        /// </summary>
        /// <returns>Danh sách đối tượng T</returns>
        /// CreatedBy: dqdat (12/06/2021)
        public IEnumerable<T> GetAll()
        {
            var entities = DbConnection.Query<T>($"Proc_Get{_className}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Lấy thông tin một đối tượng T theo id.   
        /// </summary>
        /// <param name="id">id của đối tượng cần lấy.</param>
        /// <returns>Thông tin đối tượng T</returns>
        /// CreatedBy: dqdat (12/06/2021)
        public T GetById(Guid id)
        {
            Parameters.Add($"@m_{_className}Id", id);
            var entity = DbConnection.QueryFirstOrDefault<T>($"Proc_Get{_className}ById", param: Parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Thêm mới một đối tượng.
        /// </summary>
        /// <param name="t">Thông tin đối tượng.</param>
        /// <returns>Số đối tượng được thêm vào.</returns>
        /// CreatedBy: dqdat (12/06/2021)
        public int Insert(T t)
        {
            MappingProcParametersValueWithObject(t);
            var rowAffect = DbConnection.Execute($"Proc_Insert{_className}", param: Parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        /// <summary>
        /// Cập nhật thông tin một đối tượng.
        /// </summary>
        /// <param name="t">Thông tin đối tượng cần cập nhật.</param>
        /// <returns>Số đối tượng được cập nhật.</returns>
        /// CreatedBy: dqdat (12/06/2021)
        public int Update(T t, Guid id)
        {
            // Gán lại gái trị cho Id
            t.GetType().GetProperty($"{_className}Id").SetValue(t, id);
            MappingProcParametersValueWithObject(t);
            var rowAffect = DbConnection.Execute($"Proc_Update{_className}", param: Parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        /// <summary>
        /// Xóa một đối tượng.
        /// </summary>
        /// <param name="id">id đối tượng cần xóa.</param>
        /// <returns>Số đối tượng bị xóa.</returns>
        /// CreatedBy: dqdat (12/06/2021)
        public int Delete(Guid id)
        {
            Parameters.Add($"@m_{_className}Id", id);
            var rowAffect = DbConnection.Execute($"Proc_Delete{_className}ById", param: Parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        /// <summary>
        /// Thực hiện gán giá trị tham số đầu vào của store với các property của object
        /// </summary>
        /// <param name="t"></param>
        /// CreatedBy: dqdat (12/06/2021)
        void MappingProcParametersValueWithObject(T t)
        {
            // Lấy ra các properties của đối tượng:
            var properties = typeof(T).GetProperties();

            // Duyệt từng Property:
            foreach (var property in properties)
            {
                // Lấy ra value:
                var value = property.GetValue(t);

                // Lấy ra tên của Property:
                var propertyName = property.Name;

                // Đặt tên cho tham số đầu vào:
                Parameters.Add($"@m_{propertyName}", value);
            }
        }
        #endregion
    }
}
