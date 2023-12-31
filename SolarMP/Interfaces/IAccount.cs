﻿using SolarMP.DTOs.Account;
using SolarMP.Models;

namespace SolarMP.Interfaces
{
    public interface IAccount
    {
        Task<List<Account>> getAll();
        Task<Account> register(AccountRegisterDTO dto);
        Task<Account> delete(string id);
        Task<Account> deleteHardCode(string id);
        Task<List<Account>> getByName(string name);
        Task<Account> getById(string id);
        Task<Account> update(AccountUpdateDTO dto);
    }
}
