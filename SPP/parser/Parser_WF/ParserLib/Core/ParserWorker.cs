using System;
using System.Collections.Generic;
using System.Text;

namespace ParserLib.Core
{
    class ParserWorker<T> where T:class
    {
        IParser<T> parser;

    }
}
