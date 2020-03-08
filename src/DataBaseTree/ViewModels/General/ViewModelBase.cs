﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using DBManager.Application.Utils;
using DBManager.Application.View.Windows;
using Ninject;

namespace DBManager.Application.ViewModels.General
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public static IKernel Resolver { get; } = new StandardKernel();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
        

        public virtual void Dispose()
        {
            PropertyChanged = null;
        }
    }
}
