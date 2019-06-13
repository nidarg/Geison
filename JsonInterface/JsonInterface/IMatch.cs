using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public interface IMatch
    {
         bool Success();

         string RemainingText();
    }
}
