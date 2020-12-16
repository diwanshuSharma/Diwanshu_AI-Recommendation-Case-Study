using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationApp.PearsonEngine
{
    public interface IRecommendationEngine
    {
        double GetCorellation(int[] a1, int[] a2);
    }
}
