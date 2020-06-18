using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewslyAE.Exceptions
{
    public class EverythingRequestInputException:Exception
    {
        public EverythingRequestInputException()
        {

        }
        public EverythingRequestInputException(string message):base(message)
        {

        }
    }
}
