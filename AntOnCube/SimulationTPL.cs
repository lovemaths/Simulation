using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AntOnCube
{
    /// <summary>
    /// Provide simulation method using Task Parallel Library.
    /// </summary>
    public class SimulationTPL
    {
        /// <summary>
        /// Simulate the ants, using Task Parallel Library.
        /// </summary>
        public static void Simuluation()
        {
            // Create and initilize ants.
            Ant[] ants = new Ant[GlobalData.numAnts];
            for (int i = 0; i < GlobalData.numAnts; i++)
                ants[i] = new Ant();

            // Simulate each ants.
            Parallel.For(0, GlobalData.numAnts, i =>
                {
                    int local = i;
                    ants[local].Run();
                });

            // Count how many ants using how many steps, and store the 
            // result in the dictionary frequency.
            foreach (Ant ant in ants)
            {
                if (!GlobalData.frequency.ContainsKey(ant.steps))
                {
                    GlobalData.frequency.Add(ant.steps, 1);
                }
                else
                    GlobalData.frequency[ant.steps]++;
            }
        }
    }
}
