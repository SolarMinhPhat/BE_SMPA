using Microsoft.EntityFrameworkCore;
using SolarMP.Interfaces;
using SolarMP.Models;

namespace SolarMP.Services
{
    public class AccountServices : IAccount
    {
        protected readonly solarMPContext context;
        public AccountServices(solarMPContext context)
        {
            this.context = context;
        }
        public async Task<List<Account>> getAll()
        {
            try
            {
                var account = await this.context.Account
                    .Include(x=>x.Role)
                    .ToListAsync();
                return account;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
