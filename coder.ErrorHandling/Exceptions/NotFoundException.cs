using coder.ErrorHandling.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.ErrorHandling.Exceptions
{
    public class NotFoundException: CoderException
    {
        public NotFoundException(string msg) : base(msg)
        {
            
        }
    }
}
