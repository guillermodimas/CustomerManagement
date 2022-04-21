using BlazorWithIdentity.Shared;
using BlazorWithIdentity.Shared.Models;

namespace BlazorWithIdentity.Client.Services.Implementations
{
    public interface IAuthorizeApi
    {
        Task AddCustomer(Customer_Profile customer);
        Task AddCustomerRep(Customer_Representatives custRep);
        Task DeleteCustomer(Customer_Profile customer);
        Task DeleteCustomerRep(Customer_Representatives custRep);
        Task EditCustomer(Customer_Profile customer);
        Task EditCustomerRep(Customer_Representatives custRep);
        Task<List<Customer_Representatives>> GetAllCustomerReps();
        Task<List<Customer_Profile>> GetAllCustomers();
        Task<List<UserInfo>> GetAllUsers();
        Task<UserInfo> GetUserInfo();
        Task Login(LoginParameters loginParameters);
        Task Logout();
        Task Register(RegisterParameters registerParameters);
    }
}