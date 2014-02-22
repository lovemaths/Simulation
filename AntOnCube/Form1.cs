using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AntOnCube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numOfAnts_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void numOfThreads_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProOfStep_TexChanged(object sender, EventArgs e)
        {

        }

        private void StepMean_Label(object sender, EventArgs e)
        {

        }

        private void StepVar_Label(object sender, EventArgs e)
        {

        }

        private void ProbOfStep_Label(object sender, EventArgs e)
        {

        }

        private void Simulate_Click(object sender, EventArgs e)
        {
            //BackEnd.AntNo = int.Parse(numOfAnts.Text);
            //BackEnd.Simulate();
            //BackEnd.StatCompute();

            GlobalData.numAnts = int.Parse(numOfAnts.Text);
            try
            {
                GlobalData.threads = int.Parse(numOfThreads.Text);
                GlobalData.useTPL = false;
            }
            catch (FormatException E)
            {
                GlobalData.useTPL = true;
            }

            // clean up the history from previous calculation
            GlobalData.countAnts.Clear();
            GlobalData.countAntThread.Clear();
            GlobalData.frequency.Clear();

            if (GlobalData.useTPL)
                SimulationTPL.Simuluation();
            else
                SimulationMan.Simulation();

            GlobalData.mean = StatisticsCal.findMean();
            GlobalData.variance = StatisticsCal.findVariance();

            StepMean.Text = GlobalData.mean.ToString();
            StepVar.Text = GlobalData.variance.ToString();

            //StepMean.Text = BackEnd.mean.ToString();
            //StepVar.Text = BackEnd.variance.ToString();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GenerateDistribution_Click(object sender, EventArgs e)
        {
            //this.chart1.Series.Clear();
            //this.chart1.Series.Add("Steps");
            //this.chart1.ChartAreas[0].AxisY.Maximum = BackEnd.Steps.Max();

            //int index = 0;
            //for (int i = 0; i < BackEnd.MaxStep; i++)
            //{
            //    index = 2 * i + 3;
            //    this.chart1.Series["Steps"].Points.AddXY(index.ToString(), BackEnd.Steps[i]);
            //}

            int[] steps = new int[50];
            this.chart1.Series.Clear();
            this.chart1.Series.Add("Probability");
            this.chart1.ChartAreas[0].AxisY.Maximum = 40;
            this.chart1.ChartAreas[0].AxisX.Minimum = 0;
            this.chart1.ChartAreas[0].AxisX.Title = "Steps";
            this.chart1.ChartAreas[0].AxisY.Title = "Percentage";
            int prob = 0;
            for (int i = 0; i < 50; i++)
            {
                if (!GlobalData.frequency.ContainsKey(i))
                    prob = 0;
                else
                    prob = GlobalData.frequency[i]*100/GlobalData.numAnts;
              this.chart1.Series["Probability"].Points.AddXY(i,prob.ToString());
            }
        }

        private void Compute_Prob_Click(object sender, EventArgs e)
        {
            ProbOfStepRes.Text =StatisticsCal.ProbCompute(int.Parse(ProbOfStep.Text)).ToString();
            //double prob = BackEnd.ProbCompute(int.Parse(ProbOfStep.Text));
            //ProbOfStepRes.Text = prob.ToString();

        }

        private void ProbOfStep_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
