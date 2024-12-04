using Microsoft.AspNetCore.Mvc;
using TechTest.Services;

namespace TechTest.Controllers;

// Controller for http requests.

public class ConverterController : Controller
{
    private readonly ConverterService _converterService;

    public ConverterController(ConverterService converterService)
    {
        _converterService = converterService;
    }

    public IActionResult Index()
    {
        return View("~/Views/Numbers/Index.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> ConvertNumber(int number)
    {
        var words = await _converterService.NumberConversion(number);
        ViewBag.Words = words;
        Console.WriteLine($"Received number: {number}");
        return View("~/Views/Numbers/Index.cshtml");
    }
    
    //ViewBag allows data passing from controller to view?
}