namespace Exercise1_TomskNIPIneft.Models
{
    class ComputerSpecificationModel
    {
        private string _pcName;
        private string _versionOS;
        private string _typeCPU;
        private double _ram;
        private int _screenHeigth;
        private int _screenWidth;

        public string PcName { get => _pcName; set => _pcName = value; }
        public string VersionOS { get => _versionOS; set => _versionOS = value; }
        public string TypeCpu { get => _typeCPU; set => _typeCPU = value; }
        public double Ram { get => _ram; set => _ram = value; }
        public int ScreenHeigth{ get => _screenHeigth; set => _screenHeigth = value; }
        public int ScreenWidth { get => _screenWidth; set => _screenWidth = value; }
    }
}
