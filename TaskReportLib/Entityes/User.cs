using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;

namespace TaskReportLib.Entityes
{
    public class User
    {
        // ------
        private string userName;
        private string passwordHash;
        // ------        
        public int Id { get; set; }
        public string UserName
        {
            set
            {
                Regex rg = new Regex(@"^[\w-]{3,16}$"); // Латинские буквы, цифры, дефисы и подчёркивания, от 3 до 16 символов
                if (!string.IsNullOrEmpty(value) && rg.IsMatch(value))
                    userName = value;
            }
            get => userName;
        }
        public string PasswordHash
        {
            set
            {
                Regex rg = new Regex(@"^[\w-]{6,16}$"); // Латинские буквы, цифры, дефисы и подчёркивания, от 6 до 16 символов
                if (!string.IsNullOrEmpty(value) && rg.IsMatch(value))
                    passwordHash = GetMd5Hash(value);
            }
            get => passwordHash;
        }
        [Column(TypeName = "datetime2")] public DateTime LastLogin { get; set; }
        [Column(TypeName = "datetime2")] public DateTime DaySpan { get; set; }
        [Column(TypeName = "datetime2")] public DateTime WeekSpan { get; set; }
        [Column(TypeName = "datetime2")] public DateTime MonthSpan { get; set; }
        [Column(TypeName = "datetime2")] public DateTime YearSpan { get; set; }
        [Column(TypeName = "datetime2")] public virtual ICollection<Job> Jobs { get; set; }
        // ------
        public User(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                UserName = username;
                PasswordHash = password;
            }
        }
        public User() { }
        // ------
        public bool CheckAutotification(string password)
        {
            if (!string.IsNullOrEmpty(password) && GetMd5Hash(password) == passwordHash)
                return true;

            return false;
        }
        public bool CheckAutotification(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && userName == this.userName && GetMd5Hash(password) == passwordHash)
                return true;

            return false;
        }
        private string GetMd5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
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
}
