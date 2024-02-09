using System.Management;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GetInformation("Win32_Processor", "Description");
        }

        private static List<string> GetInformation(string Win32_Class, string ClassItemField)
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

                throw;
            }

            return result;
        }
    }
}
