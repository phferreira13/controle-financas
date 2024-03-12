using AccountService.Domain.Models.Base;

namespace AccountService.EFConfiguration.Configuration.Base
{
    public abstract class UserEntityBaseConfiguration<T> : EntityBaseConfiguration<T> where T : UserEntityBase
    {
        public new virtual void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UserId).IsRequired(false);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
