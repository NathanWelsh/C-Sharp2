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

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Dr. Roger Webster
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // ***********************************************
    class Cards
    {
        Random ranNumberGenerator;

        int currentcardnumber = 0;
        Card[] AllCards = new Card[52];
        Card ACardBack;
        public Cards()
        {
            ranNumberGenerator = new Random();
            LoadCards();
        }
        private void LoadCards()
        {
            Card ACard;
            string[] list = Directory.GetFiles(@"cards", "*.gif");

            for (int index = 0; index < 52; index++)
            {
                int value = GetNextCardValue(index);
                Image image = Image.FromFile(list[index]);

                ACard = new Card(image, value);
                if (index > 32 && index < 36)
                {
                    ACard.SetCardToAce();

                }
                AllCards[index] = ACard;
            }


            string[] list2 = Directory.GetFiles(@"cards", "Wfswbackcard*.gif");
            Image Backimage = Image.FromFile(list2[0]);
            ACardBack = new Card(Backimage, 0);

        }

        private int GetNextCardValue(int currentcardnumber)
        {
            int cardvalue = 0;
            if (currentcardnumber < 33)
                cardvalue = (currentcardnumber / 4) + 2;
            else
            {
                cardvalue = 10;
            }
            if (currentcardnumber > 31 && currentcardnumber < 36)
                cardvalue = 14;//aces
            if (currentcardnumber > 35 && currentcardnumber < 40)
                cardvalue = 11;//jack
            if (currentcardnumber > 39 && currentcardnumber < 44)
                cardvalue = 13;//king
            if (currentcardnumber > 43 && currentcardnumber < 48)
                cardvalue = 12;//Queen
            return cardvalue;
        }

        public Card GetNextCard()
        {

            if (currentcardnumber >= 52)
            {
                currentcardnumber = 0;
                MessageBox.Show("Dealer is reshuffling cards!");
                shuffleCards();

            }

            return AllCards[currentcardnumber++];

        }
        public int GetCurrentCardNumber()
        {
            return currentcardnumber;

        }
        public void shuffleCards()
        {
            int timestoshuffle = ranNumberGenerator.Next(11, 100);
            for (int index = 0; index < timestoshuffle; index++)
            {
                for (int r1 = 0; r1 < 52; r1++)
                {
                    int r2 = ranNumberGenerator.Next(52);
                    Card TempCard1 = AllCards[r1];
                    Card TempCard2 = AllCards[r2];

                    AllCards[r1] = TempCard2;
                    AllCards[r2] = TempCard1;
                }
            }
            currentcardnumber = 0;

        }


        public Card GetBackCard()
        {
            return ACardBack;

        }




    }
}