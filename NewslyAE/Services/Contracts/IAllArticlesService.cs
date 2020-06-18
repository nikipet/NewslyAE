using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Services.Contracts
{
    public interface IAllArticlesService
    {
        ArticlesResult GetEverything(EverythingRequest reqParams);
    }
}
