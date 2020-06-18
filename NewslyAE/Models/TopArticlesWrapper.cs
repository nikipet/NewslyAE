using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsAPI.Models;

namespace NewslyAE.Models.DTOs
{
    public class TopArticlesWrapper
    {
        public TopArticlesWrapper(TopArticlesParamsDTO request, ArticlesResult articles)
        {
            Result = articles;
            Request = request;
        }
        public TopArticlesWrapper()
        {
          
        }
        public ArticlesResult Result { set; get; }
        public TopArticlesParamsDTO Request { set; get; }
    }
}
