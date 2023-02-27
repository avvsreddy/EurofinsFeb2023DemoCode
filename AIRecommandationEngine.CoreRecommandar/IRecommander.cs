using System.Collections.Generic;

namespace AIRecommandationEngine.CoreRecommandar
{
    public interface IRecommander
    {
        double GetCorrelation(List<int> baseData, List<int> otherData);
    }
}
