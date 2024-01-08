using Controle.Financas.Domain.Enums;
using Controle.Financas.EFConfiguration.Repositories;
using Controle.Financas.Shared.Enums;
using Controle.Financas.Shared.Services;
using Controle.Financas.Tests.Repositories.Repositories.Base;
using Controle.Financas.Tests.Shared.Factories.AccountType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Tests.Repositories.Repositories
{
    [TestClass]
    public class AccountTypeRepositoryTests : BaseRepositoryTest
    {
        private AccountTypeRepository _accountTypeRepository;

        [TestInitialize]
        public void ResetDatabase()
        {
            ConfigureContext();
            _accountTypeRepository = new AccountTypeRepository(_controleFinancasContext);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldAddAccountType()
        {
            // Arrange
            var accountType = new AddAccountTypeDtoFactory().Generate();

            // Act
            var accountTypeAdded = await _accountTypeRepository.AddAsync(accountType);

            // Assert
            Assert.IsNotNull(accountTypeAdded);
            Assert.AreEqual(accountType.Name, accountTypeAdded.Name);
            Assert.AreEqual(accountType.UserId, accountTypeAdded.UserId);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldUpdateAccountType()
        {
            // Arrange
            var accountType = new AddAccountTypeDtoFactory().Generate();
            var accountTypeAdded = await _accountTypeRepository.AddAsync(accountType);
            var accountTypeUpdated = new UpdateAccountTypeDtoFactory().WithId(accountTypeAdded.Id).Generate();

            // Act
            var accountTypeUpdatedResult = await _accountTypeRepository.UpdateAsync(accountTypeUpdated);

            // Assert
            Assert.IsNotNull(accountTypeUpdatedResult);
            Assert.AreEqual(accountTypeUpdated.Name, accountTypeUpdatedResult.Name);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldDeleteAccountType()
        {
            // Arrange
            var accountType = new AddAccountTypeDtoFactory().Generate();
            var accountTypeAdded = await _accountTypeRepository.AddAsync(accountType);

            // Act
            await _accountTypeRepository.DeleteAsync(accountTypeAdded.Id);
            var accountTypeDeleted = await _accountTypeRepository.GetByIdAsync(accountTypeAdded.Id);

            // Assert
            Assert.IsNotNull(accountTypeDeleted);
            Assert.AreEqual(EStatus.Deleted, accountTypeDeleted.Status);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldGetAccountTypeById()
        {
            // Arrange
            var accountType = new AddAccountTypeDtoFactory().Generate();
            var accountTypeAdded = await _accountTypeRepository.AddAsync(accountType);

            // Act
            var accountTypeGetById = await _accountTypeRepository.GetByIdAsync(accountTypeAdded.Id);

            // Assert
            Assert.IsNotNull(accountTypeGetById);
            Assert.AreEqual(accountTypeAdded.Id, accountTypeGetById.Id);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldGetAccountTypeByUserId()
        {
            // Arrange
            var accountType = new AddAccountTypeDtoFactory().Generate();
            var accountTypeAdded = await _accountTypeRepository.AddAsync(accountType);

            // Act
            var accountTypeGetByUserId = await _accountTypeRepository.GetByUserIdAsync(accountTypeAdded.UserId.Value);

            // Assert
            Assert.IsNotNull(accountTypeGetByUserId);
            Assert.AreEqual(accountTypeAdded.UserId, accountTypeGetByUserId.UserId);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldGetAllAccountTypes()
        {
            // Arrange
            var newAccountTypes = new AddAccountTypeDtoFactory().Generate(10);
            foreach (var accountType in newAccountTypes)
            {
                await _accountTypeRepository.AddAsync(accountType);
            }

            // Act
            var accountTypes = await _accountTypeRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(accountTypes);
            Assert.IsTrue(accountTypes.Any());
            Assert.AreEqual(10, accountTypes.Count());
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldGetAccountTypeById_ReturnNull()
        {
            // Arrange

            // Act
            var accountTypeGetById = await _accountTypeRepository.GetByIdAsync(1);

            // Assert
            Assert.IsNull(accountTypeGetById);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldGetAccountTypeByUserId_ReturnNull()
        {
            // Arrange

            // Act
            var accountTypeGetByUserId = await _accountTypeRepository.GetByUserIdAsync(1);

            // Assert
            Assert.IsNull(accountTypeGetByUserId);
        }

        [TestMethod]
        [TestCategory("Success")]
        public async Task ShouldGetAllAccountTypes_ReturnEmpty()
        {
            // Arrange

            // Act
            var accountTypes = await _accountTypeRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(accountTypes);
            Assert.IsFalse(accountTypes.Any());
        }

        [TestMethod]
        [TestCategory("Exception")]
        public async Task ShouldUpdateAccountType_ThrowException()
        {
            // Arrange
            var accountType = new UpdateAccountTypeDtoFactory().Generate();

            try
            {
                // Act
                await _accountTypeRepository.UpdateAsync(accountType);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ErrorMessageService.GetErrorMessage(EErrorType.NotFound, "AccountType"), ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Exception")]
        public async Task ShouldDeleteAccountType_ThrowException()
        {
            // Arrange

            try
            {
                // Act
                await _accountTypeRepository.DeleteAsync(1);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(ErrorMessageService.GetErrorMessage(EErrorType.NotFound, "AccountType"), ex.Message);
            }
        }

    }
}
