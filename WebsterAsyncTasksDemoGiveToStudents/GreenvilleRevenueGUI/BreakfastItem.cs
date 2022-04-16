using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.ComponentModel;
using System.Threading;
namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Dr. Roger Webster
    // Written by: Nathan Welsh
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // ***********************************************
    class BreakfastItem
    {
        int RandomwaitMax = 0;
        ProgressBar myprogressBar = null;
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        Boolean keepgoing = true;
        String BreakfastItemName = "";
        public delegate void MyCallBack(String BreakfastItem);// call back
        public event MyCallBack CallToMakeWhenDone = null;
        double totaltime = 0;
        public BreakfastItem(String BreakfastItemNameIn, int intervallen, int RandomwaitMax, ProgressBar progressBarin, MyCallBack callback)
        {
            this.RandomwaitMax = RandomwaitMax;
            BreakfastItemName = BreakfastItemNameIn;
            CallToMakeWhenDone = callback;
            if (progressBarin != null)
            {
                myprogressBar = progressBarin;
                myprogressBar.MarqueeAnimationSpeed = intervallen;
                myprogressBar.Maximum = RandomwaitMax;
                myprogressBar.Name = "progressBar Item";
                myprogressBar.Size = new System.Drawing.Size(RandomwaitMax, 23);
                myprogressBar.Step = 10;
                myprogressBar.TabIndex = 2;
            }

            startTask(intervallen);
        }

        private void startTask(int intervallen)
        {
            totaltime = 0;

            //Start timer1
            timer1.Interval = intervallen;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {

            if (keepgoing)
            {
                totaltime += 1000;

                if (totaltime > timer1.Interval * 2 || timer1.Interval == 1000)
                {
                    myprogressBar.PerformStep();
                    if (myprogressBar.Value.Equals(RandomwaitMax))
                    {
                        keepgoing = false;
                        CallToMakeWhenDone(BreakfastItemName);//call back to form1
                        timer1.Stop();
                        timer1.Enabled = false;


                    }
                }
            }
        }

    }
}
