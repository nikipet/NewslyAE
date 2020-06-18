using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Exceptions
{
    public class ApiResponseException : Exception
    {
        public ApiResponseException()
        {

        }
        public ApiResponseException(string reason)
       : base(String.Format("Could not retrieve results. Reason:\n{0}", reason))
        {

        }
    }
}
