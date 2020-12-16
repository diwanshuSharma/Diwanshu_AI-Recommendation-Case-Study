using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLoadingOfBook;

namespace AIRecommendationApp.UnitTest
{
    [TestClass]
    public class DataLayerUnitest
    {
        [TestMethod]
        public void Loading_check()
        {
            IDataLoader cv = new CSVDataLoader();
            Console.WriteLine("test success");
        }


        [TestMethod]
        public void Loading_check_usingParallel()
        {
            IDataLoader cv = new ParallelCsvLoading();
            Console.WriteLine("test success");
        }

        [TestMethod]
        public void Loading_check_usingDB()
        {
            IDataLoader cv = new DBLoading();
            Console.WriteLine("test success");
        }


    }
}
