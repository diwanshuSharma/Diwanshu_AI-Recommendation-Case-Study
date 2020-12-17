using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookUserRatingLib;
using DataLoadingOfBook;

namespace AIRecommendationApp.PearsonEngine
{
    public class BookDataService
    {
        public BookDetails GetBookDetails()
        {
            MemDataCacher memDataCacher = new MemDataCacher();

            var data = memDataCacher.GetData();

            if(data == null)
            {
                Console.WriteLine("Data Stored into Cache");
                IDataLoader dataLoader = new CSVDataLoader();
                data = dataLoader.Load();
                memDataCacher.SetData(data);
            }

            return data;
        }
    }
}
