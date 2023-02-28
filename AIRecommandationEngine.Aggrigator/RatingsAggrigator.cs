using AIRecommandationEngine.Common.Entities;
using System.Collections.Generic;

namespace AIRecommandationEngine.Aggrigator
{
    public class RatingsAggrigator : IAggrigator
    {
        public Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preference preference)
        {
            // collect all ratings for each book based on preference and return
            Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();
            // fill the ratings
            return ratings;

        }
    }
}
