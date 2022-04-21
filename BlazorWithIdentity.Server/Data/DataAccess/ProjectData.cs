using BlazorWithIdentity.Client.Pages;
using BlazorWithIdentity.Server.Data.Internal;
using BlazorWithIdentity.Shared;
using BlazorWithIdentity.Shared.Models;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorWithIdentity.Server.Data.DataAccess
{
    public class ProjectData : IProjectData
    {
        private readonly ISQLDataAccess _sQLDataAccess;
        private readonly ILogger<ProjectData> _logger;

        public ProjectData(ISQLDataAccess sQLDataAccess, ILogger<ProjectData> logger)
        {
            _sQLDataAccess = sQLDataAccess;
            _logger = logger;
        }

        public List<Customer_Profile> LoadAllCustomers(List<UserInfo> allUsers)
        {
            try
            {
                return _sQLDataAccess.LoadData<Customer_Profile, dynamic>("dbo.spLoadAllCustomers", new { }, "DefaultConnection");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }




        public void AddCustomer(Customer_Profile customer)
        {
            try
            {
                _sQLDataAccess.SaveData("dbo.spAddCustomer", new { customer.BusinessName, customer.Address, customer.StartDate, customer.EndDate }, "DefaultConnection");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public void DeleteCustomer(Customer_Profile customer)
        {
            try
            {
                _sQLDataAccess.SaveData("dbo.spDeleteCustomer", new { customer.CustomerID }, "DefaultConnection");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void EditCustomer(Customer_Profile customer)
        {
            try
            {
                _sQLDataAccess.SaveData("dbo.spEditCustomer", customer, "DefaultConnection");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public List<Customer_Representatives> LoadAllCustomerReps()
        {
            try
            {
                //display ALL cust reps
                return _sQLDataAccess.LoadData<Customer_Representatives, dynamic>("dbo.spLoadAllCustomerReps", new { }, "DefaultConnection");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }



        }
        public void AddCustomerRep(Customer_Representatives custRep)
        {
            try
            {
                _sQLDataAccess.SaveData("dbo.spAddCustomerRep", new { custRep.First_Name, custRep.Last_Name, custRep.Address, custRep.Email, custRep.StartDate, custRep.EndDate, custRep.ActiveInd,  custRep.CustomerID }, "DefaultConnection");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public void EditCustomerRep(Customer_Representatives custRep)
        {
            try
            {
                _sQLDataAccess.SaveData("dbo.spEditCustomerRep", new { custRep.CustomerRepID, custRep.First_Name, custRep.Last_Name, custRep.Address, custRep.Email, custRep.StartDate, custRep.EndDate, custRep.ActiveInd , custRep.CustomerID }, "DefaultConnection");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public void DeleteCustomerRep(Customer_Representatives custRep)
        {
            try
            {
                _sQLDataAccess.SaveData("dbo.spDeleteCustomerRep", new { custRep.CustomerRepID }, "DefaultConnection");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }




    }
}
