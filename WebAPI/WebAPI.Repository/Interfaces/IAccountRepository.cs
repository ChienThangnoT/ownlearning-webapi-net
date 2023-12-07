using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Data;

namespace WebAPI.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<AccountModel>> GetAllAccount();
        public Task<AccountModel> GetById(int id);
        public Task<AccountModel> Add(AccountModel account);
        public Task<AccountModel> Update(AccountModel account);
        public Task<AccountModel> Delete(int id);
    }
}
