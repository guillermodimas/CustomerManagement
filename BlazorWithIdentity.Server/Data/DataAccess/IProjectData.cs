using BlazorWithIdentity.Shared;
using BlazorWithIdentity.Shared.Models;

namespace BlazorWithIdentity.Server.Data.DataAccess
{
    public interface IProjectData
    {
        void AddCustomer(Customer_Profile customer);
        void AddCustomerRep(Customer_Representatives custRep);
        void DeleteCustomer(Customer_Profile customer);
        void DeleteCustomerRep(Customer_Representatives custRep);
        void EditCustomer(Customer_Profile customer);
        void EditCustomerRep(Customer_Representatives custRep);
        List<Customer_Representatives> LoadAllCustomerReps();
        List<Customer_Profile> LoadAllCustomers(List<UserInfo> allUsers);
    }
}