using NewslyAE.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NewslyAE.Exceptions;
using static NewslyAE.Utils.Constants;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace NewslyAE.Utils
{
    public class ApiConnector
    {
        ///Returns list of Articles
      
        public static ArticlesResult GetEverything(EverythingRequest reqParams)
        {
            try {
                var newsApiClient = new NewsApiClient(apiKey);
                var articleresult = newsApiClient.GetEverything(reqParams);
                if (articleresult.Status == Statuses.Ok)
                {
                    return articleresult;
                }
                else
                {
                    throw new ApiResponseException(articleresult.Error.Message);
                }
            } catch (AggregateException e)
            {
                throw new ApiResponseException(e.Message);
            }
        }

        public static ArticlesResult GetTopArticles(TopHeadlinesRequest reqParams)
        {
            try
            {
                var newsApiClient = new NewsApiClient(apiKey);
                var articleresult = newsApiClient.GetTopHeadlines(reqParams);
                if (articleresult.Status == Statuses.Ok)
                {
                    return articleresult;
                }
                else
                {
                    throw new ApiResponseException(articleresult.Error.Message);
                }
            }catch(AggregateException e)
            {
                throw new ApiResponseException(e.Message);
            }
        }
    }
}
