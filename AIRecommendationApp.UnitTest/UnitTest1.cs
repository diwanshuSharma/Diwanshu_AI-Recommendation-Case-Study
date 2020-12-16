using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AIRecommendationApp;
using System.Collections.Generic;
using AIRecommendationApp.PearsonEngine;

namespace AIRecommendationApp.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        int precision = 2;
        PesrsonRecommendationEngine pe = new PesrsonRecommendationEngine();
        [TestMethod]
        public void PearsonEngine_OnSameLength_ReturnDouble()
        {
            List<int> a = new List<int> { 1, 2, 3, 4, 5 };
            List<int> b = new List<int> { 1, 2, 2, 2, 3 };
            double expected = 0.89;
           
            double actual = pe.GetCorrelation(a, b);
            Assert.AreEqual(expected, Math.Round(actual, precision));
        }

        [TestMethod]
        public void PearsonEngine_BaseLengthLarger_ReturnDouble()
        {
            List<int> a = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> b = new List<int> { 1, 2, 2, 2, 3 };
            double expected = 0.08;
            
            double actual = pe.GetCorrelation(a, b);
            Assert.AreEqual(expected, Math.Round(actual, precision));
        }

        [TestMethod]
        public void PearsonEngine_BaseLengthSmaller_ReturnDouble()
        {
            List<int> a = new List<int> { 1, 2, 3, 4 };
            List<int> b = new List<int> { 1, 2, 2, 2, 3 };
            double expected = 0.77;
            
            double actual = pe.GetCorrelation(a, b);
            Assert.AreEqual(expected, Math.Round(actual, precision));
        }
    }
}
