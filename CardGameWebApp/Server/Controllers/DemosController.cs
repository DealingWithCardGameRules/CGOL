using CardGameWebApp.Shared;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CardGameWebApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemosController : Controller
    {
        [HttpGet]
        public DemoList Index()
        {
            var demos = new DemoList(Request.GetEncodedUrl());
            demos.Links.Add("Draw one play one", Url.Action("create", "demos", new { game = "d1p1" }, Request.Scheme));
            return demos;
        }

        [HttpGet("{game}")]
        public IActionResult Create(string game)
        {
            return Ok();
        }
    }
}
