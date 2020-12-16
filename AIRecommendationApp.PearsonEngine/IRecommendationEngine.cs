using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationApp.PearsonEngine
{
    public interface IRecommendationEngine
    {
        double GetCorrelation(List<int> baselist, List<int> otherlist);
    }
}
