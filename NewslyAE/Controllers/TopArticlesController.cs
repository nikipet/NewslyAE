using Microsoft.AspNetCore.Mvc;
using NewslyAE.Models.DTOs;
using NewslyAE.Services.Contracts;
using NewslyAE.Models;
using NewsAPI.Models;
using NewslyAE.Exceptions;
using static NewslyAE.Models.Mapper;

namespace NewslyAE.Controllers
    
{
    public class TopArticlesController : Controller
    {
        private readonly ITopArticlesService topArticlesService;

        public TopArticlesController(ITopArticlesService TopArticlesService)
        {
            this.topArticlesService = TopArticlesService;
        }
        // GET: TopArticlesController
        public ActionResult Index()
        {
           
            return View(new TopArticlesWrapper());
        }

        // POST: TopArticlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(TopArticlesWrapper topArticlesWrapper)
        {
            try
            {
                var requestParam = DTOToHeadline(topArticlesWrapper.Request);
                topArticlesWrapper.Result = topArticlesService.GetTopArticles(requestParam);
                return View(topArticlesWrapper);
            }
            catch (TopArticlesReguestInputException e)
            {
                var Error = new ErrorViewModel
                {
                    RequestId = e.Message
                };
                return View("Error", Error);
            }
            catch (ApiResponseException e)
            {
                var Error = new ErrorViewModel
                {
                    RequestId = e.Message
                };
                return View("Error", Error);
            }
        }
       

    }
}
