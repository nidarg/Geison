using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}
