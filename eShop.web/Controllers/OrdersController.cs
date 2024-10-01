using eShop.models;
using static eShop.models.Storage;
using Microsoft.AspNetCore.Mvc;

namespace eShop.web.Controllers;

public class OrdersController : Controller
{
    private List<SalesOrder> _salesOrders = [];
    private readonly IWebHostEnvironment _environment;

    public OrdersController(IWebHostEnvironment environment)
    {
        _environment = environment;
        var path = string.Concat(_environment.WebRootPath, "/data/orders.json");
        GetOrders(path);
    }

    public ActionResult Index()
    {
        return View(_salesOrders);
    }

    private void GetOrders(string path)
    {
        _salesOrders = ReadFromFile(path);
    }
}
