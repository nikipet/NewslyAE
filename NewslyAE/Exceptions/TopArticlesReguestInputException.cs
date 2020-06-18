using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Exceptions
{
    public class TopArticlesReguestInputException:Exception
    {
        public TopArticlesReguestInputException()
        {

        }

        public TopArticlesReguestInputException(string message) : base(message)
        {

        }
    }
}
