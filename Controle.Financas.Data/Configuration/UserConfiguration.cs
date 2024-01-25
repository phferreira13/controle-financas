using AccountService.Domain.Models;
using AccountService.EFConfiguration.Configuration.Base;

namespace AccountService.EFConfiguration.Configuration
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public new virtual void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("Users");

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
