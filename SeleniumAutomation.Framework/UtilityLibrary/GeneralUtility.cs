using AutoItX3Lib;
using Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Framework.UtilityLibrary
{
    public class GeneralUtility
    {

        #region Database Connection Manipulation

        //TODO: Connecting Database

        #endregion
        
        #region Excel File Manipulation

        /// <summary>
        /// Read Excel data for the file from given location
        /// </summary>
        /// <returns></returns>
        public IExcelDataReader GetExcelReader()
        {
            string excelFilePath = @"C:\Users\prabur\Desktop\FunctionListInFramework.xlsx";
            FileStream stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = null;
            try
            {
                if(excelFilePath.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                if(excelFilePath.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                return reader;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Read Worksheet names from the excel workbook
        /// </summary>
        /// <returns>returns list of sheetnames in list string </returns>
        public IEnumerable<string> GetWorkSheetNames()
        {
            var reader = this.GetExcelReader();
            var workBook = reader.AsDataSet();
            var sheets = from DataTable sheet in workBook.Tables select sheet.TableName;
            return sheets;
        }

        /// <summary>
        /// Read Data from worksheet given for the excel datasource
        /// </summary>
        /// <param name="sheetName">Worksheet name</param>
        /// <param name="firstNameIsColumnNames">If First Row of the sheet is Column Names, then True else False </param>
        /// <returns>Data row list</returns>
        public IEnumerable<DataRow> GetRowDataFromWorkSheet(string sheetName, bool firstNameIsColumnNames)
        {
            var reader = this.GetExcelReader();
            reader.IsFirstRowAsColumnNames = firstNameIsColumnNames;
            var workSheet = reader.AsDataSet().Tables[sheetName];
            var rows = from DataRow a in workSheet.Rows select a;
            return rows;
        }

        /// <summary>
        /// Read Column Names from worksheet given for the excel datasource
        /// </summary>
        /// <param name="sheetName">Worksheet name</param>
        /// <param name="firstNameIsColumnNames">If First Row of the sheet is Column Names, then True else False </param>
        /// <returns>Column Names</returns>
        public IEnumerable<object> GetCloumnNamesFromWorkSheet(string sheetName, bool firstNameIsColumnNames)
        {
            var reader = this.GetExcelReader();
            if(firstNameIsColumnNames)
            {
                var workSheet = reader.AsDataSet();
                var columnNames = from DataTable sheet in workSheet.Tables select sheet.Rows[0].ItemArray;
                return columnNames;
            }
            return null;
        }

        #endregion

        #region CSV File Manipulation
        /// <summary>
        /// Read CSV file
        /// </summary>
        /// <returns>Return the csv values as IEnumerable String</returns>
        public IEnumerable<string> GetCSVData()
        {
            string csvFilePath = @"C:\Users\prabur\Desktop\FunctionListInFramework.csv";
            var csvLines = File.ReadAllLines(csvFilePath);
            return csvLines;
        }

        #endregion

        #region JSON File Manipulation
        /// <summary>
        /// Read the JSON File
        /// </summary>
        /// <returns>Returns the values as IEnumerable Object</returns>
        public IEnumerable<Object> GetJSONValues()
        {
            string filePath = @"C:\Users\prabur\Desktop\JSONTestFile.json";
            using (StreamReader reader = new StreamReader(filePath))
            {

                string json = reader.ReadToEnd();
                List<Object> items = JsonConvert.DeserializeObject<List<Object>>(json);
                return items;
            }
        }

        #endregion

        /// <summary>
        /// AutoIT functions
        /// </summary>
        public static void LoginAsAdminUser()
        {
            var AutoIT = new AutoItX3();
            AutoIT.WinWait("Authentication Required");
            AutoIT.WinWaitActive("Authentication Required");
            AutoIT.Send(ConfigurationManager.AppSettings["Username"]);
            AutoIT.Send("{TAB}");
            AutoIT.Send(ConfigurationManager.AppSettings["Password"]);
            AutoIT.Send("{ENTER}");
        }
    }



    /// <summary>
    /// Browser Types
    /// </summary>
    public enum BrowserType
    {
        Firefox,
        Chrome,
        InternetExplorer,
        Headless,
        Safari,
        Edge
    }

    /// <summary>
    /// Selenium Webdriver Locators
    /// </summary>
    public enum LocatorType
    {
        Id,
        Name,
        CssSelector,
        XPath,
        LinkText,
        PartialLinkText,
        TagName,
        ClassName
    }

    /// <summary>
    /// Type of Test Results Status
    /// </summary>
    public enum ResultStatus
    {
        Pass,
        Fail,
        Skipped,
        Inconclusive,
        Warning,
        Error
    }

    /// <summary>
    /// List of Timeouts
    /// </summary>
    public enum TimeOuts
    {
        PageLoadTimeOut,
        ImplicitTimeOutPeriod,
        ExplicitTimeOutPeriod,
        RetryTimeOutPeriod,
        SleepTime
    }
}
