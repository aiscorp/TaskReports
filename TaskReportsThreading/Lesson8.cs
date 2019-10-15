using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReportsThreading
{
    class Lesson8
    {
        public static void Lesson_8()
        {
            
        }

        // 1. Выполнить без использования среды разработки, используя только ручку и лист бумаги, 
        // задачу на написание консольного приложения нахождения факториала числа N.
        // Выполнил.. (шутка, но на алгоритмах делали), задание странное.

        // 2. Есть ли проблемы в следующем коде?

        //    int i = 1;  // все строки корректны не считая последней
        //    object obj = i;
        //    ++i;
        //    Console.WriteLine(i); // выведется инкремент i, т.е.  2
        //    Console.WriteLine(obj); // выведется 1
        //
        //    Console.WriteLine((short) obj); - ошибка приведения типа object к short, т.к. мы положили int

        // 3.  Есть таблица Users. Столбцы в ней — Id, Name. Написать SQL-запрос, который выведет имена пользователей, начинающиеся на 'A' и встречающиеся в таблице более одного раза, и их количество.

        // Честно говоря SQL не копал до данного момента, но 30 минут гугления дали вот это:
        //
        // Вывод списка пользователей, с именами начинающимися на 'A' 
        // и встречающиеся в таблице более одного раза и их количество
        //
        // SELECT Name, COUNT(CASE WHEN Name>1 THEN 1 ELSE NULL END) 
        // FROM Users 
        // WHERE Name 
        // Like "А%"

        // 4. Каков результат вывода следующего кода?
        //
        //  Ответ - выведется 5, т.к. enum считает по порядку, начальное значение задано в 4.
        //
        //private enum SomeEnum
        //{
        //    First = 4,
        //    Second,
        //    Third = 7
        //}
        //static void Main(string[] args)
        //{
        //    Console.WriteLine((int)SomeEnum.Second); 
        //}


    }
}
