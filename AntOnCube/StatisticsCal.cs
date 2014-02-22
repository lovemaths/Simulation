using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntOnCube
{
    public class StatisticsCal
    {
        public static double findMean()
        {
            double total = 0;
            foreach (var item in GlobalData.frequency)
            {
                total += (double)(item.Key * item.Value);
            }
            return total / (double)GlobalData.numAnts;
        }

        public static double findVariance()
        {
            double temp = 0;
            foreach (var item in GlobalData.frequency)
            {
                temp += (double)item.Key * Math.Pow((double)item.Value - GlobalData.mean, 2);
            }
            return  Math.Sqrt(temp / (double)GlobalData.numAnts);
        }

        public static double ProbCompute(int StepNum)
        {
            if (!GlobalData.frequency.ContainsKey(StepNum))
                return 0;
            return GlobalData.frequency[StepNum] / (double)GlobalData.numAnts;
        }
    }
}
