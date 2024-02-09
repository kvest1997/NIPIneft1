using Aspose.Cells;
using Exercise1_TomskNIPIneft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Exercise1_TomskNIPIneft.Tools
{
    class MarketGenerator : IMarketGenerator
    {
        public byte[] GenerateToExcel<T>(T report) 
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var json = JsonConvert.SerializeObject(report);
            Dictionary<string, string> paramter = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);


            var package = new ExcelPackage();
            
            Workbook book = new Workbook();
            var sheet = package.Workbook.Worksheets.Add("Report");
            
            int i = 1;
            foreach (var item in paramter)
            {
                sheet.Cells[$"A{i}"].Value = item.Key;
                sheet.Cells[$"B{i}"].Value = item.Value;
                i++;
            }
            
            return package.GetAsByteArray();
        }
    }
}
