using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.ErrorHandling.Middleware
{
    public abstract class CoderException: Exception
    {
        internal protected CoderException(string msg): base(msg) 
        {
            
        }
    }
}
