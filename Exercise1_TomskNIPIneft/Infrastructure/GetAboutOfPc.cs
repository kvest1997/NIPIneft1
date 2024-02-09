using Exercise1_TomskNIPIneft.Tools;
using System.Windows.Forms;

namespace Exercise1_TomskNIPIneft.Services
{
    internal class GetAboutOfPc : AssistantInformationPC
    {
        private List<string> _result;
        private readonly Screen screen; // для определения размера экрана

        public GetAboutOfPc()
        {
            screen = Screen.PrimaryScreen;
            _result = new List<string>();
        }

        #region GetOSVersion - получение версии ОС
        public string GetOSVersion() => Environment.OSVersion.VersionString;
        #endregion

        #region GetPCName - получение название ПК
        public string GetPCName()
        {
            _result.Clear();
            _result = GetInformation("Win32_ComputerSystem", "Caption");

            return ConvertorListToString(_result);
        }
        #endregion

        #region GetProcessorType - получение названия процессора
        public string GetProcessorType() 
        {
            _result.Clear();
            _result = GetInformation("Win32_Processor","Name");

            return ConvertorListToString(_result);
        }
        #endregion

        #region GetRamSize - Получение размера RAM 
        public double GetRamSize()
        {
            _result.Clear();
            _result = GetInformation("Win32_ComputerSystem", "TotalPhysicalMemory");

            var ramOfbyte = Convert.ToDouble(ConvertorListToString(_result));

            double ramInfo = ramOfbyte / (1024 * 1024 * 1024);
            return ramInfo;
        }
        #endregion

        #region GetScreenHeight - Получение высоты экрана
        public int GetScreenHeight() => screen.Bounds.Height;
        #endregion

        #region GetScreenWidth - получение ширины экрана
        public int GetScreenWidth() => screen.Bounds.Width;
        #endregion

        #region ConvertorListToString - конвертация листа в стринг
        private string ConvertorListToString(List<string> result)
        {
            string result_temp = string.Empty;
            foreach (var item in result)
            {
                result_temp += item;
            }

            return result_temp;
        }
        #endregion
    }
}
