using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLoadingOfBook;

namespace AIRecommendationApp.UnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Loading_check()
        {
            IDataLoader cv = new CSVDataLoader();
            Console.WriteLine("test success");
        }
    }
}
