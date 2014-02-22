using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntOnCube
{
    public static class GlobalData
    {
        #region Structure of the cube
        // The nodes on the cube are labelled by 0, 1, 2, 3, .... , 7.
        // GraphCube[i] is the the adjacent node list of node i. 
        // For example, node 0 has adjacent nodes 1,2,3, 
        // so GraphCube[0] = {1,2,3}
        private static int[,] GraphCube_;
        public static int[,] GraphCube{
            get
            {
                GraphCube_ = new int[,]{{1,2,3}, {0,4,5}, {0,5,6}, {0,4,6}, 
            {1,3,7}, {1,2,7}, {2,3,7}, {4,5,6}};
                return GraphCube_;
            }
        }

        // DiagNode[i] is the node off the diagonal of node i. 
        // For example, node 0 and 7 are on the same diagonal,
        // so DiagNode[0] = 7 and DiagNode[7] = 0;
        private static int[] DiagNode_;
        public static int[] DiagNode
        {
            get{
                DiagNode_= new int[8] { 7, 6, 4, 5, 2, 3, 1, 0 };
                return DiagNode_;
            }
        }

        #endregion

        #region Input data

        // The input data, number of ants and number of threads
        private static int numAnts_ = 0;
        public static int numAnts
        {
            get { return numAnts_;  }
            set { numAnts_ = value; }
        }
        private static int threads_ = 1;
        public static int threads
        {
            get { return threads_;  }
            set { threads_=value;  }
        }

        // use TPL parallel or manual parallel
        private static bool useTPL_ = true;
        public static bool useTPL
        {
            get { return useTPL_; }
            set { useTPL_ = value; }
        }

        #endregion

        #region Statistic variables

        // The statistics data of the simulation
        private static double mean_ = 0;
        public static double mean
        {
            get { return mean_; }
            set { mean_ = value; }
        }
        private static double variance_ = 0;
        public static double variance
        {
            get { return variance_; }
            set { variance_ = value; }
        }
        #endregion

        #region Program variables

        // The ants are grouped in a dictionary, 
        // by the number of steps used from node 0 (start node) to node 7 (end node).
        // The key is the number of steps, and value is number of ants.
        // For example, {{3,5},{7,10}} means 5 ants used 3 steps, and 10 ants 
        // used 7 steps, and in total there are 15 ants.
        public static Dictionary<int, int> countAnts = new Dictionary<int,int>();           

        public static List<Dictionary<int, int>> countAntThread = new List<Dictionary<int, int>>();

        public static Dictionary<int, int> frequency = new Dictionary<int, int>();

        #endregion
    }
}
