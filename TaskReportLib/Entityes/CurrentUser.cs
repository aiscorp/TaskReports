using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskReportLib.Entityes
{
    public static class CurrentUser
    {
        public static string UserName { get => currentUser.UserName; }

        public static bool IsLoggedIn { get; private set; }

        private static User currentUser;

        static CurrentUser()
        {
            // Загрузка последнего залогинившегося пользователя будет организована позднее
            // на данный момент костыль root, root1234
            currentUser = new User("root", "root1234");
        }

        public static bool TryLogIn(string userName, string password)
        {

            if (currentUser != null && currentUser.CheckAutotification(userName, password))
            {
                IsLoggedIn = true;
                return true;
            }

            IsLoggedIn = false;
            return false;
        }

        public static bool TryChangePassword(string password)
        {
            if (currentUser != null)
            {
                currentUser.PasswordHash = password;
                return currentUser.CheckAutotification(password);
            }

            return false;
        }

        public static User TryGetUser()
        {
            if (currentUser != null)
                return currentUser;

            return null;
        }

        public static void ChangeUser(string userName, string password)
        {
            // Не разработано
            SaveUserData();
            LoadUserData();
        }
        public static void LogOut()
        {
            IsLoggedIn = false;
            // Логика далее не проработана
        }

        private static void LoadUserData()
        {
            // Загрузка данных пользователя 
        }

        private static void SaveUserData()
        {
            // Сохранение данных пользователя
        }

    }
}
