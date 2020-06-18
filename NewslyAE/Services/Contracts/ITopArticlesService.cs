using NewsAPI.Models;
using NewslyAE.Models;
using NewslyAE.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Services.Contracts
{
    public interface ITopArticlesService
    {
        public ArticlesResult GetTopArticles(TopHeadlinesRequest requestParam);
    }
}
