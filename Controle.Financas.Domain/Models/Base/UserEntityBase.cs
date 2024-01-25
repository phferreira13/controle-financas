namespace AccountService.Domain.Models.Base
{
    public abstract class UserEntityBase : EntityBase
    {
        public int? UserId { get; private set; }
        public virtual User? User { get; set; }

        public UserEntityBase() { }

        public UserEntityBase(int userId)
        {
            UserId = userId;
        }
    }
}
