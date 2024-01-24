using Controle.Financas.Domain.Enums;
using Controle.Financas.Domain.Interfaces.Repositories;
using Controle.Financas.EFConfiguration.Repositories;
using Controle.Financas.Tests.Repositories.Repositories.Base;
using Controle.Financas.Tests.Shared.Factories.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Tests.Repositories.Repositories
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
        public async Task ShouldReturnAccountById()
        {
            // Arrange
            var factory = new AddAccountDtoFactory();
            var account = factory.Generate();
            
            var added = await _accountRepository.AddAsync(account);

            // Act
            var result = await _accountRepository.GetByIdAsync(added.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(added.Id, result.Id);
        }

        [TestMethod]
        public async Task ShouldReturnAllAccounts()
        {
            // Arrange
            var factory = new AddAccountDtoFactory();
            foreach (var item in factory.Generate(10))
            {
                await _accountRepository.AddAsync(item);
            }

            // Act
            var accounts = await _accountRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(accounts);
            Assert.AreEqual(10, accounts.Count());
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

            var accountDeleted = await _accountRepository.GetByIdAsync(accountAdded.Id);

            // Assert
            Assert.IsNotNull(accountDeleted);
            Assert.AreEqual(EStatus.Deleted, accountDeleted.Status);
        }
    }
}
