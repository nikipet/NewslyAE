using NewsAPI.Constants;
using NewsAPI.Models;
using NewslyAE.Exceptions;
using NewslyAE.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Models
{
    public class Mapper
    {
        private const string NO_SUCH_CATEGORY = "Unreconginzed category {0}";
        const string NO_SUCH_COUNTRY_CODE = "Unreconginzed country code {0}";
        private const string NO_SUCH_LANGUAGE_CODE = "Unreconginzed language code {0}";
        private const string NO_SUCH_SORT_BY = "Unreconginzed Sort By paramter {0}";

        public static TopHeadlinesRequest DTOToHeadline(TopArticlesParamsDTO requestParamsDTO)
        {
            TopHeadlinesRequest requestParam = new TopHeadlinesRequest();
            requestParam.Q = requestParamsDTO.Keywords;
            requestParam.Page = requestParamsDTO.Page;
            requestParam.PageSize = requestParamsDTO.PageSize;
            if (!(requestParamsDTO.Sources is null)) {
                requestParam.Sources = requestParamsDTO.Sources.Split(",").ToList();
            }
            if (!(requestParamsDTO.Category is null))
            {
                ///If the user doesnt select one of the options,
                ///it converts the user input to string with beggining capital letter
                ///followed only by lower case letters 
                string userInputCat = requestParamsDTO.Category.ToLower().Substring(1);
                string firstLetter = requestParamsDTO.Category[0].ToString().ToUpper();
                userInputCat = firstLetter + userInputCat;
                if (Enum.TryParse(userInputCat, out Categories category)) {
                    requestParam.Category = category;
                } else {
                    throw new TopArticlesReguestInputException(string.Format(
                        NO_SUCH_CATEGORY, requestParamsDTO.Category));
                }
            }
            if (!(requestParamsDTO.Country is null))
            {
                if (Enum.TryParse(requestParamsDTO.Country.ToUpper(), out Countries country)) {
                    requestParam.Country = country;
                } else
                {
                    throw new TopArticlesReguestInputException(string.Format(
                        NO_SUCH_COUNTRY_CODE, requestParamsDTO.Country));
                }
            }
            return requestParam;
        }
        public static EverythingRequest DTOToEverything(EverythingParamsDTO requestParamsDTO)
        {
            EverythingRequest requestParam = new EverythingRequest();
            requestParam.Q = requestParamsDTO.Keywords;
            requestParam.Page = requestParamsDTO.Page;
            requestParam.PageSize = requestParamsDTO.PageSize;
            requestParam.From = requestParamsDTO.From;
            requestParam.To = requestParamsDTO.To;
            if(!(requestParamsDTO.Sources is null))
            {
                requestParam.Sources = requestParamsDTO.Sources.Split(",").ToList();
            }
            if (!(requestParamsDTO.Domains is null))
            {
                requestParam.Domains = requestParamsDTO.Domains.Split(",").ToList();
            }
            if (!(requestParamsDTO.Language is null))
            {
                if (Enum.TryParse(requestParamsDTO.Language.ToUpper(), out Languages language))
                {
                    requestParam.Language = language;
                }
                else
                {
                    throw new EverythingRequestInputException(string.Format(
                       NO_SUCH_LANGUAGE_CODE, requestParamsDTO.Language));
                }
            }
            if (!(requestParamsDTO.SortBy is null))
            {
                if (Enum.TryParse(requestParamsDTO.SortBy, out SortBys sortBy))
                {
                    requestParam.SortBy = sortBy;
                }
                else
                {
                    throw new EverythingRequestInputException(string.Format(
                      NO_SUCH_SORT_BY, requestParamsDTO.SortBy));
                }
            }
            return requestParam;

        }
        
    }
}
