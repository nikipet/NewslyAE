using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;
using NewslyAE.Exceptions;
using NewslyAE.Models;
using NewslyAE.Services.Contracts;
using static NewslyAE.Models.Mapper;

namespace NewslyAE.Controllers
{
    public class EverythingController : Controller
    {

        private readonly IAllArticlesService allArticlesService;

        public EverythingController (IAllArticlesService allArticlesService)
        {
            this.allArticlesService = allArticlesService;
        }
        // GET: EverythingController
        public ActionResult Index()
        { 
            return View(new EverythingWrapper());
        }

        [HttpPost]
        public ActionResult Search(EverythingWrapper everythingWrapper)
        {
            try
            {
                var requestParams = DTOToEverything(everythingWrapper.Request);
                everythingWrapper.Result = allArticlesService.GetEverything(requestParams);
                return View(everythingWrapper);
            }
            catch(EverythingRequestInputException e)
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
