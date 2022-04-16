using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Nathan Welsh
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // ***********************************************
    class Card
    {
        private int value;
        private Boolean IsAce;
        private Image image;

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


    }
}
