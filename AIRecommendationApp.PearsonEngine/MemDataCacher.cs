using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookUserRatingLib;
using System.Runtime.Caching;

namespace AIRecommendationApp.PearsonEngine
{
    public class MemDataCacher : IDataCacher
    {
        static MemoryCache memCache = new MemoryCache("memcache");
        public BookDetails GetData()
        {
            BookDetails book = null;

            if (memCache.Contains("data"))
            {
                CacheItem obj = (CacheItem)memCache.Get("data");
                book = (BookDetails)obj.Value;
                //book = (BookDetails);
               
            }

            return book;
        }
        public void SetData(BookDetails bookDetails)
        {
            CacheItem item = new CacheItem("Test", bookDetails);
            memCache.Add("data", item, DateTime.Now.AddMinutes(10));
        }
    }
}
