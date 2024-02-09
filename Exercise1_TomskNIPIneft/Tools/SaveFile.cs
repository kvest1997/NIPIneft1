using System.Diagnostics;
using System.IO;
using System.Net;

namespace Exercise1_TomskNIPIneft.Tools
{
    internal class SaveFile
    {
        private readonly SaveFileDialog saveFile;
        private readonly HtmlPage _htmlPage;

        public SaveFile()
        {
            saveFile = new SaveFileDialog();
            _htmlPage = new HtmlPage();
        }

        public void SaveStreamToFile(byte[] bookExcel)
        {
            saveFile.DefaultExt = ".xlsx";
            saveFile.Filter = "Excel (.xlsx)|*.xlsx|Excel  (.xls)|*.xls";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(bookExcel);
                }

                _htmlPage.Url = "file:///" + saveFile.FileName;
                _htmlPage.CreateHtmlPage();

                // Создание сообщения с кнопками "OK" и "Отмена"
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;

                // Отображение сообщения с ссылкой на скачивание
                DialogResult result = MessageBox.Show("Нажмите \"OK\", чтобы скачать файл", "Скачивание", buttons);
                if (result == DialogResult.OK)
                {
                    Process.Start(new ProcessStartInfo(_htmlPage.HtmlName) { UseShellExecute = true });
                }
            }
        }
    }
}
