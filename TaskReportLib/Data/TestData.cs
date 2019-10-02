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
            new Tag{Id=1, Name = "Работа №1", Text="Основные задачи в рабочее время", Color= new SolidColorBrush(Colors.Red)},
            new Tag{Id=2, Name = "Работа №2", Text="Основные задачи в рабочее время", Color= new SolidColorBrush(Colors.Orange)},
            new Tag{Id=3, Name = "Обучение", Text="Обучение программированию и не только", Color= new SolidColorBrush(Colors.Blue)},
            new Tag{Id=4, Name = "Отдых", Text="Перерывы на отдых, развлечения или что-то другое", Color= new SolidColorBrush(Colors.Green)}
        };

        public static List<Project> Projects { get; } = new List<Project>
        {
            new Project{Id=1, Name = "Без проекта", Text="Если проект не требуется", Color= new SolidColorBrush(Colors.Gray)},
            new Project{Id=2, Name = "Проект 2", Text="Описание проекта 2", Color= new SolidColorBrush(Colors.Black)},
            new Project{Id=3, Name = "Проект 3", Text="Описание проекта 3", Color= new SolidColorBrush(Colors.Black)},
            new Project{Id=4, Name = "Проект 4", Text="Описание проекта 4", Color= new SolidColorBrush(Colors.Black)},
            new Project{Id=5, Name = "Проект 5", Text="Описание проекта 5", Color= new SolidColorBrush(Colors.Black)},
            new Project{Id=6, Name = "Проект 6", Text="Описание проекта 6", Color= new SolidColorBrush(Colors.Black)}
        };

        public static List<Task> Tasks { get; } = new List<Task>
        {
            new Task { Id = 1, Name = "Задача 1", Text = "Описание задачи", Project = Projects[0], Tag = Tags[0] },
            new Task { Id = 2, Name = "Задача 2", Text = "Описание задачи", Project = Projects[1], Tag = Tags[2] },
            new Task { Id = 3, Name = "Задача 3", Text = "Описание задачи", Project = Projects[0], Tag = Tags[3] }
        };

        static TestData()
        {

        }   

    }
}
