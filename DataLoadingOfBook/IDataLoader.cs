using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookUserRatingLib;

namespace DataLoadingOfBook
{
    public interface IDataLoader
    {
        BookDetails Load();
    }
}
