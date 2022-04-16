using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
    public partial class Form1 : Form
    {
        Random ranNumberGenerator;
        int WindowHeight = 380;
        int WindowWidth = 680;
        int totalbreakfastitemsdone = 0;
        delegate void MyCallBack(String BreakfastItem);// call back

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(WindowWidth, WindowHeight);
            ranNumberGenerator = new Random();
        }

        async Task MyMain()
        {
            String msg = "";
            var CoffeeTask = PourCoffee(30);
            var eggsTask = FryEggsAsync(100);
            var baconTask = FryBaconAsync(200);
            var toastTask = MakeToastWithButterAndJamAsync(140);

            var allTasks = new List<Task> { CoffeeTask, eggsTask, baconTask, toastTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished.IsCompleted)
                {

                    if (finished == CoffeeTask)
                    {
                        msg = "Coffee is done";
                        
                    }
                    if (finished == eggsTask)
                    {
                        msg = "eggs are ready";
                    }

                    else if (finished == baconTask)
                    {
                        msg = "Bacon is ready";
                          
                    }

                    else if (finished == toastTask)
                    {
                        msg = "toast is ready";
                    }

                    allTasks.Remove(finished);

                }
            }
        }

        async Task<BreakfastItem> MakeToastWithButterAndJamAsync(int timeinmlsecs)
        {
            BreakfastItem myitem = new BreakfastItem("Toast", 1200, timeinmlsecs, progressBarToast, TaskCallBack);//fix this
            return myitem;
        }

        async Task<BreakfastItem> FryEggsAsync(int timeinmlsecs)
        {

            BreakfastItem myitem = new BreakfastItem("Fried Eggs", 1400, timeinmlsecs, progressBarFriedEggs, TaskCallBack);
            return myitem;
        }

        async Task<BreakfastItem> FryBaconAsync(int timeinmlsecs)
        {

            BreakfastItem myitem = new BreakfastItem("Bacon", 900, timeinmlsecs, progressBarBacon, TaskCallBack);
            return myitem;
        }

        async Task<BreakfastItem> PourCoffee(int timeinmlsecs)
        {
            BreakfastItem myitem = new BreakfastItem("Pour Cofffee", 1000, timeinmlsecs, progressBarCoffee, TaskCallBack);
            return myitem;
        }

        public void TaskCallBack(String BreakfastItemName)
        {
            //MessageBox.Show(BreakfastItemName + " Task is DONE...");
            String msg = BreakfastItemName + " Task is DONE...";
            label6.Text = msg;
            label6.Refresh();
            totalbreakfastitemsdone++;
            if (totalbreakfastitemsdone >= 4)
            {
                msg = "Breakfast is ready!!";
                label6.Text = msg;
                label6.Refresh();
                MessageBox.Show(msg, "Dr. Webster's Breakfast Tasks");
            }
        }

    
        private void MakeBreakfastButton_Click(object sender, EventArgs e)
        {
            label6.Text = "Making Breakfast with Async Tasks Multi-Tasking!!";
            label6.Refresh();
            Task finished = MyMain();
        }
    }
}

