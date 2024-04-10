using AccountService.Domain.Enums;
using AccountService.Domain.Filters.Accounts;
using AccountService.Domain.Interfaces.Repositories;
using AccountService.EFConfiguration.Repositories;
using AccountService.Tests.Repositories.Repositories.Base;
using AccountService.Tests.Shared.Factories.Accounts;

namespace AccountService.Tests.Repositories.Repositories
{
    [TestClass]
    public class AccountRepositoryTests : BaseRepositoryTest
    {
        private IAccountRepository _accountRepository;

        public AccountRepositoryTests()
        {
            ConfigureContext();
            _accountRepository = new AccountRepository(_controleFinancasContext);
        }

        [TestMethod]
        public async Task ShouldAddAccount()
        {
            // Arrange
            var account = new AddAccountDtoFactory().Generate();

            // Act
            var accountAdded = await _accountRepository.AddAsync(account);

            // Assert
            Assert.IsNotNull(accountAdded);
            Assert.AreEqual(account.Name, accountAdded.Name);
        }

        [TestMethod]
        public async Task ShouldUpdateAccount()
        {
            // Arrange
            var account = new AddAccountDtoFactory().Generate();
            var accountAdded = await _accountRepository.AddAsync(account);
            var accountToUpdate = new UpdateAccountDtoFactory()
                .WithId(accountAdded.Id)
                .Generate();

            // Act
            var accountUpdated = await _accountRepository.UpdateAsync(accountToUpdate);

            // Assert
            Assert.IsNotNull(accountUpdated);
            Assert.AreEqual(accountToUpdate.Name, accountUpdated.Name);
        }

        [TestMethod]
        public async Task ShouldDeleteAccount()
        {
            // Arrange
            var account = new AddAccountDtoFactory().Generate();
            var accountAdded = await _accountRepository.AddAsync(account);

            // Act
            await _accountRepository.DeleteAsync(accountAdded.Id);

            var accountDeleted = await _accountRepository.GetOneByFilterAsync(new AccountFilter { Id = accountAdded.Id });

            // Assert
            Assert.IsNotNull(accountDeleted);
            Assert.AreEqual(EStatus.Deleted, accountDeleted.Status);
        }
    }
}
