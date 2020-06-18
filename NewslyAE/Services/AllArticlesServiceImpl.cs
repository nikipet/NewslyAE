using NewsAPI.Models;
using NewslyAE.Exceptions;
using NewslyAE.Services.Contracts;
using NewslyAE.Utils;
using static NewslyAE.Utils.Constants;

namespace NewslyAE.Services
{
    public class AllArticlesServiceImpl : IAllArticlesService
    {
       

        public ArticlesResult GetEverything(EverythingRequest requestParams)
        {
            ValidateParams(requestParams);
            var result = ApiConnector.GetEverything(requestParams);
            //Limits the description of each article to 250 characters
            foreach (var article in result.Articles)
            {
                if (!(article.Description is null) && article.Description.Length > 250)
                {
                    article.Description = article.Description.Substring(0, 250) + "...";
                }
            }
            return result;
        }

        private void ValidateParams(EverythingRequest requestParams)
        {
            if(requestParams.Domains.Count==0 &&
               requestParams.Q is null &&
               requestParams.Sources.Count==0)
            {
                throw new EverythingRequestInputException(EVERYTHING_REQUEST_MISSING_INFO_MESSAGE);
            }
            if (requestParams.PageSize <= 0 || requestParams.PageSize > 100)
            {
                throw new EverythingRequestInputException(PAGE_SIZE_VIOLATION);
            }
            if (requestParams.Page <= 0)
            {
                throw new EverythingRequestInputException(PAGE_NUMBER_VIOLATION);
            }
        }
    }
}
