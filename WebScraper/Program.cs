using System;
using System.Data;
using System.Collections.Generic;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Result> res = GetDeets.GetDeetsMethod("https://www.cbn.gov.ng/rates/GovtSecuritiesDrillDown.asp");
            DataTable dataTable = ConvertToDataTable.ConvertToDataTableMethod<Result>(res);
            GenerateExcel.GenerateExcelMethod(dataTable);
        } 
    }
}