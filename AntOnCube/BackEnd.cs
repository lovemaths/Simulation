//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace AntOnCube
//{
//    public class Ant
//    {
//        public int position;
//        public Ant()
//        {
//            position = 0;
//        }
//    }

//    public static class BackEnd
//    {
//        public static int[,] GraphCube = new int[8,3];
//        public static double mean = 0;
//        public static double variance = 0;
//        public static int AntNo = 100;
//        public static int MaxStep = 30;
//        /* record the number of Ants walk 3, 5, 7, ..., 21 steps*/
//        public static int[] Steps = new int[MaxStep];
//        public static int Sum; //The sum of all the steps;
//       // public static int ProbStep = 0;
//        //public static double Prob = 0;
//        public static Ant[] Ants = new Ant[AntNo];

//        /* Construct a Cube Graph */
//        public static void ConstructCube()
//        {
//            GraphCube[0, 0] = 1;
//            GraphCube[0, 1] = 4;
//            GraphCube[0, 2] = 3;
//            GraphCube[1, 0] = 0;
//            GraphCube[1, 1] = 2;
//            GraphCube[1, 2] = 5;
//            GraphCube[2, 0] = 1;
//            GraphCube[2, 1] = 3;
//            GraphCube[2, 2] = 6;
//            GraphCube[3, 0] = 0;
//            GraphCube[3, 1] = 2;
//            GraphCube[3, 2] = 7;

//            GraphCube[4, 0] = 0;
//            GraphCube[4, 1] = 5;
//            GraphCube[4, 2] = 7;
//            GraphCube[5, 0] = 1;
//            GraphCube[5, 1] = 4;
//            GraphCube[5, 2] = 6;
//            GraphCube[6, 0] = 2;
//            GraphCube[6, 1] = 5;
//            GraphCube[6, 2] = 7;
//            GraphCube[7, 0] = 3;
//            GraphCube[7, 1] = 4;
//            GraphCube[7, 2] = 6;
//        }

//        /* Given a node, compute the diagnol node */
//        public static int DiagNode(int start)
//        {
//            int result;
//            switch (start) 
//            {
//                case 0:
//                    result = 6;
//                    break;
//                case 1:
//                    result = 7;
//                    break;
//                case 2:
//                    result = 4;
//                    break;
//                case 3:
//                    result = 5;
//                    break;
//                case 4:
//                    result = 2;
//                    break;
//                case 5:
//                    result = 3;
//                    break;
//                case 6:
//                    result = 0;
//                    break;
//                default:
//                    result = 0;
//                    break;

//            }
//            return result;
//        }

//        /* main function return the step on ant traverse */
//        public static int DiagCompute(int start)
//        {
//            int end = DiagNode(start);
//            int middle = start;
//            int step = 0;
//            Random rand = new Random(Guid.NewGuid().GetHashCode());
//            int randd = 0;

//            while (middle != end)
//            {
//                randd = rand.Next(3);
//                switch (randd) 
//                {
//                    case 0:
//                        middle = GraphCube[middle,0];
//                        step++;
//                        break;
//                    case 1:
//                        middle = GraphCube[middle,1];
//                        step++;
//                        break;
//                    case 2:
//                        middle = GraphCube[middle,2];
//                        step++;
//                        break;
//                }
//            }

//            return step;
//        }

//        /* Simulate, and compute the statistical value*/
//        public static void Simulate()
//        {
//            ConstructCube();
//            Array.Clear(Steps, 0, MaxStep);
//            int TempStep = 0;
//            int TempIndex = 0;

//            for (int i = 0; i < AntNo; i++)
//            {
//                //TempStep = DiagCompute(Ants[i].position);
//                TempStep = DiagCompute(0);
//                TempIndex = (TempStep - 3) / 2;
//                if (TempIndex < MaxStep)
//                {
//                    Steps[TempIndex]++;
//                }
//                else
//                {
//                    Steps[MaxStep - 1]++;
//                }
//                Sum += TempStep;
//            }
//        }


//            /*
//            int Sum = 0;
            
//            int TempStep = 0;

//            for (int i = 0; i < AntNo; i++)
//            {
//                //Steps[i] = DiagCompute(Ants[i].position);
//                Steps[i] = DiagCompute(0);
//                Sum += Steps[i];
//                if (Steps[i] == ProbStep)
//                    TempStep++;
//            }

//            / /Compute the Statistic Value 
//            mean = (double)Sum / (double)AntNo;
//            Prob = (double)TempStep / (double)AntNo;

//            double TempSum = 0;
//            for (int i = 0; i < AntNo; i++)
//            {
//                TempSum += Math.Pow((double)Steps[i]-mean,2);
//            }
//            variance = Math.Sqrt(TempSum / (double)AntNo);
//            */

//        /* Compute statistical value, such as mean and variance */
//        public static void StatCompute()
//        {
//            mean = (double)Sum / (double)AntNo;
//        }

//        public static double ProbCompute(int StepNum)
//        {
//            int index = (StepNum - 3) / 2;
//            if (index < MaxStep)
//                return (double)Steps[index] / (double)AntNo;
//            else
//                return (double)Steps[MaxStep - 1] / (double)AntNo; 
//        }

//    }
//}
