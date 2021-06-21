using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repository;
using MISA.AMIS.Core.Interfaces.Service;
using MISA.AMIS.Core.Properties;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// Export file excel danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: dqdat (14/06/2021)
        public Stream ExportExcel()
        {
            var res = _employeeRepository.GetAll();
            var listEmployees = res.ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

            // Thêm title và style title cho file excel
            using (var range = workSheet.Cells["A1:I1"])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Value = "DANH SÁCH NHÂN VIÊN";
                range.Merge = true;
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 18;
            }


            // Thêm title cho danh sách nhân viên trong file excel.
            workSheet.Cells[3, 1].Value = "STT";
            workSheet.Cells[3, 2].Value = "Mã nhân viên";
            workSheet.Cells[3, 3].Value = "Tên nhân viên";
            workSheet.Cells[3, 4].Value = "Giới tính";
            workSheet.Cells[3, 5].Value = "Ngày sinh";
            workSheet.Cells[3, 6].Value = "Chức danh";
            workSheet.Cells[3, 7].Value = "Tên đơn vị";
            workSheet.Cells[3, 8].Value = "Số tài khoản";
            workSheet.Cells[3, 9].Value = "Tên ngân hàng";


            // style cho title danh sách nhân viên
            using (var range = workSheet.Cells["A3:I3"])
            {
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                range.Style.Font.Bold = true;

                // Thêm border cho các ô
                for (int j = 1; j <= 9; j++)
                {
                    workSheet.Cells[3,j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
            }

            // set độ rộng cho cột.
            workSheet.Column(1).Width = 5;
            workSheet.Column(2).Width = 15;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 15;
            workSheet.Column(5).Width = 15;
            workSheet.Column(6).Width = 25;
            workSheet.Column(7).Width = 30;
            workSheet.Column(8).Width = 20;
            workSheet.Column(9).Width = 30;


            int i = 0;
            // Gán dữ liệu từ listEployees vào workSheet.
            foreach (var e in listEmployees)
            {
                workSheet.Cells[i + 4, 1].Value = i + 1;
                workSheet.Cells[i + 4, 2].Value = e.EmployeeCode;
                workSheet.Cells[i + 4, 3].Value = e.EmployeeName;
                workSheet.Cells[i + 4, 4].Value = e.GenderName;
                workSheet.Cells[i + 4, 5].Value = e.DateOfBirth?.ToString("dd/MM/yyyy");
                workSheet.Cells[i + 4, 6].Value = e.EmployeePosition;
                workSheet.Cells[i + 4, 7].Value = e.EmployeeDepartmentName;
                workSheet.Cells[i + 4, 8].Value = e.BankAccountNumber;
                workSheet.Cells[i + 4, 9].Value = e.BankName;

                // Thêm border cho các ô
                for (int j = 1; j <= 9; j++)
                {
                    workSheet.Cells[i + 4, j].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                // Căn chỉnh giữa cho ô ngày sinh
                workSheet.Cells[i + 4, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                i++;
            }

            package.Save();
            stream.Position = 0;
            return package.Stream;
        }


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
