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
        PokerCard[] MyCards = new PokerCard[5];
        int totalvalue = 0;
        int numberofcards = 0;

        public Hand(String Name)
        {
            NameofPlayer = Name;
        }
        public void DealACardtoMe(PokerCard ACard)
        {
            if (numberofcards < 5)
            {
                MyCards[numberofcards] = ACard;

                totalvalue = totalvalue + ACard.GetCardValue();
                numberofcards++;
            }
        }

        public void DealACardtoMeIndex(PokerCard ACard, int index)
        {
            
                MyCards[index] = ACard;
                MyCards[index].Setdiscarded(false);
                totalvalue = totalvalue + ACard.GetCardValue();
                
            
        }

        public int GetNumberofCards()
        {
            return numberofcards;
        }
        public Boolean GetIsanAce(int index)
        {
            if (index < numberofcards)
            {
                if (MyCards[index].GetCardisanAce())
                {
                    return true;
                }
            }
            return false;
        }
        public int GetCardValue(int index)
        {
            return (MyCards[index].GetCardValue());
        }

        
        public String GetCardValueasString(int index)
        {
            String val = MyCards[index].GetCardValueString();
            return (val);
        }

        public String GetCardSuit(int index)
        {
            return (MyCards[index].GetSuitasString());
        }

        public void SetValuetoDiscarded(int index)
        {
            MyCards[index].Setdiscarded(true);//means that we can take cards
            
        }

        public Boolean GetIsItDiscarded(int index)
        {
            return(MyCards[index].Getdiscarded());

        }



        public PokerCard GetaCard(int index)
        {
            if (index < numberofcards)
                return MyCards[index];
            else 
                return null;
        }

        public int GetTotalValueofCards()
        {
            totalvalue = 0;
            for (int i = 0; i < numberofcards; i++)
            {
                totalvalue = totalvalue + MyCards[i].GetCardValue();
            }
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
