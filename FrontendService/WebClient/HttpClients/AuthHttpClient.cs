using Administration.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.HttpClients
{
    public class AuthHttpClient
    {
        private readonly HttpClient _httpClient;

        public AuthHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserViewModel> Login([FromBody]LoginViewModel loginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/Account/Login", loginViewModel);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadFromJsonAsync<UserViewModel>();
                return jsonData;
            }
            throw new Exception("Login failed. Please check your email/username and password and try again.");

        }
    }
}
