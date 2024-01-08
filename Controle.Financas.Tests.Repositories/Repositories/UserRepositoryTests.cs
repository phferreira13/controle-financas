using Microsoft.VisualStudio.TestTools.UnitTesting;
using Controle.Financas.EFConfiguration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle.Financas.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Controle.Financas.Tests.Shared.Factories.Users;
using Controle.Financas.Domain.Enums;
using Controle.Financas.Shared.Services;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Tests.Repositories.Repositories.Base;

namespace Controle.Financas.EFConfiguration.Repositories.Tests
{
    [TestClass]
    public class UserRepositoryTests : BaseRepositoryTest
    {
        private UserRepository _userRepository;

        [TestInitialize]
        public void ResetDatabase()
        {
            ConfigureContext();
            _userRepository = new UserRepository(_controleFinancasContext);
        }

        [TestMethod("GetUserByIdAsync - Should return not null")]
        [TestCategory("Success")]
        public async Task GetUserByIdTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = await _userRepository.InsertUserAsync(user);

            // Act
            var result = await _userRepository.GetUserByIdAsync(created.Id);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod("GetUserByEmailAsync - Should return not null")]
        [TestCategory("Success")]
        public async Task GetUserByEmailTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = await _userRepository.InsertUserAsync(user);

            // Act
            var result = _userRepository.GetUserByEmailAsync(created.Email);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod("GetUserByEmailAndPasswordAsync - Should return not null")]
        [TestCategory("Success")]
        public void GetUserByEmailAndPasswordTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = _userRepository.InsertUserAsync(user).Result;

            // Act
            var result = _userRepository.GetUserByEmailAndPasswordAsync(created.Email, created.Password);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod("GetAllUsersTest - Should return 10")]
        [TestCategory("Success")]
        public async Task GetAllUsersTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var users = addUserFactory.BuildList(10);
            
            foreach (var user in users)
            {
                await _userRepository.InsertUserAsync(user);
            }

            // Act
            var result = await _userRepository.GetAllUsersAsync();

            // Assert
            Assert.AreEqual(10, result.Count());

        }

        [TestMethod("InsertUserAsync - Should return inserted")]
        [TestCategory("Success")]
        public void InsertUserTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();

            // Act
            var result = _userRepository.InsertUserAsync(user).Result;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod("UpdateUserAsync - Should return updated")]
        [TestCategory("Success")]
        public void UpdateUserTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = _userRepository.InsertUserAsync(user).Result;

            var updateUserFactory = new UpdateUserDtoFactory();
            var updateUser = updateUserFactory.WithId(created.Id).Build();

            // Act
            var result = _userRepository.UpdateUserAsync(updateUser).Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updateUser.Id, result.Id);
            Assert.AreEqual(updateUser.FullName, result.FullName);
            Assert.AreEqual(updateUser.Email, result.Email);
            Assert.AreEqual(updateUser.Password, result.Password);
            Assert.IsTrue(result.UpdatedDate.HasValue);
        }

        [TestMethod("DeleteUserAsync - Should update status")]
        [TestCategory("Success")]
        public async Task DeleteUserTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = _userRepository.InsertUserAsync(user).Result;

            // Act
            await _userRepository.DeleteUserAsync(created.Id);
            var deleted = await _userRepository.GetUserByIdAsync(created.Id);

            // Assert
            Assert.IsNotNull(deleted);
            Assert.IsTrue(deleted.Status == EStatus.Deleted);
        }

        [TestMethod("ChangeStatusAsync - Should update status")]
        [TestCategory("Success")]
        public async Task ChangeStatusTest()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = _userRepository.InsertUserAsync(user).Result;

            // Act
            var result = await _userRepository.ChangeStatusAsync(created.Id, EStatus.Inactive);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Status == EStatus.Inactive);
        }

        [TestMethod("GetUserByIdAsync - Should return null")]
        [TestCategory("Success")]
        public async Task GetUserById_ShouldReturnNull()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = await _userRepository.InsertUserAsync(user);

            // Act
            var result = await _userRepository.GetUserByIdAsync(created.Id+1);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod("GetUserByEmailAsync - Should return null")]
        [TestCategory("Success")]
        public async Task GetUserByEmail_ShouldReturnNull()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = await _userRepository.InsertUserAsync(user);

            // Act
            var result = await _userRepository.GetUserByEmailAsync(created.Email+"1");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod("GetUserByEmailAndPasswordAsync - Should return null")]
        [TestCategory("Success")]
        public async Task GetUserByEmailAndPassword_ShouldReturnNull()
        {
            // Arrange
            var addUserFactory = new AddUserDtoFactory();
            var user = addUserFactory.Build();
            var created = await _userRepository.InsertUserAsync(user);

            // Act
            var result = await _userRepository.GetUserByEmailAndPasswordAsync(created.Email+"1", created.Password+"1");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod("GetAllUsersTest - Should return 0")]
        [TestCategory("Success")]
        public async Task GetAllUsers_ShouldReturnZero()
        {
            // Arrange

            // Act
            var result = await _userRepository.GetAllUsersAsync();

            // Assert
            Assert.AreEqual(0, result.Count());
        }

        //Should return exception

        [TestMethod("UpdateUserAsync - Should return exception")]
        [TestCategory("Exception")]
        public async Task UpdateUser_ShouldReturnException()
        {
            // Arrange
            var factory = new UpdateUserDtoFactory();
            var user = factory.Build();

            try
            {
                // Act
                var result = await _userRepository.UpdateUserAsync(user);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ErrorMessageService.GetErrorMessage(EErrorType.NotFound, "User"), ex.Message);
            }
        }

        [TestMethod("DeleteUserAsync - Should return exception")]
        [TestCategory("Exception")]
        public async Task DeleteUser_ShouldReturnException()
        {
            // Arrange
            var factory = new UpdateUserDtoFactory();
            var user = factory.Build();

            try
            {
                // Act
                await _userRepository.DeleteUserAsync(user.Id);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ErrorMessageService.GetErrorMessage(EErrorType.NotFound, "User"), ex.Message);
            }
        }

        [TestMethod("ChangeStatusAsync - Should return exception")]
        [TestCategory("Exception")]
        public async Task ChangeStatus_ShouldReturnException()
        {
            // Arrange
            var factory = new UpdateUserDtoFactory();
            var user = factory.Build();

            try
            {
                // Act
                await _userRepository.ChangeStatusAsync(user.Id, EStatus.Inactive);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ErrorMessageService.GetErrorMessage(EErrorType.NotFound, "User"), ex.Message);
            }
        }
    }
}