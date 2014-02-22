using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntOnCube
{
    /// <summary>
    /// Support the calculation of statistical variables.
    /// </summary>
    public class StatisticsCal
    {
        /// <summary>
        /// Find the mean steps
        /// </summary>
        /// <returns>Mean steps</returns>
        public static double findMean()
        {
            double total = 0; // Total number of steps
            foreach (var item in GlobalData.frequency)
            {
                total += (double)(item.Key * item.Value);
            }
            return total / (double)GlobalData.numAnts;
        }

        /// <summary>
        /// Find the variance
        /// </summary>
        /// <returns>Variance</returns>
        public static double findVariance()
        {
            double temp = 0;
            foreach (var item in GlobalData.frequency)
            {
                temp += (double)item.Value * Math.Pow((double)item.Key - GlobalData.mean, 2);
            }
            return  Math.Sqrt(temp / (double)GlobalData.numAnts);
        }

        /// <summary>
        /// Calculate the probability that an ant uses StepNum steps to reach the diagonal point. 
        /// </summary>
        /// <param name="StepNum">num of steps</param>
        /// <returns>Probability</returns>
        public static double probOfStep(int StepNum)
        {
            if (!GlobalData.frequency.ContainsKey(StepNum))
                return 0;
            return GlobalData.frequency[StepNum] / (double)GlobalData.numAnts;
        }
    }
}
