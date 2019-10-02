using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TaskReportLib.Entityes;
using System.Windows.Media;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskReports.ViewModel
{

    //public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
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
            set => Set(ref _userName, value);
            get
            {
                if (IsLoggedIn)
                    return CurrentUser.UserName;
                else
                    return _userName;
            }
        }

        private string _password;
        public string Password
        {
            set => Set(ref _password, value);
            get => _password;
        }


        public bool IsLoggedIn
        {
            get => CurrentUser.IsLoggedIn;
            //set => OnPropertyChanged(nameof(IsLoggedIn));
        }

        public bool IsLoggedIn_Invert
        {
            get => !CurrentUser.IsLoggedIn;
            //set => OnPropertyChanged(nameof(IsLoggedIn_Invert));
        }

        public SolidColorBrush IsLoggedInColor
        {
            get
            {
                return new SolidColorBrush(IsLoggedIn ? Colors.Green : Colors.Gray);
            }
            //set => OnPropertyChanged(nameof(IsLoggedInColor));
        }

        public ICommand LogInCommand { get; }
        public ICommand LogOutCommand { get; }
        public ICommand ChangePasswordCommand { get; }

        public MainWindowViewModel()
        {
            LogInCommand = new RelayCommand(OnRefreshLogInCommandExecute, CanRefreshLogInCommandExecute);
            LogOutCommand = new RelayCommand(OnRefreshLogOutCommandExecute, CanRefreshLogOutCommandExecute);
            ChangePasswordCommand = new RelayCommand(OnRefreshChangePasswordCommandExecute, CanRefreshChangePasswordCommandExecute);
        }

        private bool CanRefreshLogInCommandExecute() => true;

        private void OnRefreshLogInCommandExecute()
        {
            //string password = pboxUserPassword.SecurePassword;
            bool unUseResult = CurrentUser.TryLogIn(UserName, Password);

            Password = "******";

            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsLoggedIn_Invert));
            OnPropertyChanged(nameof(IsLoggedInColor));

        }

        private bool CanRefreshLogOutCommandExecute() => true;

        private void OnRefreshLogOutCommandExecute()
        {
            //string password = pboxUserPassword.SecurePassword;
            CurrentUser.LogOut();

            Password = "******";

            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsLoggedIn_Invert));
            OnPropertyChanged(nameof(IsLoggedInColor));

        }

        private bool CanRefreshChangePasswordCommandExecute() => true;

        private void OnRefreshChangePasswordCommandExecute()
        {
            //string password = pboxUserPassword.SecurePassword;
            CurrentUser.TryChangePassword(Password);

            Password = "******";

            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsLoggedIn_Invert));
            OnPropertyChanged(nameof(IsLoggedInColor));

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
