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

    //public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
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
            get
            {
                if (IsLoggedIn)
                    return CurrentUser.UserName;
                else
                    return _userName;
            }
            set => Set(ref _userName, value, "UserName");
        }

        private string _password = "******";
        public string Password
        {
            set => Set(ref _password, value);
            get => _password;
        }

        public bool IsLoggedIn
        {
            get
            {
                //RaisePropertyChanged("IsLoggedIn");
                return CurrentUser.IsLoggedIn;
            }
           // set => RaisePropertyChanged("IsLoggedIn");
        }

        public bool IsLoggedOut
        {
            get
            {
                //RaisePropertyChanged("IsLoggedOut");
                return !CurrentUser.IsLoggedIn;
            }
            //set => RaisePropertyChanged("IsLoggedOut");
        }

        public SolidColorBrush IsLoggedInColor
        {
            get
            {
                return new SolidColorBrush(IsLoggedIn ? Colors.Green : Colors.Gray);
            }
            set => RaisePropertyChanged("IsLoggedInColor");
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

            Password = "******";

            UpdateProperties();
        }

        private void OnRefreshLogOutCommandExecute()
        {
            CurrentUser.LogOut();

            Password = "******";

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

        private void UpdateProperties()
        {
            RaisePropertyChanged("IsLoggedIn");
            RaisePropertyChanged("IsLoggedOut");
            RaisePropertyChanged("IsLoggedInColor");
        }

    }
}
