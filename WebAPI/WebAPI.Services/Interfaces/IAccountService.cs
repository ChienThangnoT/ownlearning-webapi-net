using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Models;

namespace WebAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<TblAccount> SignUpAsync(TblAccount account);
        Task<TblAccount> SignInAsync(TblAccount account);
    }
}
