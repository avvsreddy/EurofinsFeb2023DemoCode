using AIRecommandationEngine.Common.Entities;
using System.Collections.Generic;

namespace AIRecommandationEngine.Aggrigator
{
    public interface IAggrigator
    {
        Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference);
    }
}
