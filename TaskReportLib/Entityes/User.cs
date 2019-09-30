using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace TaskReportLib.Entityes
{
    public class User
    {
        private string username;
        private string password;

        public string UserName
        {
            set
            {
                Regex rg = new Regex(@"^[\w-]{3,16}$"); // Латинские буквы, цифры, дефисы и подчёркивания, от 3 до 16 символов
                if (rg.IsMatch(value))
                {
                    username = value;
                }
            }
            get
            {
                return username;
            }
        }

        public string Password
        {
            set
            {
                Regex rg = new Regex(@"^[\w-]{6,16}$"); // Латинские буквы, цифры, дефисы и подчёркивания, от 6 до 16 символов
                if (rg.IsMatch(value))
                {
                    password = GetMd5Hash(value);
                }
            }
            get
            {
                return password;
            }
        }
        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        private string GetMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}
