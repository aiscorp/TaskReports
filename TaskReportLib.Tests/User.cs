using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskReportLib.Entityes;

namespace TaskReportLib.Tests
{
    /// <summary>
    /// Общий тест класса User на создание экземпляра класса с проверкой корректности работы хэш алгоритма
    /// </summary>
    [TestClass]
    public class UserTests
    {


        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void NewUser()
        {
            // arange

            string userNameIn = "ivan";
            string passwordIn = "abc123";

            string userNameExpected = "ivan";
            string passwordHashExpected = "e99a18c428cb38d5f260853678922e03";

            string userNameActual;
            string passwordHashActual;

            // act

            User user1 = new User(userNameIn, passwordIn);
                       

           // user1.UserName = userNameIn;
            //user1.PasswordHash = passwordIn;

            userNameActual = user1.UserName;
            passwordHashActual = user1.PasswordHash;

            // assert

            Assert.AreEqual(userNameExpected, userNameActual);
            Assert.AreEqual(passwordHashExpected, passwordHashActual);

        }

        [TestMethod]
        public void CheckAutotification()
        {
            // arange

            string userNameIn = "ivan";
            string passwordIn = "abc123";
            
            bool isCorrect1, isCorrect2;

            // act

            User user1 = new User(userNameIn, passwordIn);

            isCorrect1 = user1.CheckAutotification(passwordIn);
            isCorrect2 = user1.CheckAutotification(userNameIn, passwordIn);


            // assert

            Assert.IsTrue(isCorrect1);
            Assert.IsTrue(isCorrect2);

        }

        [TestMethod]
        public void BlankUser()
        {
            // arange


            string userNameActual;
            string passwordHashActual;

            // act

            User user1 = new User();


            // user1.UserName = userNameIn;
            //user1.PasswordHash = passwordIn;

            userNameActual = user1.UserName;
            passwordHashActual = user1.PasswordHash;

            // assert

            Assert.IsNull(userNameActual);
            Assert.IsNull(passwordHashActual);

        }

    }
}
