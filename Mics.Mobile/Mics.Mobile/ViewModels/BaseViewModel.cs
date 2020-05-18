using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Mics.Mobile.Models;
using Mics.Mobile.Services;
using Mics.Web.Api;

namespace Mics.Mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IDataStore<Customer> CustomerDataStore => DependencyService.Get<IDataStore<Customer>>();
        public IDataStore<CustomerView> WebApiDataStore => new WebApiDataService();
        public IDataStore<Customer> CustomerSqlLiteDataStore => new SqliteDataService(App.FilePath);// DependencyService.Get<IDataStore<Customer>>();
        public IDataStore<CustomerView> CustomerViewSqlLiteDataStore =>  DependencyService.Get<IDataStore<CustomerView>>();
        public SqliteDataService sqlDataService => new SqliteDataService(App.FilePath);

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
