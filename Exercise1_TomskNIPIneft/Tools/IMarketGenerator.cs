using Aspose.Cells;
using Exercise1_TomskNIPIneft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_TomskNIPIneft.Tools
{
    internal interface IMarketGenerator
    {
        byte[] GenerateToExcel<T>(T report);
    }
}
