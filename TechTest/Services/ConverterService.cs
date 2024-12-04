using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Text.Json;


//Main service for API calls.

namespace TechTest.Services;

public class ConverterService
{
    private readonly HttpClient _httpClient;

    public ConverterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> NumberConversion(int number)
    {
        var apiAccess = $"https://www.dataaccess.com/webservicesserver/NumberConversion.wso/NumberToWords/JSON/debug?ubiNum={number}";
        
        var response = await _httpClient.GetAsync(apiAccess);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            return "Error- Could not convert number";
        }
        
    }
}