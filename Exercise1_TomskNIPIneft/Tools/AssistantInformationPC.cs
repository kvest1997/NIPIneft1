using System.Management;

namespace Exercise1_TomskNIPIneft.Tools
{
    /// <summary>
    /// Класс для запроса данных о параметрах ПК
    /// </summary>
    class AssistantInformationPC
    {
        /// <summary>
        /// Метод который получает информацию о характеристиках пк
        /// </summary>
        /// <param name="Win32_Class">Название класса для поиска информации</param>
        /// <param name="ClassItemField">Название поля для вытягивания нужной информации</param>
        /// <returns>Возращает список данных</returns>
        protected List<string> GetInformation(string Win32_Class, string ClassItemField)
        {
            List<string> result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT * FROM {Win32_Class}");

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    result.Add(item[ClassItemField].ToString().Trim());
                }
            }
            catch (Exception)
            {

                throw ;
            }

            return result;
        }


    }
}
