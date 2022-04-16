using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Dr. Roger Webster
    // Written by: Nathan Welsh
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // ***********************************************
    class Hand
    {
        String NameofPlayer;
        Card[] MyCards = new Card[5];
        int totalvalue = 0;
        int numberofcards = 0;
  
        public Hand(String Name)
        {
            NameofPlayer = Name;
        }
        public void DealACardtoMe(Card ACard)
        {
            if (numberofcards < 5)
            {
                MyCards[numberofcards] = ACard;
              
                totalvalue = totalvalue + ACard.GetCardValue();
                numberofcards++;
            }
        }

        public int GetNumberofCards()
        {
            return numberofcards;
        }
        public Boolean GetIsanAce(int index)
        {
            if (MyCards[index].GetCardisanAce())
            {
                return true;
            }
            return false;
        }
    
            
        public Card GetaCard(int index)
        {
            if (index < numberofcards)
                return MyCards[index];
            else return null;
        }

        public int GetTotalValueofCards()
        {
            return totalvalue;
        }
        public void ResetHand()
        {
            totalvalue = 0;
            numberofcards = 0;
            for (int i = 0; i < 5; i++)
            {
                MyCards[i] = null;
            }

        }

    }
}
