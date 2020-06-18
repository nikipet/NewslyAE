using NewsAPI.Models;
using NewslyAE.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Models
{
    public class EverythingWrapper
    {
        public EverythingParamsDTO Request { get; set; }
        public ArticlesResult Result{ get; set; }
    }
}
