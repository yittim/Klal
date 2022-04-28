using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Infra.Helper
{
    public static class ExcelHelper
    {

        public static DataTest ReadXlsxDataToDataTest()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            int index = path.LastIndexOf("/");
            if (index > 0)
            {
                path = path.Substring(0, index);
            }
            XSSFWorkbook workbook = new XSSFWorkbook(path + @"\Helper\DataForTest.xlsx");

            // get sheet
            var sheet = (XSSFSheet)workbook.GetSheetAt(0);

            DataTest dataTest = new DataTest();
            dataTest.Firstname = sheet.GetRow(1).GetCell(0).ToString();
            dataTest.Lastname = sheet.GetRow(1).GetCell(1).ToString();
            dataTest.Password = sheet.GetRow(1).GetCell(2).ToString();
            dataTest.Company = sheet.GetRow(1).GetCell(3).ToString();
            dataTest.Address = sheet.GetRow(1).GetCell(4).ToString();
            dataTest.City = sheet.GetRow(1).GetCell(5).ToString();
            dataTest.Zip = sheet.GetRow(1).GetCell(6).ToString().Replace("\"", "");
            dataTest.Number = sheet.GetRow(1).GetCell(7).ToString().Replace("\"", "");
            dataTest.State = sheet.GetRow(1).GetCell(8).ToString();
            dataTest.Country = sheet.GetRow(1).GetCell(9).ToString();
            return dataTest;


        }
    }

}
