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
        }

        public bool IsLoggedIn_Invert
        {
            get => !CurrentUser.IsLoggedIn;
        }

        public SolidColorBrush IsLoggedInColor
        {
            get
            {
                return new SolidColorBrush(IsLoggedIn ? Colors.Green : Colors.Gray);
            }
        }

        public ICommand LogInCommand { get; }


        public MainWindowViewModel()
        {
            LogInCommand = new RelayCommand(OnRefreshLogInCommandExecute, CanRefreshLogInCommandExecute);
        }

        private bool CanRefreshLogInCommandExecute() => true;

        private void OnRefreshLogInCommandExecute()
        {
            //string password = pboxUserPassword.SecurePassword;
            bool unUseResult = CurrentUser.TryLogIn(UserName, Password);

            
        }






    }
}
