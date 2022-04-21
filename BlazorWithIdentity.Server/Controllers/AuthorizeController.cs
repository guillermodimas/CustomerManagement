using BlazorWithIdentity.Server.Data.DataAccess;
using BlazorWithIdentity.Server.Models;
using BlazorWithIdentity.Shared;
using BlazorWithIdentity.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorWithIdentity.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IProjectData _projectManagementData;

        public AuthorizeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IProjectData projectManagementData)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _projectManagementData = projectManagementData;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters parameters)
        {
            var user = await _userManager.FindByNameAsync(parameters.EmailAddress);
            if (user == null) return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, new AuthenticationProperties()
            {
                IsPersistent = parameters.RememberMe,

                //for messing with server authentication timeout (cookies)
                //    ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(15)

            });



            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters)
        {
            var user = new ApplicationUser { UserName = parameters.EmailAddress, Email = parameters.EmailAddress, FirstName = parameters.FirstName, LastName = parameters.LastName };

            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);

            return await Login(new LoginParameters
            {
                EmailAddress = parameters.EmailAddress,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public UserInfo UserInfo()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            return BuildUserInfo();
        }




        private UserInfo BuildUserInfo()
        {
            if (User.Identity.Name != null)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                return new UserInfo
                {
                    Id = user.Id.ToString(),
                    IsAuthenticated = User.Identity.IsAuthenticated,
                    UserName = User.Identity.Name,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ExposedClaims = User.Claims
                        //Optionally: filter the claims you want to expose to the client
                        //.Where(c => c.Type == "test-claim")
                        .ToDictionary(c => c.Type, c => c.Value)
                };
            }
            else
            {
                return new UserInfo();
            }

        }

        [Authorize]
        [HttpGet]
        public List<UserInfo> AllUsers()
        {
            var userList = new List<UserInfo>();
            var users = _userManager.Users;
            if (users != null)
            {
                foreach (var user in users)
                {
                    userList.Add(new UserInfo
                    {
                        Id = user.Id.ToString(),
                        IsAuthenticated = User.Identity.IsAuthenticated,
                        UserName = User.Identity.Name,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        ExposedClaims = User.Claims.ToDictionary(c => c.Type, c => c.Value)
                    });
                }
            }
            return userList;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var allUsers = AllUsers();
            List<Customer_Profile> result = null;
            try
            {
                result = _projectManagementData.LoadAllCustomers(allUsers);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(result);
            }
        }

      

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer_Profile customer_Profile) 
        {
            _projectManagementData.AddCustomer(customer_Profile);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(Customer_Profile customer_Profile) 
        {
            try
            {
                _projectManagementData.DeleteCustomer(customer_Profile);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditCustomer(Customer_Profile customer_Profile) 
        {
            try
            {
                _projectManagementData.EditCustomer(customer_Profile);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCustomerReps()
        {
            List<Customer_Representatives> result = null;
            try
            {
                result = _projectManagementData.LoadAllCustomerReps();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCustomerRep(Customer_Representatives custRep) //Id (UserID)
        {
            try
            {
                _projectManagementData.AddCustomerRep(custRep);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditCustomerRep(Customer_Representatives custRep) //Id (UserID)
        {
            try
            {
                _projectManagementData.EditCustomerRep(custRep);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteCustomerRep(Customer_Representatives custRep) //Id (UserID)
        {
            try
            {
                _projectManagementData.DeleteCustomerRep(custRep);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    

       
    }
}
