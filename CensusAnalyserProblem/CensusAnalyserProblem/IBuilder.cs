using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserProblem
{
   public interface IBuilder
    {
        IList<string> Parse(String path);
    }
}
