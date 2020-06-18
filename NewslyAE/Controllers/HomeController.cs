using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsAPI.Models;
using NewslyAE.Models;
using NewslyAE.Models.DTOs;
using NewslyAE.Services.Contracts;
using static NewslyAE.Utils.Constants;

namespace NewslyAE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITopArticlesService topArticlesService;

        public HomeController(ILogger<HomeController> logger, ITopArticlesService TopArticlesService)
        {
            _logger = logger;
            this.topArticlesService = TopArticlesService;

        }

        public IActionResult Index()
        {
            TopArticlesWrapper homePageExample = new TopArticlesWrapper();
            TopHeadlinesRequest homepageRequest = new TopHeadlinesRequest
            {
                Q = KEYWORDS_OF_THE_DAY,
                Page = EXAMPLE_PAGE,
                PageSize = EXAMPLE_PAGESIZE,
                Language = NewsAPI.Constants.Languages.EN

            };
            homePageExample.Result = topArticlesService.GetTopArticles(homepageRequest);
            ViewBag.Keywords = KEYWORDS_OF_THE_DAY;
            return View(homePageExample);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
