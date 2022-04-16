using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Nathan Welsh
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // ***********************************************
    class DeckOfCards
    {
        Random ranNumberGenerator;
        int currentcardnumber = 0;
        Card[] AllCards = new Card[52];
        Card ACardBack;


        public DeckOfCards()
        {
            ranNumberGenerator = new Random();
            LoadCards();
            ShuffleCards();
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
                cardvalue = 11;//aces
            return cardvalue;
        }
        public Card GetNextCard()
        {
            if (currentcardnumber == 52)
            {
                ShuffleCards();
                currentcardnumber = 0;
            }
            return (AllCards[currentcardnumber++]);
        }

        public void ShuffleCards()
        {
            int timetoshuffle = ranNumberGenerator.Next(11, 100);
            for (int index = 0; index < timetoshuffle; index++)
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
        public Card GetBackOfCard()
        {
            return (ACardBack);
        }

    }
}
