using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

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
        DeckOfCards DeckOfCards = new DeckOfCards();
        Hand DealerHand = new Hand("Dealer");
        Hand PlayerHand = new Hand("Nathan Welsh");
        Image HitMeGreyedout;
        Image HitMeok;
        Image StayButtonGreyedout;
        Image StayButtonok;
        Image BackofCard;
        Funds myfunds = new Funds(5000);



        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(800, 700);
            //button1.AutoSize = true;

            BackofCard = Image.FromFile("ButtonImages/Wfswbackcard.gif");

            HitMeGreyedout = Image.FromFile("ButtonImages/hitmegreyedout.png");
            HitMeok = Image.FromFile("ButtonImages/hitme200x175.png");

            StayButtonGreyedout = Image.FromFile("ButtonImages/staygreyedout.png");
            StayButtonok = Image.FromFile("ButtonImages/stay200x157.png");

            HitMeButton.BackgroundImage = HitMeGreyedout;
            HitMeButton.Enabled = false;

            StayButton.BackgroundImage = StayButtonGreyedout;
            StayButton.Enabled = false;

        }

        public void BigPurplebutton(Boolean DoShuffle)
        {
            TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();

            myfunds.SetBetAmount((int)numericUpDown1.Value);

            ResetGraphics();

            if (myfunds.GetBetAmount() > myfunds.GetMoney())
            {
                numericUpDown1.Value = myfunds.GetMoney();
                myfunds.SetBetAmount(myfunds.GetBetAmount());
            }

            HitMeButton.BackgroundImage = HitMeok;
            HitMeButton.Enabled = true;

            StayButton.BackgroundImage = StayButtonok;
            StayButton.Enabled = true;

            if (DoShuffle)
            {
                DeckOfCards.ShuffleCards();
            }

            DealerHand.ResetHand();
            PlayerHand.ResetHand();

            Card somecard = DeckOfCards.GetNextCard();
            DealerHand.DealACardToMe(somecard);

            DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();

            somecard = DeckOfCards.GetNextCard();
            PlayerHand.DealACardToMe(somecard);

            somecard = DeckOfCards.GetNextCard();
            DealerHand.DealACardToMe(somecard);

            somecard = DeckOfCards.GetNextCard();
            PlayerHand.DealACardToMe(somecard);

            if (PlayerHand.GetTotalValue() == 21 && DealerHand.GetTotalValue() == 21)
            {
                FlipDealerCard();
                DisplayDealerGraphics();
                DisplayPlayerGraphics();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("It's a tie game");
            }


            if (PlayerHand.GetTotalValue() == 21 && DealerHand.GetTotalValue() < 21)
            {
                FlipDealerCard();
                DisplayDealerGraphics();
                DisplayPlayerGraphics();
                myfunds.WonBet();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("Congrats you win! You got 21!");
            }

            if (DealerHand.GetTotalValue() == 21 && PlayerHand.GetTotalValue() < 21)
            {
                FlipDealerCard();
                DisplayDealerGraphics();
                DisplayPlayerGraphics();
                myfunds.LostBet();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You lost, Dealer got 21!");
            }

            DisplayDealerGraphics();

            DisplayPlayerGraphics();
        }

        private void BigPurpleButton_Click(object sender, EventArgs e)
        {
            BigPurplebutton(true);

        }

        public void DisplayDealerGraphics()
        {


            for (int i = 0; i < DealerHand.GetNumberofCards(); i++)
            {
                Card acard = DealerHand.GetaCard(i);
                switch (i)
                {
                    case 0:
                        DealerCard1.Image = acard.GetCardImage();
                        DealerCardAmount1.Text = " " + acard.GetCardValue();
                        break;
                    case 1:
                        //DealerCard2.Image = acard.GetCardImage();
                        //DealerCardAmount2.Text = " ";
                        break;
                    case 2:
                        DealerCard3.Image = acard.GetCardImage();
                        DealerCardAmount3.Text = " " + acard.GetCardValue();
                        break;
                    case 3:
                        DealerCard4.Image = acard.GetCardImage();
                        DealerCardAmount4.Text = " " + acard.GetCardValue();
                        break;
                    case 4:
                        DealerCard5.Image = acard.GetCardImage();
                        DealerCardAmount5.Text = " " + acard.GetCardValue();
                        break;
                }

            }
        }

        public void DisplayPlayerGraphics()
        {


            for (int i = 0; i < PlayerHand.GetNumberofCards(); i++)
            {
                Card acard = PlayerHand.GetaCard(i);
                switch (i)
                {
                    case 0:
                        PlayerCard1.Image = acard.GetCardImage();
                        PlayerCardAmount1.Text = " " + acard.GetCardValue();
                        break;
                    case 1:
                        PlayerCard2.Image = acard.GetCardImage();
                        PlayerCardAmount2.Text = " " + acard.GetCardValue();
                        break;

                    case 2:
                        PlayerCard3.Image = acard.GetCardImage();
                        PlayerCardAmount3.Text = " " + acard.GetCardValue();
                        break;

                    case 3:
                        PlayerCard4.Image = acard.GetCardImage();
                        PlayerCardAmount4.Text = " " + acard.GetCardValue();
                        break;

                    case 4:
                        PlayerCard5.Image = acard.GetCardImage();
                        PlayerCardAmount5.Text = " " + acard.GetCardValue();
                        break;

                }

            }
            PlayerTotalLabel.Text = "Player's Total Value: " + PlayerHand.GetTotalValue();
        }

        private void HitMeButton_Click(object sender, EventArgs e)
        {
            if (PlayerHand.GetNumberofCards() >= 4)
            {
                HitMeButton.BackgroundImage = HitMeGreyedout;
                HitMeButton.Enabled = false;
            }

            if (DealACardToPlayer())
            {
                if (PlayerHand.GetTotalValue() == 21)
                {
                    PlayerHas21();
                }
            }
            else
            {
                HitMeButton.BackgroundImage = HitMeGreyedout;
                HitMeButton.Enabled = false;
            }
        }

        private void PlayerHas21()
        {
            HitMeButton.BackgroundImage = HitMeGreyedout;
            HitMeButton.Enabled = false;

            StayButton.BackgroundImage = StayButtonGreyedout;
            StayButton.Enabled = false;

            myfunds.WonBet();
            TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
            FlipDealerCard();
            DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
            MessageBox.Show("Congrats you win! You have 21!");
        }

        private void FlipDealerCard()
        {
            Card acard = DealerHand.GetaCard(1);

            DealerCard2.Image = acard.GetCardImage();
            DealerCardAmount2.Text = " " + acard.GetCardValue();

            DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();

            HitMeButton.BackgroundImage = HitMeGreyedout;
            HitMeButton.Enabled = false;
        }
        private Boolean DealACardToPlayer()
        {
            int numberofcards = PlayerHand.GetNumberofCards();

            if (numberofcards < 5)
            {
                Card somecard = DeckOfCards.GetNextCard();

                PlayerHand.DealACardToMe(somecard);

                DisplayPlayerGraphics();
                return (true);
            }
            return (false);
        }

        private void StayButton_Click(object sender, EventArgs e)
        {
            HitMeButton.BackgroundImage = HitMeGreyedout;
            HitMeButton.Enabled = false;

            StayButton.BackgroundImage = StayButtonGreyedout;
            StayButton.Enabled = false;

            FlipDealerCard();
            DisplayDealerGraphics();

            if (PlayerHand.GetTotalValue() > 21)
            {
                PlayerHand.AceTotal(16);
            }

            bool deal = true;
            while (deal)
            {
                if (DealerHand.GetNumberofCards() >= 5) // Dealer has 5 cards end while loop
                {
                    deal = false;
                }
                else
                {
                    if (IsDealerBusted())
                    {
                        DealerCheckAce();
                    }
                    if (DealerHand.GetTotalValue() <= 17 || PlayerHand.GetTotalValue() > DealerHand.GetTotalValue() && !IsDealerBusted())
                    {
                        Card somecard = DeckOfCards.GetNextCard();
                        DealerHand.DealACardToMe(somecard);
                        DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                        if (IsDealerBusted())
                        {
                            DealerCheckAce();
                        }
                    }
                    else
                    {
                        deal = false;
                    }
                }
            }
            FlipDealerCard();
            CheckWinner();
        }

        public void CheckWinner()
        {
            if (PlayerHand.GetTotalValue() > 21 && DealerHand.GetTotalValue() > 21) // Both Player and Dealer Busts
            {
                DisplayDealerGraphics();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You both have lost. Nobody wins!");
            }
            if (DealerHand.GetTotalValue() <= 21 && DealerHand.GetTotalValue() > PlayerHand.GetTotalValue()) // Dealer Wins Logic
            {
                myfunds.LostBet();
                DisplayDealerGraphics();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You have lost. Dealer wins!");
                CheckMoney();
            }
            if (PlayerHand.GetTotalValue() > 21 && DealerHand.GetTotalValue() <= 21)
            {
                myfunds.LostBet();
                DisplayDealerGraphics();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You have lost. Dealer wins!");
                CheckMoney();
            }
            if (PlayerHand.GetTotalValue() <= 21 && PlayerHand.GetTotalValue() > DealerHand.GetTotalValue()) // Player Wins Logic 
            {
                myfunds.WonBet();
                DisplayDealerGraphics();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You Win. Dealer lost!");
            }
            if (DealerHand.GetTotalValue() > 21 && PlayerHand.GetTotalValue() <= 21)
            {
                myfunds.WonBet();
                DisplayDealerGraphics();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You Win. Dealer lost!");
            }
            if (DealerHand.GetTotalValue() <= 21 && PlayerHand.GetTotalValue() <= 21 && PlayerHand.GetTotalValue() == DealerHand.GetTotalValue())
            {
                DisplayDealerGraphics();
                TotalFundsLabel.Text = "Funds: " + myfunds.GetMoney();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("Tie Game. Nobody wins!");
            }
        }

        public void ResetGraphics()
        {

            PlayerCard3.Image = BackofCard;
            PlayerCardAmount3.Text = "";
            PlayerCard4.Image = BackofCard;
            PlayerCardAmount4.Text = "";
            PlayerCard5.Image = BackofCard;
            PlayerCardAmount5.Text = "";

            DealerCard2.Image = BackofCard;
            DealerCardAmount2.Text = "";
            DealerCard3.Image = BackofCard;
            DealerCardAmount3.Text = "";
            DealerCard4.Image = BackofCard;
            DealerCardAmount4.Text = "";
            DealerCard5.Image = BackofCard;
            DealerCardAmount5.Text = "";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            myfunds.SetBetAmount((int)numericUpDown1.Value);
        }
        public bool IsDealerBusted()
        {
            if (DealerHand.GetTotalValue() > 21)
            {
                DealerCheckAce();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                return true;
            }
            return false;
        }
        public bool DealerCheckAce()
        {
            if (DealerHand.GetTotalValue() > 21 && DealerHand.HasAces())
            {
                for (int i = 0; i < DealerHand.GetNumberofCards(); i++)
                {
                    if (DealerHand.GetaCard(i).GetAce() && DealerHand.GetaCard(i).GetCardValue() == 11)
                    {
                        DealerHand.GetaCard(i).ToggleAce();
                        DealerHand.SetTotal();
                        DisplayDealerGraphics();
                        return true;
                    }
                }
            }
            return false;
        }

        public void CheckMoney()
        {
            if (myfunds.GetMoney() <= 0)
            {
                MessageBox.Show("You don't have anymore money. Sell your house and come back.");
                Application.Exit();
            }
        }

        private void GiveAll4AcestoDealer_Click_1(object sender, EventArgs e)
        {
            //deal 4 aces
            DeckOfCards.ShuffleCards();
            DeckOfCards.Dealall4AcestoDealer();
            BigPurplebutton(false);
            DealerTotalLabel.Text = "Total Value of Dealer Hand is ?? ";
            DealerTotalLabel.Refresh();
        }

        private void GiveMeAces_Click(object sender, EventArgs e)
        {
            // Give Me Aces
            PlayerHand.ResetHand();
            DealerHand.ResetHand();
            DeckOfCards.PutAcesFirst();
            BigPurplebutton(false);
            DealerTotalLabel.Text = "Total Value of Dealer Hand is ?? ";
        }

        private void PlayerCard1_Click(object sender, EventArgs e)
        {
            PlayerHand.GetaCard(0).ToggleAce();
            PlayerHand.SetTotal();
            PlayerTotalLabel.Text = "Player's Total Value: " + PlayerHand.GetTotalValue();
            DisplayPlayerGraphics();
        }

        private void PlayerCard2_Click(object sender, EventArgs e)
        {
            PlayerHand.GetaCard(1).ToggleAce();
            PlayerHand.SetTotal();
            PlayerTotalLabel.Text = "Player's Total Value: " + PlayerHand.GetTotalValue();
            DisplayPlayerGraphics();
        }

        private void PlayerCard3_Click(object sender, EventArgs e)
        {
            PlayerHand.GetaCard(2).ToggleAce();
            PlayerHand.SetTotal();
            PlayerTotalLabel.Text = "Player's Total Value: " + PlayerHand.GetTotalValue();
            DisplayPlayerGraphics();
        }

        private void PlayerCard4_Click(object sender, EventArgs e)
        {
            PlayerHand.GetaCard(3).ToggleAce();
            PlayerHand.SetTotal();
            PlayerTotalLabel.Text = "Player's Total Value: " + PlayerHand.GetTotalValue();
            DisplayPlayerGraphics();
        }

        private void PlayerCard5_Click(object sender, EventArgs e)
        {
            PlayerHand.GetaCard(4).ToggleAce();
            PlayerHand.SetTotal();
            PlayerTotalLabel.Text = "Player's Total Value: " + PlayerHand.GetTotalValue();
            DisplayPlayerGraphics();
        }
    }
}

