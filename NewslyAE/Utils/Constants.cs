using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Utils
{
    public class Constants
    {
        public static readonly string apiKey="517e405b170d42e598999a5461b07b17";

        public static readonly string EVERYTHING_REQUEST_MISSING_INFO_MESSAGE = 
            "Please fill input for Keywords, Sources or Domains";
        public static readonly string TOP_ARTICLES_PARAM_COMBINATION_ERROR =
            "Cannot combine the Source parameter with either Country or Category!";
        public static readonly string TOP_ARTICLES_MISSING_INPUT_MESSAGE = 
            "You need to input for Sources,Keywords,Language, Country or Category!";
        public static readonly string PAGE_SIZE_VIOLATION = 
            "Page size must be between 1 and 100!";
        public static readonly string PAGE_NUMBER_VIOLATION = 
            "Page e must be at least 1!";

        public static readonly string KEYWORDS_OF_THE_DAY = "Trump";
        public static readonly int EXAMPLE_PAGESIZE = 5;
        public static readonly int EXAMPLE_PAGE = 1;

    }
}
