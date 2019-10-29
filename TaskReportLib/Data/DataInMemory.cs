using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Windows.Media;
using TaskReportLib.Entityes;

namespace TaskReportLib.Data
{
    public class DataInMemory
    {

        public static User CurrentUser { get; set; }
        public static List<Tag> Tags { get; set; }

        public static List<Project> Projects { get; set; }

        public static List<Job> Jobs { get; set; }

        static DataInMemory()
        {
            CurrentUser = new User { UserName = "root", PasswordHash = "aabb2100033f0352fe7458e412495148", LastLogin = DateTime.Parse("2019-10-22 15:49:22.000") };

            Projects = new List<Project>
                {
                    new Project{Name = "Проект", Text="Данные не загружены", Color="#aaaaaa"},
                    new Project{Name = "Проект", Text="Данные не загружены", Color="#aaaaaa"}
                };

            Tags = new List<Tag>
                {
                    new Tag{Name = "Тег", Text="Данные не загружены", Color="#aaaaaa"},
                    new Tag{Name = "Тег", Text="Данные не загружены", Color="#aaaaaa"}
                };

            Jobs = new List<Job>
                {
                    new Job { Name = "Задача", Description = "Данные не загружены" },
                    new Job { Name = "Задача", Description = "Данные не загружены" }
                };
        }
    }
}
