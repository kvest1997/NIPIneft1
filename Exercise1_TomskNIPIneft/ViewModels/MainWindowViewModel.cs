using Exercise1_TomskNIPIneft.Infrastructure.Commands;
using Exercise1_TomskNIPIneft.Models;
using Exercise1_TomskNIPIneft.Services;
using Exercise1_TomskNIPIneft.Tools;
using Exercise1_TomskNIPIneft.ViewModels.Base;
using System.Windows.Input;
using Application = System.Windows.Application;


namespace Exercise1_TomskNIPIneft.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Модель данных компьютера
        /// </summary>
        private readonly ComputerSpecificationModel _PCModel;
        private readonly MarketGenerator _market;
        private readonly SaveFile _saveFile;

        /// <summary>
        /// Класс получающий информацию о ПК
        /// </summary>
        private readonly GetAboutOfPc InformationPC;
        public MainWindowViewModel()
        {
            InformationPC = new GetAboutOfPc();
            _PCModel = GetAllComputerSpecificationModel();
            FillFields();
            _market = new MarketGenerator();
            _saveFile = new SaveFile();

            SaveToExcel = new LambdaCommand(OnSaveToExcel, CanSaveToExcel);
            
        }

        /// <summary>
        /// Метод создающий нашу модель с данными о текущем ПК
        /// </summary>
        /// <returns>Возращает объект модели с данными о ПК</returns>
        #region GetAllComputerSpecificationModel - создание модели ПК
        private ComputerSpecificationModel GetAllComputerSpecificationModel() => new ComputerSpecificationModel
        { 
            PcName = InformationPC.GetPCName(),
            TypeCpu = InformationPC.GetProcessorType(),
            VersionOS = InformationPC.GetOSVersion(),
            Ram = InformationPC.GetRamSize(),
            ScreenHeigth = InformationPC.GetScreenHeight(),
            ScreenWidth = InformationPC.GetScreenWidth()
        };
        #endregion

        /// <summary>
        /// Метод заполнения полей для вывода на форму
        /// </summary>
        #region FillFields - Заполнение полей
        private void FillFields()
        {
            _pcName = _PCModel.PcName;
            _typeCPU = _PCModel.TypeCpu;
            _versionOS = _PCModel.VersionOS;
            _ram = string.Format("{0:0.00}", _PCModel.Ram);
            _screenHeigth = _PCModel.ScreenHeigth;
            _screenWidth = _PCModel.ScreenWidth;

            _screenResolution = $"{_screenWidth}x{_screenHeigth}";
        }
        #endregion

        private int _screenHeigth;
        private int _screenWidth;

        private string _Title = "Тестовое задание 1 - ТомскНИПИнефть";
        public string Title { get => _Title; set => Set(ref _Title, value); }

        private string _screenResolution;
        public string ScreenResolution { get => _screenResolution; set => Set(ref _screenResolution, value); }

        private string _ram;
        public string Ram { get => _ram; set => Set(ref _ram, value); }

        private string _pcName;
        public string PcName { get => _pcName; set => Set(ref _pcName, value); }


        private string _typeCPU;
        public string TypeCPU { get => _typeCPU; set => Set(ref _typeCPU, value); }

        private string _versionOS;
        
        public string VersionOS { get => _versionOS; set => Set(ref _versionOS, value); }

        public void OnCloseCommand()
        {
            _saveFile.SaveStreamToFile(_market.GenerateToExcel(_PCModel));
        }

        public ICommand SaveToExcel { get; }
        public void OnSaveToExcel(object p)
        {
            _saveFile.SaveStreamToFile(_market.GenerateToExcel(_PCModel));
        }
        private bool CanSaveToExcel(object p) => true;

    }
}
