using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Models.DTOs
{
    public class TopArticlesParamsDTO
    {
        [StringLength(2)]
        public string Country { get; set; }
        public string Category { get; set; }
        public string Sources { get; set; }
        public string Keywords { get; set; }
        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100")]
        public int PageSize { get; set; }
        [Range(1, 100, ErrorMessage = "Page number must at least 1 and not exceed Results/PageSize")]
        public int Page { get; set; }
    }
}
