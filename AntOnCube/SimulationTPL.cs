using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AntOnCube
{
    // simulation using Task Parallel Library, # of threads will be determined
    // by the library
    public class SimulationTPL
    {
      public static void Simuluation()
        {
            Ant[] ants = new Ant[GlobalData.numAnts];
            for (int i = 0; i < GlobalData.numAnts; i++)
                ants[i] = new Ant();
            Parallel.For(0, GlobalData.numAnts - 1, i =>
                {
                    int local = i;
                    ants[local].Run();
                });
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
