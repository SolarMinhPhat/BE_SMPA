using SolarMP.DTOs.Account;
using SolarMP.Models;

namespace SolarMP.Interfaces
{
    public interface IAccount
    {
        Task<List<Account>> getAll();
        Task<Account> register(AccountRegisterDTO dto);
    }
}
