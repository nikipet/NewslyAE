using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewslyAE.Models;
using NewslyAE.Models.DTOs;
using NewslyAE.Services.Contracts;
using static NewslyAE.Utils.Constants;
using static NewslyAE.Utils.ApiConnector;
using NewslyAE.Utils;
using NewsAPI.Models;
using NewslyAE.Exceptions;

namespace NewslyAE.Services
{
    public class TopArticlesServiceImpl : ITopArticlesService
    {
        

        public ArticlesResult GetTopArticles(TopHeadlinesRequest requestParam)
        {
            ValidateParams(requestParam);
            var result= ApiConnector.GetTopArticles(requestParam);
            //Limits the description of each article to 250 characters
            foreach (var article in result.Articles)
            {
                if (!(article.Description is null)&& article.Description.Length > 250)
                {
                    article.Description = article.Description.Substring(0, 250) + "...";
                }
            }
            return result;

        }

        private void ValidateParams(TopHeadlinesRequest requestParams)
        {
            if(!(requestParams.Sources.Count ==0))
            {
                if(!(requestParams.Country is null)||!(requestParams.Category is null))
                {
                    throw new TopArticlesReguestInputException(TOP_ARTICLES_PARAM_COMBINATION_ERROR);
                }
            }
            if(requestParams.Sources is null &&
               requestParams.Q is null &&
               requestParams.Language is null &&
               requestParams.Country is null &&
               requestParams.Category is null)
            {
                throw new TopArticlesReguestInputException(TOP_ARTICLES_MISSING_INPUT_MESSAGE);
            }
            if(requestParams.PageSize<=0||requestParams.PageSize>100)
            {
                throw new TopArticlesReguestInputException(PAGE_SIZE_VIOLATION);
            }
            if (requestParams.Page <= 0 )
            {
                throw new TopArticlesReguestInputException(PAGE_NUMBER_VIOLATION);
            }
        }

    }
}
