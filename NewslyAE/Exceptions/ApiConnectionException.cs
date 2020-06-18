using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Exceptions
{
    public class ApiConnectionException:Exception
    {
        public ApiConnectionException()
        {

        }
        public ApiConnectionException(string reason)
       : base(String.Format("Could not connecto to NewsApi. Reason:\n{0}", reason))
        {

        }
    }
}
