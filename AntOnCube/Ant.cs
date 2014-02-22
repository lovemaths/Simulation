using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntOnCube
{
    public class Ant
    {
        // start and end position are fixed nodes, 0 and 7
        private const int start_ = 0;
        private const int end_ = 7;

        // number of steps from start to the end
        private int steps_ = 0;
        public int steps
        {
            get { return steps_; }
            set { steps_ = value; }
        }

        public Ant()
        {
        }

        // simulate the ant
        public void Run()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            //Random rand = new Random();
            int curPosition = start_;
            while (curPosition != end_)
            {
                // generate a random number from 0, 1, 2, means the three
                // directions to go
                int randDirection = rand.Next(3);
                // choose a random adjacent node to go
                curPosition = GlobalData.GraphCube[curPosition,randDirection];
                steps++;
            }
        }
    }
}
