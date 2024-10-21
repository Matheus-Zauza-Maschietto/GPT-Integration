using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpt_integration.Exceptions;

public class BussinesException : Exception
{
    public BussinesException(string message) : base(message)
    {
        
    }
}
