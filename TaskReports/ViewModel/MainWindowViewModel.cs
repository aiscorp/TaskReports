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
using TaskReportLib.Data;

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
            get => CurrentUser.IsLoggedIn ? _password = "******" : _password;
            set => _password = value;
            // Не ясно зачем используеюся код по примеру ниже, т.к. он не влияет на результат
            // set => Set(ref _password, CurrentUser.IsLoggedIn ? "******" : value);
        }

        public string LoggedInString
        {
            get => CurrentUser.IsLoggedIn ? "Подключен" : "Не подключен";
        }

        public string LoggedInColor
        {
            get => IsLoggedIn ? "Green" : "Gray";
        }

        public bool IsLoggedIn
        {
            get => CurrentUser.IsLoggedIn;
        }

        public bool IsLoggedOut
        {
            get => !CurrentUser.IsLoggedIn;
        }

        public int TestValue = 10;


        public ICommand LogInCommand { get; private set; }
        public ICommand LogOutCommand { get; private set; }
        public ICommand ChangePasswordCommand { get; private set; }

        public MainWindowViewModel()
        {
            LogInCommand = new RelayCommand(OnRefreshLogInCommandExecute, () => IsLoggedIn != true);
            LogOutCommand = new RelayCommand(OnRefreshLogOutCommandExecute, () => IsLoggedIn == true);
            ChangePasswordCommand = new RelayCommand(OnRefreshChangePasswordCommandExecute, () => IsLoggedIn == true);

            using (DataContext context = new DataContext())
            {
                context.Database.Delete();

                var job = new Job() { Name = "job" };

                List<Project> projects = new List<Project>
                {
                    new Project{Id=1, Name = "Без проекта", Text="Если проект не требуется", Color="#aaaaaa"},
                    new Project{Id=2, Name = "Проект 2", Text="Описание проекта 2", Color="#0000ff"},
                    new Project{Id=3, Name = "Проект 3", Text="Описание проекта 3", Color="#00ff00"},
                    new Project{Id=4, Name = "Проект 4", Text="Описание проекта 4", Color="#ff0000"},
                    new Project{Id=5, Name = "Проект 5", Text="Описание проекта 5", Color="#0000ff"},
                    new Project{Id=6, Name = "Проект 6", Text="Описание проекта 6", Color="#ff0000"}
                };

                List<Tag> tags = new List<Tag>
                {
                    new Tag{Id=1, Name = "Работа №1", Text="Основные задачи в рабочее время", Color="#ff0000"},
                    new Tag{Id=2, Name = "Работа №2", Text="Основные задачи в рабочее время", Color="#00ff00"},
                    new Tag{Id=3, Name = "Обучение", Text="Обучение программированию и не только", Color="#0000ff"},
                    new Tag{Id=4, Name = "Отдых", Text="Перерывы на отдых, развлечения или что-то другое", Color="#aaaaaa"}
                };

                List<Job> jobs = new List<Job>
                {
                    new Job { Id = 1, Name = "Задача 1", Description = "Описание задачи" },
                    new Job { Id = 2, Name = "Задача 2", Description = "Описание задачи" },
                    new Job { Id = 3, Name = "Задача 3", Description = "Описание задачи" }
                };


                context.Jobs.Add(job);
                context.Projects.AddRange(projects);
                context.Tags.AddRange(tags);
                context.Jobs.AddRange(jobs);
                context.SaveChanges();
            }


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
            RaisePropertyChanged("LoggedInColor");
            RaisePropertyChanged("LoggedInString");
            RaisePropertyChanged("Password");
        }

    }
}
