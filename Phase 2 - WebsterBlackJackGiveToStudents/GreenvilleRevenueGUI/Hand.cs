using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenvilleRevenueGUI
{
    //**********************************************
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

            GetNumberofCards();
            GetTotalValue();
            //ResetHand();
        }

        public void DealACardToMe(Card ACard)
        {
                MyCards[numberofcards++] = ACard;
                totalvalue = totalvalue + ACard.GetCardValue();            
        }

        public void AceTotal(int i)
        {
            totalvalue = i;
        }

        public int GetNumberofCards()
        {
            return numberofcards;
        }

        public Card GetaCard(int index)
        {
            if (index < numberofcards)
            {
                return (MyCards[index]);
            }
            else
            {
                return (null);
            }
                
        }

        public int GetTotalValue()
        {
            return totalvalue;
        }

        public void ResetHand()
        {
            totalvalue = 0;
            numberofcards = 0;
            for (int i = 0; i < 5; i++)
            {
                if (GetaCard(i) != null && GetaCard(i).GetAce())
                {
                    if (GetaCard(i).GetCardValue() == 1)
                    {
                        GetaCard(i).ToggleAce();
                    }
                }
                MyCards[i] = null;
            }
        }

        public bool HasAces()
        {
            for (int i = 0; i < MyCards.Length; i++)
            {
                if (GetaCard(i) != null && GetaCard(i).GetAce())
                {
                    return true;
                }
            }
            return false;
        }

        public int ChangeAnyAcesValueto1()
        {
            int ChangedanAceto1Index = -1;
            for (int i = 0; i < numberofcards; i++)
            {
                if (MyCards[i].GetAce())
                {
                    if (MyCards[i].GetCardValue() == 11)
                    {
                        MyCards[i].SetCardToAceValue1();  // SetCardToAceValue1();
                        GetTotalValue();
                        ChangedanAceto1Index = i;
                        return (ChangedanAceto1Index);
                    }
                }

            }
            return (ChangedanAceto1Index);
        }
        public void SetTotal()
        {
            int newtotal = 0;

            for (int i = 0; i < GetNumberofCards(); i++)
            {
                int cardvalue = GetaCard(i).GetCardValue();
                newtotal = newtotal + cardvalue;
            }
            totalvalue = newtotal;
        }
    }
}
