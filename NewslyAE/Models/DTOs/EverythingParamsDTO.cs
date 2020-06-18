using NewsAPI.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Models.DTOs
{
    public class EverythingParamsDTO
    {

        public string Keywords { get; set; }
        public string Sources { get; set; }
        public string Domains { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        [StringLength(2)]
        public string Language { get; set; }
        public string SortBy { get; set; }
        [Range(1, 999, ErrorMessage = "Page number must at least 1")]
        public int Page { get; set; }
        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100")]
        public int PageSize { get; set; }

    }
}
