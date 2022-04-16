using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Nathan Welsh
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // ***********************************************
    public partial class Form1 : Form
    {

        int x = 5;
        int y = 91;
        int z = 92;

        public Form1()
        {
            InitializeComponent();
            //preset the numbers!!!   int x = 5, y = 91, z = 22;
            lastTextBox.Text = "5";
            thisTextBox.Text = "91";
            textBox1.Text = "22";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        //RUN Button
        private void Button1_Click(object sender, EventArgs e)
        {

            x = Int32.Parse(lastTextBox.Text);
            y = Int32.Parse(thisTextBox.Text);
            z = Int32.Parse(textBox1.Text);
            mystery(z, y, x, 0);

            mystery(y, x, z, 1);
        }

        //callno is which call 0 or 1??
        public void mystery(int x, int z, int y, int callno)

        {

            x++;

            y = x - z * 2;

            x = z + 1;

            if (callno==0)
            {
                textBox2.Text = "" + x;
                textBox3.Text = "" + y;
                textBox4.Text = "" + z;
            }
            if (callno==1)
            {
                textBox5.Text = "" + x;
                textBox6.Text = "" + y;
                textBox7.Text = "" + z;
            }



        }


        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastTextBox_TextChanged(object sender, EventArgs e)
        {
            clearform();
        }

        private void clearform()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void thisTextBox_TextChanged(object sender, EventArgs e)
        {
            clearform();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            clearform();
        }
    }
}

