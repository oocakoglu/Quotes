using Microsoft.AspNetCore.Mvc;
using QuotesDemo.WebUI.Attribute;
using System.Runtime.InteropServices;

namespace QuotesDemo.WebUI.Controllers
{

    [Auth]
    public class BaseController : Controller
    {

    }
}
