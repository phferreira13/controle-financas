using AccountService.Domain.Enums;
using AccountService.Domain.Filters.AccountTypes;
using AccountService.EFConfiguration.Repositories;
using AccountService.Shared.Enums;
using AccountService.Shared.Services;
using AccountService.Tests.Repositories.Repositories.Base;
using AccountService.Tests.Shared.Factories.AccountTypes;

namespace AccountService.Tests.Repositories.Repositories
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
        public async Task ShouldGetAccountTypeById()
        {
            // Arrange
            var accountType = new AddAccountTypeDtoFactory().Generate();
            var accountTypeAdded = await _accountTypeRepository.AddAsync(accountType);
            var filter = new AccountTypeFilterFactory().WithId(accountTypeAdded.Id).Generate();

            // Act
            var accountTypeGetById = await _accountTypeRepository.GetOneByFilterAsync(filter);

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

            var filter = new AccountTypeFilterFactory().WithUserId(accountTypeAdded.UserId.Value).Generate();

            // Act
            var accountTypeGetByUserId = await _accountTypeRepository.GetOneByFilterAsync(filter);

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
            var accountTypes = await _accountTypeRepository.GetAllByFilterAsync(new AccountTypeFilter());

            // Assert
            Assert.IsNotNull(accountTypes);
            Assert.IsTrue(accountTypes.Any());
            Assert.AreEqual(10, accountTypes.Count());
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
