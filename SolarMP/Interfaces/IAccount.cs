using SolarMP.Models;

namespace SolarMP.Interfaces
{
    public interface IAccount
    {
        Task<List<Account>> getAll();
    }
}
