using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        private readonly IConfiguration configuration;
        private readonly SignInManager<TblAccount> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<TblAccount> userManager;

        public AccountRepository(
            AllActorsFemaleInJapanContext context,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<TblAccount> userManager,
            SignInManager<TblAccount> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._context = context;
            this._mapper = mapper;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<string> SignInAccountAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.AccountEmail, model.AccountPassword, false, false);

            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.AccountEmail);

                if (user != null)
                {
                    var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.AccountEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                    var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

                    var token = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidateIssuer"],
                        audience: configuration["JWT:ValidateAudience"],
                        expires: DateTime.Now.AddHours(2),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                    );

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    // Handle the case where the user is not found
                    return null;
                }
            }
            else
            {
                // Handle the case where the sign-in failed
                return null;
            }
        }


        public async Task<ResponeModel> SignUpAccountAsync(SignUpModel model)
        {
            var exsistAccount = await userManager.FindByEmailAsync(model.AccountEmail);
            if (exsistAccount == null)
            {
                var user = new TblAccount
                {
                    AccountName = model.AccountName,
                    AccountEmail = model.AccountEmail,
                    AccountPhone = model.AccountPhone,
                    AccountIsActive = true,
                    UserName = model.AccountEmail
                };
                var result = await userManager.CreateAsync(user, model.AccountPassword);
                string errorMessage = null;
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync(RoleModel.User.ToString()))
                    {
                        await roleManager.CreateAsync(new IdentityRole(RoleModel.User.ToString()));
                    }
                    if (await roleManager.RoleExistsAsync(RoleModel.User.ToString()))
                    {
                        await userManager.AddToRoleAsync(user, RoleModel.User.ToString());
                    }
                    var token = userManager.GenerateEmailConfirmationTokenAsync(user);
                    return new ResponeModel { Status = "Success", Message = "Create account successfull" };
                }
                foreach (var ex in result.Errors)
                {
                    errorMessage = ex.Description;
                }
                return new ResponeModel { Status = "Error", Message = errorMessage };
            }
            return new ResponeModel { Status = "Hihi", Message = "Account already exist" };
        }
    }
}


//public async Task<AccountModel> Add(AccountModel account)
//{
//    TblAccount newAccount = _mapper.Map<TblAccount>(account);
//    var accountModel = new AccountModel
//    {
//        AccountName = account.AccountName,
//        AccountEmail = account.AccountEmail,
//        AccountImg = account.AccountImg,
//        AccountPhone = account.AccountPhone,
//        AccountPassword = account.AccountPassword,
//        Biography = account.Biography,
//        SocialId = account.SocialId,
//        CreateDate = account.CreateDate,
//        RoleId = account.RoleId,
//        AccountIsActive = account.AccountIsActive
//    };
//    _context.Add(newAccount);
//    await _context.SaveChangesAsync();
//    return _mapper.Map<AccountModel>(newAccount);
//    return new AccountModel
//    {
//        AccountId = account.AccountId,
//        AccountName = account.AccountName,
//        AccountEmail = account.AccountEmail,
//        AccountImg = account.AccountImg,
//        AccountPhone = account.AccountPhone,
//        AccountPassword = account.AccountPassword,
//        Biography = account.Biography,
//        SocialId = account.SocialId,
//        CreateDate = account.CreateDate,
//        RoleId = account.RoleId,
//        AccountIsActive = account.AccountIsActive
//    };
//}

//public async Task<AccountModel> Delete(int id)
//{
//    var account = _context.TblAccounts.FirstOrDefault(x => x.AccountId == id);
//    if (account != null)
//    {
//        _context.Remove(account);
//        await _context.SaveChangesAsync();
//        return new AccountModel();
//    }
//    return null;
//}


//public async Task<List<AccountModel>> GetAllAccount()
//{
//    var accounts =  _context.TblAccounts.Select(x => new AccountModel
//    {
//        AccountName = x.AccountName,
//        AccountEmail = x.AccountEmail,
//        AccountPhone = x.AccountPhone,
//        AccountImg = x.AccountImg,
//        CreateDate = x.CreateDate
//    });
//    return await accounts.ToListAsync();
//}


//public async Task<AccountModel?> GetById(int id)
//{
//    var account = _context.TblAccounts.FirstOrDefault(x => x.AccountId == id);
//    if (account != null)
//    {
//        return _mapper.Map<AccountModel>(account);
//        return new AccountModel
//        {
//            AccountId = account.AccountId,
//            AccountEmail = account.AccountEmail,
//            AccountPhone = account.AccountPhone,
//            AccountImg = account.AccountImg,
//            CreateDate = account.CreateDate
//        };
//    }
//    return null;
//}

//public async Task<AccountModel?> Update(AccountModel account)
//{
//    var _account = _context.TblAccounts.FirstOrDefault(x => x.AccountId == account.AccountId);
//    if (_account != null)
//    {
//        _account.AccountEmail = account.AccountEmail;
//        _account.AccountPhone = account.AccountPhone;
//        _account.AccountName = account.AccountName;
//        _account.Biography = account.Biography;
//        _account.AccountIsActive = account.AccountIsActive;
//        _account.AccountImg = account.AccountImg;
//        _account.CreateDate = account.CreateDate;
//        _account.AccountPassword = account.AccountPassword;
//        _account.RoleId = account.RoleId;
//        _account.SocialId = account.SocialId;
//        _account.AccountId = account.AccountId;

//        _context.Update(_account);
//        await _context.SaveChangesAsync();

//        return _mapper.Map<AccountModel>(account);
//        return new AccountModel
//        {
//            AccountId = _account.AccountId,
//            AccountEmail = _account.AccountEmail,
//            AccountPhone = _account.AccountPhone,
//            AccountName = _account.AccountName,
//            Biography = _account.Biography,
//            AccountIsActive = _account.AccountIsActive
//        };
//    }
//    return null;
//}