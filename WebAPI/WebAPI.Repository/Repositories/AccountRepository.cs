using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository.Data;
using WebAPI.Repository.Interfaces;
using WebAPI.Repository.Models;

namespace WebAPI.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AllActorsFemaleInJapanContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(AllActorsFemaleInJapanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountModel> Add(AccountModel account)
        {
            TblAccount newAccount = _mapper.Map<TblAccount>(account);
            //var accountModel = new AccountModel
            //{
            //    AccountName = account.AccountName,
            //    AccountEmail = account.AccountEmail,
            //    AccountImg = account.AccountImg,
            //    AccountPhone = account.AccountPhone,
            //    AccountPassword = account.AccountPassword,
            //    Biography = account.Biography,
            //    SocialId = account.SocialId,
            //    CreateDate = account.CreateDate,
            //    RoleId = account.RoleId,
            //    AccountIsActive = account.AccountIsActive
            //};
            _context.Add(newAccount);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountModel>(newAccount);
            //return new AccountModel
            //{
            //    AccountId = account.AccountId,
            //    AccountName = account.AccountName,
            //    AccountEmail = account.AccountEmail,
            //    AccountImg = account.AccountImg,
            //    AccountPhone = account.AccountPhone,
            //    AccountPassword = account.AccountPassword,
            //    Biography = account.Biography,
            //    SocialId = account.SocialId,
            //    CreateDate = account.CreateDate,
            //    RoleId = account.RoleId,
            //    AccountIsActive = account.AccountIsActive
            //};
        }

        public async Task<AccountModel> Delete(int id)
        {
            var account = _context.TblAccounts.FirstOrDefault(x => x.AccountId == id);
            if (account != null)
            {
                _context.Remove(account);
                await _context.SaveChangesAsync();
                return new AccountModel();
            }
            return null;
        }


        public async Task<List<AccountModel>> GetAllAccount()
        {
            var accounts =  _context.TblAccounts.Select(x => new AccountModel
            {
                AccountName = x.AccountName,
                AccountEmail = x.AccountEmail,
                AccountPhone = x.AccountPhone,
                AccountImg = x.AccountImg,
                CreateDate = x.CreateDate
            });
            return await accounts.ToListAsync();
        }


        public async Task<AccountModel?> GetById(int id)
        {
            var account = _context.TblAccounts.FirstOrDefault(x => x.AccountId == id);
            if (account != null)
            {
                return _mapper.Map<AccountModel>(account);
                //return new AccountModel
                //{
                //    AccountId = account.AccountId,
                //    AccountEmail = account.AccountEmail,
                //    AccountPhone = account.AccountPhone,
                //    AccountImg = account.AccountImg,
                //    CreateDate = account.CreateDate
                //};
            }
            return null;
        }

        public async Task<AccountModel?> Update(AccountModel account)
        {
            var _account = _context.TblAccounts.FirstOrDefault(x => x.AccountId == account.AccountId);
            if (_account != null)
            {
                _account.AccountEmail = account.AccountEmail;
                _account.AccountPhone = account.AccountPhone;
                _account.AccountName = account.AccountName;
                _account.Biography = account.Biography;
                _account.AccountIsActive = account.AccountIsActive;
                _account.AccountImg = account.AccountImg;
                _account.CreateDate = account.CreateDate;
                _account.AccountPassword = account.AccountPassword;
                _account.RoleId = account.RoleId;
                _account.SocialId = account.SocialId;
                _account.AccountId = account.AccountId;

                _context.Update(_account);
                await _context.SaveChangesAsync();

                return _mapper.Map<AccountModel>(account);
                //return new AccountModel
                //{
                //    AccountId = _account.AccountId,
                //    AccountEmail = _account.AccountEmail,
                //    AccountPhone = _account.AccountPhone,
                //    AccountName = _account.AccountName,
                //    Biography = _account.Biography,
                //    AccountIsActive = _account.AccountIsActive
                //};
            }
            return null;
        }

    }
}
