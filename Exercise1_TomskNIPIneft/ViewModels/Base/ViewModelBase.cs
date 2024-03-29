﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exercise1_TomskNIPIneft.ViewModels.Base
{
    internal abstract class ViewModelBase
        : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropretyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropretyName));
        }

        protected virtual bool Set<T>(ref T field, T value,
            [CallerMemberName] string PropertyName = "")
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;
            _Disposed = true;
        }
    }

}
