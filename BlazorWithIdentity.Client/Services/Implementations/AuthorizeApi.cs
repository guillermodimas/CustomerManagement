using BlazorWithIdentity.Client.Pages;
using BlazorWithIdentity.Client.Services;
using BlazorWithIdentity.Shared;
using BlazorWithIdentity.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorWithIdentity.Client.Services.Implementations
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;

        public AuthorizeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Login(LoginParameters loginParameters)
        {
            //var stringContent = new StringContent(JsonSerializer.Serialize(loginParameters), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/Login", loginParameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/Authorize/Logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterParameters registerParameters)
        {
            //var stringContent = new StringContent(JsonSerializer.Serialize(registerParameters), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsJsonAsync("api/Authorize/Register", registerParameters);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<UserInfo> GetUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<UserInfo>("api/Authorize/UserInfo");
            return result;
        }

        public async Task<List<UserInfo>> GetAllUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserInfo>>("api/Authorize/AllUsers");
            return result;
        }
        public async Task<List<Customer_Profile>> GetAllCustomers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Customer_Profile>>("api/Authorize/GetCustomers");
            return result;
        }
        public async Task AddCustomer(Customer_Profile customer)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Authorize/AddCustomer", customer);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task DeleteCustomer(Customer_Profile customer)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Authorize/DeleteCustomer", customer);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task EditCustomer(Customer_Profile customer)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Authorize/EditCustomer", customer);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task<List<Customer_Representatives>> GetAllCustomerReps()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Customer_Representatives>>("api/Authorize/GetCustomerReps");
            return result;
        }

        public async Task AddCustomerRep(Customer_Representatives custRep)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Authorize/AddCustomerRep", custRep);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }


        public async Task EditCustomerRep(Customer_Representatives custRep)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Authorize/EditCustomerRep", custRep);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }
        public async Task DeleteCustomerRep(Customer_Representatives custRep)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Authorize/DeleteCustomerRep", custRep);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }



    }
}
