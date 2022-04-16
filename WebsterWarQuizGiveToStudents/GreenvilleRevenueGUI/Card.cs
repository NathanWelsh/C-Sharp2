using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Dr. Roger Webster
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // ***********************************************
    class Card
    {
        Image image;
        int value;
        Boolean IsAce;
        public Card(Image myimage, int myvalue)
        {
            image = myimage;
            value = myvalue;
            IsAce = false;

        }
        public Image GetCardImage()
        {
            return image;
        }
        public int GetCardValue()
        {
            return value;
        }
        
        public void SetCardToAce()
        {
            IsAce = true;
        }
        public Boolean GetCardisanAce()
        {
            return IsAce;
        }
        public void SetCardToAceValue1()
        {
            if (IsAce)
            {
                value = 1;
            }
        }

    }
}
