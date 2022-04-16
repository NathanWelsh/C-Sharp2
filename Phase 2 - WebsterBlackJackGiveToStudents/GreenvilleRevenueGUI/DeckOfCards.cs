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

        public void Dealall4AcestoDealer()
        {
            for (int index = 0; index < 52; index++)
            {
                Card TempCard1 = AllCards[index];
                if (TempCard1.GetAce())
                {
                    putAceinposition(index);
                }
            }
            currentcardnumber = 0;//RWW
                                  //checkdeckofcards();
        }

        private void putAceinposition(int index)
        {
            //recall aces go in (index == 0 || index == 2 || index == 4 || index == 6)
            Boolean notlocatedthenewace = true;
            int aceindex = 0;
            Card AceCard = AllCards[index];

            if (index == aceindex)
            {
                //do nothing it is already in its place
                aceindex = aceindex + 2;// go to the next pos
            }
            else
            {
                while (notlocatedthenewace)
                {
                    Card TempCard1 = AllCards[aceindex];
                    if (TempCard1.GetAce())
                    {
                        TempCard1.SetCardToAceValue11(); // SetCardToAceValue11();
                        aceindex = aceindex + 2;// is already in its place go to the next pos
                    }
                    else
                    {
                        // its ok to swap them AllCards[aceindex] is not an ace
                        Card OriginalCard = AllCards[aceindex];
                        AllCards[aceindex] = AceCard;
                        AllCards[index] = OriginalCard;
                        notlocatedthenewace = false;
                    }
                }
            }
        }

        public void PutAcesFirst()
        {
            int aceindex;

            ShuffleCards();
            for (aceindex = 0; aceindex < 4; aceindex++)
            {
                SetSpecificCard(aceindex, 11);
            }

            SetSpecificCard(aceindex++, 9);
            SetSpecificCard(aceindex++, 5);
            SetSpecificCard(aceindex, 6);

        }

        private void SetSpecificCard(int place, int value)
        {
            int aceindex = place;
            bool keepgoing = true;
            while (keepgoing)
            {
                Card TempCard1 = AllCards[aceindex];

                if (TempCard1.GetCardValue() == value)
                {
                    Card OriginalCard = AllCards[place];// original card spot to swap

                    AllCards[place] = TempCard1;
                    AllCards[aceindex] = OriginalCard;
                    keepgoing = false;
                }
                aceindex++;
            }
        }


        public void DealerlowcardsFirst()
        {
            int aceindex = 0;
            int card9index = 0;
            int card5index = 0;
            int card6index = 0;

            Boolean keepgoing = true;
            ShuffleCards();

            // find a 9
            card9index = aceindex = 0;
            while (keepgoing)
            {
                Card TempCard1 = AllCards[aceindex];

                if (TempCard1.GetCardValue() == 2)
                {
                    Card OriginalCard = AllCards[card9index];// original card spot to swap

                    AllCards[card9index] = TempCard1;//put the 9 in the 5th card spot
                    AllCards[aceindex] = OriginalCard;
                    keepgoing = false;
                }
                aceindex++;

            }

            // find a 3
            card5index = aceindex = 2;
            keepgoing = true;
            while (keepgoing)
            {
                Card TempCard1 = AllCards[aceindex];

                if (TempCard1.GetCardValue() == 3)
                {
                    Card OriginalCard = AllCards[card5index];// original card spot to swap

                    AllCards[card5index] = TempCard1;//put the 5 in the 6th card spot
                    AllCards[aceindex] = OriginalCard;
                    keepgoing = false;
                }
                aceindex++;

            }

            // find a 4 put it in the 4th card spot
            card6index = aceindex = 4;
            keepgoing = true;
            while (keepgoing)
            {
                Card TempCard1 = AllCards[aceindex];

                if (TempCard1.GetCardValue() == 4)
                {
                    Card OriginalCard = AllCards[card6index];// original card spot to swap

                    AllCards[card6index] = TempCard1;//put the 6 in the 7th card spot
                    AllCards[aceindex] = OriginalCard;
                    keepgoing = false;
                }
                aceindex++;

            }

            // find a 3 put it in the 5th card spot
            card6index = aceindex = 5;
            keepgoing = true;
            while (keepgoing)
            {
                Card TempCard1 = AllCards[aceindex];

                if (TempCard1.GetCardValue() == 3)
                {
                    Card OriginalCard = AllCards[card6index];// original card spot to swap

                    AllCards[card6index] = TempCard1;//put the 6 in the 7th card spot
                    AllCards[aceindex] = OriginalCard;
                    keepgoing = false;
                }
                aceindex++;

            }

            // find a 2 put it in the 6th card spot
            card6index = aceindex = 6;
            keepgoing = true;
            while (keepgoing)
            {
                Card TempCard1 = AllCards[aceindex];

                if (TempCard1.GetCardValue() == 2)
                {
                    Card OriginalCard = AllCards[card6index];// original card spot to swap

                    AllCards[card6index] = TempCard1;//put the 6 in the 7th card spot
                    AllCards[aceindex] = OriginalCard;
                    keepgoing = false;
                }
                aceindex++;

            }

            currentcardnumber = 0;//RWW
        }

    }
}
