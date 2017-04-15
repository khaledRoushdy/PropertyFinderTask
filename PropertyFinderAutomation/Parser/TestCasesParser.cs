using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;

namespace PropertyFinderAutomation.Parser
{
    public class TestCasesParser
    {
        public static string GetValueOf(string key, string methodName, string className)
        {
            var testData = TestCasesParser.ParseTestDataFromExcel(className, methodName);
            try
            {
                return testData[key];
            }
            catch
            {
                return null;
            }


        } //end method

        public static List<string> GetAllStringValuesOf(string key, string methodName, string className,
            char delimiter = ',')
        {
            try
            {
                List<string> splittedTestData = new List<string>();
                var testData = TestCasesParser.ParseTestDataFromExcel(className, methodName);

                if (testData[key] != null)
                {
                    string commaSeparatedTestData = testData[key];
                    string[] dataElements = commaSeparatedTestData.Split(delimiter);

                    foreach (string element in dataElements)
                    {
                        splittedTestData.Add(element.Trim());
                    }

                } //endif

                return splittedTestData;

            }
            catch (Exception ex)
            {
                
                return null;
            }

        } //end method


        public static ArrayList GetAllValuesOf(string key, string methodName, string className, char delimiter = ',')
        {
            try
            {

                ArrayList splittedTestData = new ArrayList();
                var testData = TestCasesParser.ParseTestDataFromExcel(className, methodName);

                if (testData[key] != null)
                {
                    string commaSeparatedTestData = testData[key];
                    string[] dataElements = commaSeparatedTestData.Split(delimiter);

                    foreach (string element in dataElements)
                    {
                        splittedTestData.Add(element.Trim());
                    }

                }//endif

                return splittedTestData;
            }
            catch (Exception ex)
            {
                //TODO: log this
                return null;
            }

        }//end method

        public static Dictionary<string, string> ParseTestDataFromExcel(string className, string requiredMethodName)
        {
            var directory = AppDomain.CurrentDomain.RelativeSearchPath ??
                            AppDomain.CurrentDomain.BaseDirectory;

            var fileLocation = Path.Combine(directory, @"Parser\Data", "TestData.xlsx");

            FileStream stream = File.Open(fileLocation, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            stream.Dispose();
            excelReader.IsFirstRowAsColumnNames = true;

            DataTable requiredWorkSheet = excelReader.AsDataSet().Tables[className];
            Dictionary<string, string> testCaseData = new Dictionary<string, string>();

            //The actual test data starts from the 9th row in the excel sheet (The above rows are for test reference)
            //Due to the setting that First Row As Coulmn Names, the data is considered to start from the 8th row 
            //As we are zero-based, the index is 7
            for (int rowCounter = 8; rowCounter < requiredWorkSheet.Rows.Count; rowCounter++)
            {
                //The method name is the second column in the sheet (column index is 1 for zero-based array)
                string inspectedMethodName = requiredWorkSheet.Rows[rowCounter].ItemArray[1].ToString();

                if (inspectedMethodName == requiredMethodName)
                {
                    //The actual data starts from the thrid column, index is 2
                    for (int coulmnCounter = 2; coulmnCounter < requiredWorkSheet.Columns.Count; coulmnCounter++)
                    {
                        //if this cell is not empty (it has data in it)
                        if (requiredWorkSheet.Rows[rowCounter].ItemArray[coulmnCounter].ToString() != string.Empty)
                        {
                            //Add the value of this cell to the Data Dictionary
                            // Key is the Column Header (Control Name), the value is the value located in the cell
                            testCaseData.Add(requiredWorkSheet.Columns[coulmnCounter].ColumnName, requiredWorkSheet.Rows[rowCounter].ItemArray[coulmnCounter].ToString());

                        }//enndif

                    }//endfor

                    //exit the loop as you already found the required method
                    //so there is no need to loop on the rest of the rows
                    break;

                }//endif

            }//endfor

            return testCaseData;

        }//end method ParseTestDataFromExcel

    }//end class
}

