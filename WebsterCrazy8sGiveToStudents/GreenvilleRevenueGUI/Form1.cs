using System;
using System.Drawing;
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
        Cards DeckofCards = new Cards();
        Hand PlayerHand;
        Hand DealerHand;
        Card BackCard;
        PokerCard CardonTopofPile;
        Boolean GameOver = false;

        public Form1()
        {
            InitializeComponent();
            DeckofCards.shuffleCards();
            PlayerHand = new Hand("Dr. Roger Webster");
            DealerHand = new Hand("Dealer");
            BackCard = DeckofCards.GetBackCard();
            this.Size = new Size(800, 600);
            BigPurpleBucsButton(true);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (GameOver)
            {
                BigPurpleBucsButton(true);
                GameOver = false;
            }
            else
            {
                DealACardtoCardPile();
            }
        }

        private void BigPurpleBucsButton(Boolean shuffle)
        {
            ResetAllHands();
            if (shuffle)
            {
                DeckofCards.shuffleCards();
            }

            DealACardtoDealer();
            DealACardtoPlayer();

            DealACardtoDealer();
            DealACardtoPlayer();

            DealACardtoDealer();
            DealACardtoPlayer();

            DealACardtoDealer();
            DealACardtoPlayer();

            DealACardtoDealer();
            DealACardtoPlayer();

            DealACardtoCardPile();
        }


        private void DealACardtoCardPile()
        {
            PokerCard ACard = DeckofCards.GetNextCard();
            ChangeCardinCardPile(ACard);
        }

        private void ChangeCardinCardPile(PokerCard ACard)
        {
            CardonTopofPile = ACard;
            topofpilecard.BackgroundImage = CardonTopofPile.GetCardImage();
            topofpilecard.Refresh();
            CardonTopofPile.Setdiscarded(true);
        }

        private void DealACardtoPlayer()
        {
            int cardnumber = PlayerHand.GetNumberofCards();
            if (cardnumber < 5)
            {
                PokerCard ACard = DeckofCards.GetNextCard();
                PlayerHand.DealACardtoMe(ACard);
                UpdatePlayerGraphics(cardnumber, false);
            }
        }

        private void DealACardtoPlayerIndex(int cardnumber)
        {
            if (cardnumber < 5)
            {
                PokerCard ACard = DeckofCards.GetNextCard();
                PlayerHand.DealACardtoMeIndex(ACard, cardnumber);
                UpdatePlayerGraphics(cardnumber, false);
            }
        }

        private void DealACardtoDealer()
        {
            int cardnumber = DealerHand.GetNumberofCards();
            if (cardnumber < 5)
            {
                PokerCard ACard = DeckofCards.GetNextCard();
                DealerHand.DealACardtoMe(ACard);
                UpdateDealerGraphics(cardnumber, false);
            }
        }

        private void DealACardtoDealerIndex(int cardnumber)
        {
            if (cardnumber < 5)
            {
                PokerCard ACard = DeckofCards.GetNextCard();
                DealerHand.DealACardtoMeIndex(ACard, cardnumber);
                UpdateDealerGraphics(cardnumber, false);
            }
        }

        private bool CheckDealerHandToPutonTopPile()
        {
            if (DealerHand.GetCardValue(0) == CardonTopofPile.GetCardValue() || DealerHand.GetCardSuit(0) == CardonTopofPile.GetSuitasString() || DealerHand.GetCardValue(0) == 8)
            {
                CardonTopofPile = PlayerHand.GetaCard(0);
                topofpilecard.BackgroundImage = playerbutton1.BackgroundImage;
                topofpilecard.Refresh();
                CardonTopofPile.Setdiscarded(true);
                playerbutton1.BackgroundImage = BackCard.GetCardImage();
                PlayerHand.SetValuetoDiscarded(0);
                return true;
            }
            if (DealerHand.GetCardValue(1) == CardonTopofPile.GetCardValue() || DealerHand.GetCardSuit(1) == CardonTopofPile.GetSuitasString() || DealerHand.GetCardValue(1) == 8)
            {
                CardonTopofPile = PlayerHand.GetaCard(0);
                topofpilecard.BackgroundImage = playerbutton1.BackgroundImage;
                topofpilecard.Refresh();
                CardonTopofPile.Setdiscarded(true);
                playerbutton1.BackgroundImage = BackCard.GetCardImage();
                PlayerHand.SetValuetoDiscarded(1);
                return true;
            }
            if (DealerHand.GetCardValue(2) == CardonTopofPile.GetCardValue() || DealerHand.GetCardSuit(2) == CardonTopofPile.GetSuitasString() || DealerHand.GetCardValue(2) == 8)
            {
                CardonTopofPile = PlayerHand.GetaCard(0);
                topofpilecard.BackgroundImage = playerbutton1.BackgroundImage;
                topofpilecard.Refresh();
                CardonTopofPile.Setdiscarded(true);
                playerbutton1.BackgroundImage = BackCard.GetCardImage();
                PlayerHand.SetValuetoDiscarded(2);
                return true;
            }
            if (DealerHand.GetCardValue(3) == CardonTopofPile.GetCardValue() || DealerHand.GetCardSuit(3) == CardonTopofPile.GetSuitasString() || DealerHand.GetCardValue(3) == 8)
            {
                CardonTopofPile = PlayerHand.GetaCard(0);
                topofpilecard.BackgroundImage = playerbutton1.BackgroundImage;
                topofpilecard.Refresh();
                CardonTopofPile.Setdiscarded(true);
                playerbutton1.BackgroundImage = BackCard.GetCardImage();
                PlayerHand.SetValuetoDiscarded(3);
                return true;
            }
            if (DealerHand.GetCardValue(4) == CardonTopofPile.GetCardValue() || DealerHand.GetCardSuit(4) == CardonTopofPile.GetSuitasString() || DealerHand.GetCardValue(4) == 8)
            {
                CardonTopofPile = PlayerHand.GetaCard(0);
                topofpilecard.BackgroundImage = playerbutton1.BackgroundImage;
                topofpilecard.Refresh();
                CardonTopofPile.Setdiscarded(true);
                playerbutton1.BackgroundImage = BackCard.GetCardImage();
                PlayerHand.SetValuetoDiscarded(4);
                return true;
            }
            return false;
        }

        //--------------------------------------------
        // DEALER AI CODE
        //if player more than 5 cards pass to dealer AI
        // Denomination first before the 8
        //--------------------------------------------
        private void TrytogetridACardtoDealerIndex()
        {
            Boolean getrid = CheckDealerHandToPutonTopPile();
            bool keepgoing = CheckDealerHandforDiscarded();

            if (!getrid)
            {
                DealACardtoDealer();
                keepgoing = CheckDealerHandforDiscarded();
            }
            else
            {
                keepgoing = false;
                MessageBox.Show("Dealer can not go Player's turn");
            }

        }  

    

        //--------------------------------------------
        //PLAYER CARD BUTTONS 
        // when all cards are dealt game is over
        //--------------------------------------------

        public Boolean DealerTryToDiscard()
        {
            bool keepgoing = true;

            while (keepgoing)
            {
                if (CardonTopofPile.GetCardValue() != 8 && CheckDealerForDenoMatch())
                {
                    keepgoing = false;
                    return true;
                }
                else if (CheckDealerForSuitMatch())
                {
                    keepgoing = false;
                    return true;
                }
                else if (CheckDealerFor8Match())
                {
                    keepgoing = false;
                    return true;
                }
                else
                {
                    keepgoing = false;
                }
            }
            return false;
        }

        private bool PlayerTryDiscard(int i)
        {
            if (!PlayerHand.GetIsItDiscarded(i) && PlayerHand.GetCardValue(i) == CardonTopofPile.GetCardValue() || PlayerHand.GetCardSuit(i) == CardonTopofPile.GetSuitasString() || PlayerHand.GetCardValue(i) == 8)
            {
                PlayerHand.SetValuetoDiscarded(i);
                ChangeCardinCardPile(PlayerHand.GetaCard(i));
                UpdatePlayerGraphics(i, true);
                return true;
            }
            else
            {
                MessageBox.Show("Card must have the same denomination or suit as the top card.");
                return false;
            }
        }

        private void playerbutton1_Click(object sender, EventArgs e)
        {
           if (PlayerTryDiscard(0))
            {
                if (!checkPlayerWin())
                {
                    DealerGoGoGo();
                }
                else
                {
                    MessageBox.Show("Player Wins, Dealer Lost!");
                }
            }
        }

        private void playerbutton2_Click(object sender, EventArgs e)
        {
            if (PlayerTryDiscard(1))
            {
                if (!checkPlayerWin())
                {
                    DealerGoGoGo();
                }
                else
                {
                    MessageBox.Show("Player Wins, Dealer Lost!");
                }
            }
        }

        private void playerbutton3_Click(object sender, EventArgs e)
        {
            if (PlayerTryDiscard(2))
            {
                if (!checkPlayerWin())
                {
                    DealerGoGoGo();
                }
                else
                {
                    MessageBox.Show("Player Wins, Dealer Lost!");
                }
            }
        }

        private void playerbutton4_Click(object sender, EventArgs e)
        {
            if (PlayerTryDiscard(3))
            {
                if (!checkPlayerWin())
                {
                    DealerGoGoGo();
                }
                else
                {
                    MessageBox.Show("Player Wins, Dealer Lost!");
                }
            }
        }

        private void playerbutton5_Click(object sender, EventArgs e)
        {
            if (PlayerTryDiscard(4))
            {
                if (!checkPlayerWin())
                {
                    DealerGoGoGo();
                }
                else
                {
                    MessageBox.Show("Player Wins, Dealer Lost!");
                }
            }
        }

        //----------------------------------------------------
        //hit me BUTTON
        //----------------------------------------------------

        private void HITMEbutton_Click(object sender, EventArgs e)
        {
            bool keepgoing = true;
            int HitMeInc = 0;
            while (keepgoing)
            {
                Boolean isdiscarded = PlayerHand.GetIsItDiscarded(HitMeInc);
                if (isdiscarded)
                {
                    DealACardtoPlayerIndex(HitMeInc);
                    HitMeInc = 0;
                    keepgoing = false;
                }
                else
                {
                    HitMeInc++;
                    if (HitMeInc == 5)
                    {
                        keepgoing = false;
                        DealerGoGoGo();
                    }
                }
            }
        }

        private void DealerGoGoGo()
        {
            bool keepgoing = true;

            while (keepgoing)
            {
                if (!DealerTryToDiscard())
                {
                    if (!CheckDealerHandforDiscarded())
                    {
                        keepgoing = false;
                    }
                }
                else
                {
                    keepgoing = false;
                }
            }
            if (checkDealerWin())
            {
                MessageBox.Show("Dealer Won, You Lose!");
            }
        }

        private Boolean CheckDealerForDenoMatch()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!DealerHand.GetIsItDiscarded(i) && DealerHand.GetCardValue(i) == CardonTopofPile.GetCardValue())
                {
                    DealerHand.SetValuetoDiscarded(i);
                    ChangeCardinCardPile(DealerHand.GetaCard(i));
                    UpdateDealerGraphics(i, true);
                    return true;
                }
            }
            return false;
        }

        private Boolean CheckDealerForSuitMatch()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!DealerHand.GetIsItDiscarded(i) && DealerHand.GetCardSuit(i) == CardonTopofPile.GetSuitasString())
                {
                    DealerHand.SetValuetoDiscarded(i);
                    ChangeCardinCardPile(DealerHand.GetaCard(i));
                    UpdateDealerGraphics(i, true);
                    return true;
                }
            }
            return false;
        }

        private Boolean CheckDealerFor8Match()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!DealerHand.GetIsItDiscarded(i) && DealerHand.GetCardValue(i) == 8)
                {
                    DealerHand.SetValuetoDiscarded(i);
                    ChangeCardinCardPile(DealerHand.GetaCard(i));
                    UpdateDealerGraphics(i, true);
                    return true;
                }
            }
            return false;
        }

        private Boolean CheckDealerHandforDiscarded()
        {
            bool DealerHit = true;
            int Num = 0;
            while (DealerHit)
            {
                if (DealerHand.GetIsItDiscarded(Num))
                {
                    DealACardtoDealerIndex(Num);
                    Task.Delay(2000).Wait();
                    DealerHit = false;
                    Num = 0;
                    return true;
                }
                else
                {
                    Num++;
                    if (Num == 5)
                    {
                        DealerHit = false;
                        return false;
                    }
                }
            }
            return false;
        }

        public Boolean checkDealerWin()
        {
            for (int i = 0; i < DealerHand.GetNumberofCards(); i++)
            {
                if (!DealerHand.GetIsItDiscarded(i))
                {

                    return false;
                }
            }
            GameOver = true;
            return (true);
        }
        public Boolean checkPlayerWin()
        {
            for (int i = 0; i < PlayerHand.GetNumberofCards(); i++)
            {
                if (!PlayerHand.GetIsItDiscarded(i))
                {
                    return false;
                }
            }
            GameOver = true;
            return (true);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void testbuttonrww_Click(object sender, EventArgs e)
        {
            DeckofCards.shuffleCards();
            DeckofCards.DealCrazy8stoBoth();
            BigPurpleBucsButton(false);

        }

        //----------------------------------------------------
        //   GRAPHICS METHODS
        //----------------------------------------------------

        private void UpdatePlayerGraphics(int index, Boolean hideimage)
        {
            Card ACard = PlayerHand.GetaCard(index);
            if (hideimage)
            {
                ACard = BackCard;
            }

            switch (index)
            {
                case 0:
                    playerbutton1.BackgroundImage = ACard.GetCardImage();
                    break;
                case 1:
                    playerbutton2.BackgroundImage = ACard.GetCardImage();
                    break;
                case 2:
                    playerbutton3.BackgroundImage = ACard.GetCardImage();
                    break;
                case 3:
                    playerbutton4.BackgroundImage = ACard.GetCardImage();
                    break;
                case 4:
                    playerbutton5.BackgroundImage = ACard.GetCardImage();
                    break;
            }
        }

        private void UpdateDealerGraphics(int cardnumber, Boolean hideimage)
        {
            Card ACard = DealerHand.GetaCard(cardnumber);
            if (hideimage)
            {
                ACard = BackCard;
            }
            switch (cardnumber)
            {
                case 0:
                    dealerbutton1.BackgroundImage = ACard.GetCardImage();
                    break;
                case 1:
                    dealerbutton2.BackgroundImage = ACard.GetCardImage();
                    break;
                case 2:
                    dealerbutton3.BackgroundImage = ACard.GetCardImage();
                    break;
                case 3:
                    dealerbutton4.BackgroundImage = ACard.GetCardImage();
                    break;
                case 4:
                    dealerbutton5.BackgroundImage = ACard.GetCardImage();
                    break;
            }
        }
        private void ResetAllHands()
        {
            DealerHand.ResetHand();
            PlayerHand.ResetHand();
            playerbutton1.BackgroundImage = BackCard.GetCardImage();
            playerbutton2.BackgroundImage = BackCard.GetCardImage();
            playerbutton3.BackgroundImage = BackCard.GetCardImage();
            playerbutton4.BackgroundImage = BackCard.GetCardImage();
            playerbutton5.BackgroundImage = BackCard.GetCardImage();

            dealerbutton1.BackgroundImage = BackCard.GetCardImage();
            dealerbutton2.BackgroundImage = BackCard.GetCardImage();
            dealerbutton3.BackgroundImage = BackCard.GetCardImage();
            dealerbutton4.BackgroundImage = BackCard.GetCardImage();
            dealerbutton5.BackgroundImage = BackCard.GetCardImage();
        }
    }
}



