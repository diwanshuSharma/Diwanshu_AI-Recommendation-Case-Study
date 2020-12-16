using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationApp.PearsonEngine
{
    public class PesrsonRecommendationEngine : IRecommendationEngine
    {
        public double GetCorrelation(List<int> baseList, List<int> otherList)
        {
            int len1 = baseList.Count, len2 = otherList.Count;
            List<int> tArray1 = new List<int>(), tArray2 = new List<int>();
            int minLength = Math.Min(len1, len2);

            if (len1 != len2)
            {
                if (len1 < len2)                                  //Second Array is larger
                {
                    for (int i = 0; i < Math.Min(len1, len2); i++)
                    {
                        tArray1.Add(baseList[i]);
                        tArray2.Add(otherList[i]);
                    }
                }
                else                                            //First Array is larger
                {
                    tArray1 = baseList;
                    for (int i = 0; i < baseList.Count; i++)
                    {
                        if (i < minLength)
                        {
                            tArray2.Add(otherList[i]);
                        }
                        else
                        {
                            tArray1[i] += 1;
                            tArray2.Add(1);
                        }
                    }
                }
            }
            else                                                //Same Count
            {
                tArray1 = baseList;
                tArray2 = otherList;
            }
            for (int i = 0; i < tArray1.Count; i++)                 //If there are any zeros
            {
                if (tArray1[i] == 0 || tArray2[i] == 0)
                {
                    tArray1[i] += 1;
                    tArray2[i] += 1;
                }
            }

            return CalculatePearson(tArray1, tArray2);
        }

        private static double CalculatePearson(List<int> array1, List<int> array2)
        {
            double mean1 = 0, mean2 = 0;
            double numerator = 0, deno1 = 0, deno2 = 0;

            foreach (int elem in array1)
            {
                mean1 += elem;
            }
            foreach (int elem in array2)
            {
                mean2 += elem;
            }
            mean1 /= array1.Count;
            mean2 /= array1.Count;

            for (int i = 0; i < array1.Count; i++)
            {
                numerator += (array1[i] - mean1) * (array2[i] - mean2);
                deno1 += (array1[i] - mean1) * (array1[i] - mean1);
                deno2 += (array2[i] - mean2) * (array2[i] - mean2);
            }

            double pearson = (numerator) / (Math.Sqrt(deno1 * deno2));
            return pearson;
        }
    }
    
}
