using System;
using System.Collections.Generic;
using System.Text;
using ItKarieraProject.Test.Dummies;
using ItKarieraProjectTest;
using ItKarieraProjectTest.CustomExceptions;
using ItKarieraProjectTest.DAO;
using ItKarieraProjectTest.Models;
using ItKarieraProjectTest.Presentation;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Security.Cryptography;
namespace ItKarieraProject.Test
{
    //Tests the Login and Registration Methods
    [TestFixture]
    class LoginControllerTest
    {
        [Test]
        public void UserSuccessfullyLogged()
        {
            //Arrange
            SoftUniProjectDBContext context = new SoftUniProjectDBContext();

            IProfileDAO profileDAO = new ProfileDAODummy();


            LoginController loginController = new LoginController(profileDAO);

            string username = "testUser";
            string password = "1234";

            //Act
            int actualUserId = 0;
            int userIDResult = loginController.Login(username, password);
            //Assert
            Assert.That(userIDResult, Is.EqualTo(actualUserId));
        }

        [Test]
        public void UserUsesWrongCredentialsReturnsIncorrectCredentialsException()
        {
            //Arrange
            SoftUniProjectDBContext context = new SoftUniProjectDBContext();

            IProfileDAO profileDAO = new ProfileDAODummy();


            LoginController loginController = new LoginController(profileDAO);
            //Act
            string username = "wrongUsername";
            string password = "1234";
            //Assert
            var exception = Assert.Throws<IncorrectCredentialsException>(() => loginController.Login(username, password));
            Assert.That(exception.Message, Is.EqualTo("Incorrect credentials"));

        }

        [Test]
        public void RegisterMinionUserSuccessfully()
        {
            //Arrange
            SoftUniProjectDBContext context = new SoftUniProjectDBContext();
            ProfileDAO profileDAO = new ProfileDAO(context);

            LoginController loginController = new LoginController(profileDAO);
            //Act
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            registrationViewModel.FirstName = "Ivan";
            registrationViewModel.LastName = "Ivanov";
            registrationViewModel.Balance = 32;
            registrationViewModel.WorkHours = 12;
            registrationViewModel.Username = "TestUsername";
            registrationViewModel.Password = "testPassword";
            registrationViewModel.Company = 2;

            loginController.Register(registrationViewModel);
            //Assert
            WorkersProfile loginUser = context.WorkersProfile
                                .Include(l => l.PersonInfo)
                                .Where(l => l.Username.Equals(registrationViewModel.Username) &&
                                            l.Password.Equals(registrationViewModel.Password))
                                ?.FirstOrDefault();
            Assert.That(registrationViewModel.Username, Is.EqualTo(loginUser.Username));

            context.PersonInfo.Remove(loginUser.PersonInfo);
            context.WorkersProfile.Remove(loginUser);
            context.SaveChanges();

        }


        private PersonInfo CreateDummyUser()
        {
            PersonInfo user = new PersonInfo();
            user.Id = 0;

            return user;
        }
    }
}
