using Books;
using BookUserRatingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationApp.PearsonEngine
{
    public interface IRatingsAggrigator
    {
        Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preferance preferance);
    }
}
