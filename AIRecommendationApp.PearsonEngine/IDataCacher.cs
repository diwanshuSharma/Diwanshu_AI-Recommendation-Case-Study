using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookUserRatingLib;
using DataLoadingOfBook;

namespace AIRecommendationApp.PearsonEngine
{
    public interface IDataCacher
    {
        BookDetails GetData();
        void SetData(BookDetails bookDetails);
    }
}
