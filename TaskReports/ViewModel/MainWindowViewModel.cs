using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Input;

using TaskReportLib.Entityes;

using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight;
using System.Windows;
using System.Windows.Threading;

namespace TaskReports.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private string mainWindowTitle = "Task Reprots v0.01b";
        public string MainWindowTitle
        {
            get => mainWindowTitle;
            set => Set(ref mainWindowTitle, value);
        }

        // current user view model
        private string _userName;
        public string UserName
        {
            get => IsLoggedIn ? CurrentUser.UserName : _userName;
            set => Set(ref _userName, value, "UserName");
        }

        private string _password = "******";
        public string Password
        {
            get => CurrentUser.IsLoggedIn ? _password="******" : _password;
            set => _password = value;
           // Не ясно зачем используеюся код по примеру ниже, т.к. он не влияет на результат
           // set => Set(ref _password, CurrentUser.IsLoggedIn ? "******" : value);
        }

        public string LoggedInString
        {
            get => CurrentUser.IsLoggedIn ? "Подключен" : "Не подключен";
        }

        public bool IsLoggedIn
        {
            get => CurrentUser.IsLoggedIn;
        }

        public bool IsLoggedOut
        {
            get => !CurrentUser.IsLoggedIn;
        }

        public SolidColorBrush IsLoggedInColor
        {
            get => new SolidColorBrush(IsLoggedIn ? Colors.Green : Colors.Gray);
        }

        public ICommand LogInCommand { get; private set; }
        public ICommand LogOutCommand { get; private set; }
        public ICommand ChangePasswordCommand { get; private set; }

        public MainWindowViewModel()
        {
            LogInCommand = new RelayCommand(OnRefreshLogInCommandExecute, () => IsLoggedIn != true);
            LogOutCommand = new RelayCommand(OnRefreshLogOutCommandExecute, () => IsLoggedIn == true);
            ChangePasswordCommand = new RelayCommand(OnRefreshChangePasswordCommandExecute, () => IsLoggedIn == true);
        }

        private void OnRefreshLogInCommandExecute()
        {
            CurrentUser.TryLogIn(UserName, Password);

            //Password = "******";

            UpdateProperties();
        }

        private void OnRefreshLogOutCommandExecute()
        {
            CurrentUser.LogOut();

            //Password = "******";

            UpdateProperties();
        }

        private void OnRefreshChangePasswordCommandExecute()
        {
            //CurrentUser.TryChangePassword(Password);
            //Password = "******";

            UpdateProperties();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Можно ли избавиться от данного метода?
        private void UpdateProperties()
        {
            RaisePropertyChanged("IsLoggedIn");
            RaisePropertyChanged("IsLoggedOut");
            RaisePropertyChanged("IsLoggedInColor");
            RaisePropertyChanged("LoggedInString");
            RaisePropertyChanged("Password"); 
        }

    }
}
