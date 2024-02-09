using Exercise1_TomskNIPIneft.Infrastructure.Commands.Base;

namespace Exercise1_TomskNIPIneft.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute,
            Func<object, bool> CanExecute = null)
        {
            this._Execute = Execute;
            this._CanExecute = CanExecute;
        }
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
        public override void Execute(object parameter) => _Execute(parameter);
    }
}
