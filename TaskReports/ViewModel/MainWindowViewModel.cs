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
using TaskReportLib.Services.EF;
using System.Threading;
using System.Collections.ObjectModel;

namespace TaskReports.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        public List<Tag> Tags
        {
            get => DataInMemory.Tags;
        }

        public List<Project> Projects
        {
            get => DataInMemory.Projects;
        }
        public List<Job> Jobs
        {
            get => DataInMemory.Jobs;
        }

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


        async void LoadDataInMemoryAsync()
        {
            await Task.Run(() =>
            {
                var usersDP = new EFUsersDataProvider(new DataContextProvider());
                var user = usersDP.TryFindUserByName("sunbro");
                if (user != null)
                    user = usersDP.GetUserAllById(user.Id);

                DataInMemory.CurrentUser = user;
                DataInMemory.Tags = user.Tags.ToList();
                DataInMemory.Projects = user.Projects.ToList();
                DataInMemory.Jobs = user.Jobs.ToList();

                Thread.Sleep(2000);

                RaisePropertyChanged("Tags");

                Thread.Sleep(2000);

                RaisePropertyChanged("Projects");

                RaisePropertyChanged("Jobs");
            });

        }





        public MainWindowViewModel()
        {
            LogInCommand = new RelayCommand(OnRefreshLogInCommandExecute, () => IsLoggedIn != true);
            LogOutCommand = new RelayCommand(OnRefreshLogOutCommandExecute, () => IsLoggedIn == true);
            ChangePasswordCommand = new RelayCommand(OnRefreshChangePasswordCommandExecute, () => IsLoggedIn == true);


            LoadDataInMemoryAsync();



            // начальная инициализация БД, раскомментировать при необходимости сброса базы данных
            //using (TaskReportsDb context = new TaskReportsDb())
            //{

            //    List<User> users = new List<User>
            //    {
            //        new User{UserName = "root", PasswordHash = "aabb2100033f0352fe7458e412495148", LastLogin = DateTime.Parse("2019-10-22 15:49:22.000")},
            //        new User{UserName = "aisc", PasswordHash = "ff4d41e1e980dd9e2697e74084d10a97", LastLogin = DateTime.Parse("2019-10-22 15:49:22.000")},
            //        new User{UserName = "sunbro"}
            //    };

            //    List<Project> projects = new List<Project>
            //    {
            //        new Project{Name = "Без проекта", Text="Если проект не требуется", Color="#aaaaaa", User = users[1]},
            //        new Project{Name = "Проект 2", Text="Описание проекта 2", Color="#0000ff", User = users[2]},
            //        new Project{Name = "Проект 3", Text="Описание проекта 3", Color="#00ff00", User = users[1]},
            //        new Project{Name = "Проект 4", Text="Описание проекта 4", Color="#ff0000", User = users[2]},
            //        new Project{Name = "Проект 5", Text="Описание проекта 5", Color="#0000ff", User = users[1]},
            //        new Project{Name = "Проект 6", Text="Описание проекта 6", Color="#ff0000", User = users[2]}
            //    };

            //    List<Tag> tags = new List<Tag>
            //    {
            //        new Tag{Name = "Работа №1", Text="Основные задачи в рабочее время", Color="#ff0000", User = users[1]},
            //        new Tag{Name = "Работа №2", Text="Основные задачи в рабочее время", Color="#00ff00", User = users[2]},
            //        new Tag{Name = "Обучение", Text="Обучение программированию и не только", Color="#0000ff", User = users[1]},
            //        new Tag{Name = "Обучение", Text="Обучение программированию и не только", Color="#0000ff", User = users[2]},
            //        new Tag{Name = "Отдых", Text="Перерывы на отдых, развлечения или что-то другое", Color="#aaaaaa", User = users[1]}
            //    };

            //    List<Job> jobs = new List<Job>
            //    {
            //        new Job { Name = "Задача 1", Description = "Описание задачи", User = users[1] },
            //        new Job { Name = "Задача 2", Description = "Описание задачи", User = users[1] },
            //        new Job { Name = "Задача 1", Description = "Описание задачи", User = users[2] },
            //        new Job { Name = "Задача 2", Description = "Описание задачи", User = users[2] },
            //        new Job { Name = "Задача 3", Description = "Описание задачи", User = users[1] }
            //    };


            //    context.Users.AddRange(users);
            //    context.Projects.AddRange(projects);
            //    context.Tags.AddRange(tags);
            //    context.Jobs.AddRange(jobs);
            //    context.SaveChanges();
            //}


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
