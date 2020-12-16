using BookUserRatingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoadingOfBook
{
    class CSVDataLoader : IDataLoader
    {
        public BookDetails Load()
        {
            return new BookDetails();
        }
    }
}
