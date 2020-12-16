using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace AIRecommendationApp.PearsonEngine
{
    class MathNetPearsonRecommendationEngine : IRecommendationEngine
    {
        public double GetCorrelation(List<int> baselist, List<int> otherlist)
        {

            return Correlation.Pearson(baselist.Select<int, double>(i => i).ToList(), otherlist.ConvertAll<double>(i=> i));

        }
    }
}
