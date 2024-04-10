using AccountService.Domain.Enums;
using AccountService.EFConfiguration.Repositories;
using AccountService.Shared.Enums;
using AccountService.Shared.Services;
using AccountService.Tests.Repositories.Repositories.Base;
using AccountService.Tests.Shared.Factories.Users;

namespace AccountService.Tests.Repositories.Repositories
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

            var deleted = await _userRepository.DeleteUserAsync(created.Id);

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