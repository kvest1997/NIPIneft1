using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_TomskNIPIneft.Tools
{
    internal class HtmlPage
    {
        private string _htmlPage;
        private string _htmlName = "example.html";

        public string Url { get; set; }
        public string HtmlName { get => _htmlName; set => _htmlName = value; }


        public void CreateHtmlPage()
        {
            _htmlPage = @$"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Скачивание файла</title>
        </head>
        <body>
            <a href=""{Url}"" download>Скачать файл</a>
        </body>
        </html>";
            SaveHtmlPage();
        }

        private void SaveHtmlPage() 
        {
            File.WriteAllText(_htmlName, _htmlPage);
        }
    }
}
