using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AntOnCube
{
    // manually set up the number of threads, and do simulation.
    public class SimulationMan
    {
        // simulation the ants in thread i
        public static void SimulationThread(int i)
        {
            int numAntsHere = GlobalData.numAnts / GlobalData.threads;
            List<Ant> ants = new List<Ant>();
            for (int j = 0; j < numAntsHere; j++)
                ants.Add(new Ant());
            Dictionary<int, int> countAntBySteps = GlobalData.countAntThread[i];

            for (int j = 0; j < numAntsHere; j++)
            {
                ants[j].Run();
                if (!countAntBySteps.ContainsKey(ants[j].steps))
                    countAntBySteps.Add(ants[j].steps, 1);
                else
                    countAntBySteps[ants[j].steps]++;
            }

        }
        public static void Simulation()
        {
            for (int i = 0; i < GlobalData.threads; i++)
                GlobalData.countAntThread.Add(new Dictionary<int, int>());

            Thread[] myThreads = new Thread[GlobalData.threads];

            for (int i = 0; i < GlobalData.threads; i++)
            {
                int local = i;
                myThreads[i] = new Thread(() => SimulationThread(local));
            }

            for (int i = 0; i < GlobalData.threads; i++)
            {
                int local = i;
                myThreads[local].Start();
            }

            for (int i = 0; i < GlobalData.threads; i++)
            {
                int local = i;
                myThreads[local].Join();
            }

            foreach (var dict in GlobalData.countAntThread)
            {
                foreach (var item in dict)
                {
                    if (GlobalData.frequency.ContainsKey(item.Key))
                        GlobalData.frequency[item.Key] += item.Value;
                    else
                        GlobalData.frequency.Add(item.Key, item.Value);
                }
            }
        }
    }
}
