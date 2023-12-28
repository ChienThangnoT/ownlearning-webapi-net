using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository.Data;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public  AccountController(IAccountRepository accountRepository) {
            _accountRepository = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpModel signUpModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountRepository.SignUpAccountAsync(signUpModel);
                    if (result.Status.Equals("Success"))
                    {
                        return Ok(result);   
                    }
                    return BadRequest(result);
                }
                return ValidationProblem(ModelState);
            }
            catch { return BadRequest(); }
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInModel signInModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountRepository.SignInAccountAsync(signInModel);
                    if (string.IsNullOrEmpty(result))
                    {
                        return Unauthorized();
                    }
                    return Ok(result);
                }
                return ValidationProblem(ModelState);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}


//[HttpGet("{id}")]
//public async Task<ActionResult<AccountModel>> GetAccountById(int id)
//{
//    try
//    {
//        var data = await _accountRepository.GetById(id);
//        if (data != null)
//        {
//            return Ok(data);
//        }
//        else
//        {
//            return NotFound();
//        }
//    } catch
//    {
//        return StatusCode(StatusCodes.Status500InternalServerError);
//    }
//}

//[HttpPut("{id}")]
//public async Task<ActionResult<AccountModel>> UpdateAccount(int id, AccountModel model)
//{
//    if (id != model.AccountId)
//    {
//        return BadRequest();
//    }
//    try
//    {
//        await _accountRepository.Update(model);
//        return NoContent();
//    } catch
//    {
//        return StatusCode(StatusCodes.Status500InternalServerError);
//    }
//}

//[HttpDelete("{id}")]
//public async Task<ActionResult<AccountModel>> DeleteAccount(int id)
//{
//    try
//    {
//        await _accountRepository.Delete(id);
//        return Ok();
//    }
//    catch
//    {
//        return StatusCode(StatusCodes.Status500InternalServerError);
//    }
//}

//[HttpPost]
//public async Task<ActionResult<AccountModel>> AddAccount(AccountModel account)
//{
//    try
//    {
//         return Ok(await _accountRepository.Add(account));
//    }
//    catch
//    {
//        return StatusCode(StatusCodes.Status500InternalServerError);
//    }
//}