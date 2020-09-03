using sportlife.Models;

namespace sportlife.Services
{
    public class AccountService
    {
        private Account account;

        public AccountService(Account account)
        {
            this.account = account;
        }

        public int TotalBalance()
        {
            return account.Points;
        }

        public void TopUp(int amount)
        { }

        public void Pay(Service service)
        { }
    }
}