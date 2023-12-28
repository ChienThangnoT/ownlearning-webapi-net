using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Interfaces;
using WebAPI.Repository.Models;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services.Services
{
    public class AccountService : IAccountService
    {

        public AccountService(IAccountRepository repo) { }
        public async Task<TblAccount> SignInAsync(TblAccount account)
        {
            throw new NotImplementedException();
        }

        public async Task<TblAccount> SignUpAsync(TblAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
