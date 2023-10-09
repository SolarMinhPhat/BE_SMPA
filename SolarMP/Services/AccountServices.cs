using Microsoft.EntityFrameworkCore;
using SolarMP.DTOs.Account;
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

        public async Task<Account> register(AccountRegisterDTO dto)
        {
            try
            {
                var account = new Account();
                account.AccountId = "ACC"+Guid.NewGuid().ToString().Substring(0,13);
                account.RoleId = "4" ?? dto.RoleId;
                account.Phone = dto.Phone;
                account.Email = dto.Email;
                account.Username = dto.Username;
                account.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                account.Address = dto.Address;
                account.Gender= dto.Gender;
                account.Firstname = dto.Firstname;
                account.Lastname = dto.Lastname;
                account.Status = true;
                account.CreateAt = DateTime.Now;

                await this.context.Account.AddAsync(account);
                await this.context.SaveChangesAsync();
                
                return account;
            }
            catch(Exception ex)
            {
                if (ex.InnerException.Message.Contains("duplicate"))
                {
                    if (ex.InnerException.Message.Contains("Username"))
                    {
                        throw new Exception("Tên đăng nhập đã tồn tại");
                    }
                    if (ex.InnerException.Message.Contains("Email"))
                    {
                        throw new Exception("Email đã tồn tại");
                    }
                    if (ex.InnerException.Message.Contains("Phone"))
                    {
                        throw new Exception("Số điện thoại đã tồn tại");
                    }
                }
                throw new Exception("Lỗi đăng ký");
            }
        }
    }
}
