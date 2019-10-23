using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;
using TaskReportLib.Entityes;

namespace TaskReportLib.Data
{
    public static class TestData
    {
        public static List<Tag> Tags { get; } = new List<Tag>
        {
            new Tag{Id=1, Name = "Работа №1", Text="Основные задачи в рабочее время", Color="#ff0000"},
            new Tag{Id=2, Name = "Работа №2", Text="Основные задачи в рабочее время", Color="#00ff00"},
            new Tag{Id=3, Name = "Обучение", Text="Обучение программированию и не только", Color="#0000ff"},
            new Tag{Id=4, Name = "Отдых", Text="Перерывы на отдых, развлечения или что-то другое", Color="#aaaaaa"}
        };

        public static List<Project> Projects { get; } = new List<Project>
        {
            new Project{Id=1, Name = "Без проекта", Text="Если проект не требуется", Color="#aaaaaa"},
            new Project{Id=2, Name = "Проект 2", Text="Описание проекта 2", Color="#0000ff"},
            new Project{Id=3, Name = "Проект 3", Text="Описание проекта 3", Color="#00ff00"},
            new Project{Id=4, Name = "Проект 4", Text="Описание проекта 4", Color="#ff0000"},
            new Project{Id=5, Name = "Проект 5", Text="Описание проекта 5", Color="#0000ff"},
            new Project{Id=6, Name = "Проект 6", Text="Описание проекта 6", Color="#ff0000"}
        };

        public static List<Job> Tasks { get; } = new List<Job>
        {
            new Job { Id = 1, Name = "Задача 1", Description = "Описание задачи" },
            new Job { Id = 2, Name = "Задача 2", Description = "Описание задачи" },
            new Job { Id = 3, Name = "Задача 3", Description = "Описание задачи" }
        };

        static TestData()
        {

        }   

    }
}
