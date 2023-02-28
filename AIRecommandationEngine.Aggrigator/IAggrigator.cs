using AIRecommandationEngine.Common.Entities;
using System.Collections.Generic;

namespace AIRecommandationEngine.Aggrigator
{
    public interface IAggrigator
    {
        Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference);
    }

    public class RatingsAggrigator : IAggrigator
    {
        public Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference)
        {
            throw new System.NotImplementedException();
        }
    }
}
