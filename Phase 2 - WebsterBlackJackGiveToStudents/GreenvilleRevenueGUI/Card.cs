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
            if (this.GetCardValue() == 1 || this.GetCardValue() == 11)
            {
                this.SetCardToAce();
            }
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

        public bool GetAce()
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

        public void SetCardToAceValue11()
        {
            if (IsAce)
            {
                value = 11;
            }
        }

        public void ToggleAce()
        {
            if (IsAce)
            {
                if (value == 1)
                {
                    value = 11;
                }
                else
                {
                    value = 1;
                }
            }
        }


    }
}
