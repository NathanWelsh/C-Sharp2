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

        private void BigPurpleButton_Click(object sender, EventArgs e)
        {

            ResetGraphics();

            HitMeButton.BackgroundImage = HitMeok;
            HitMeButton.Enabled = true;

            StayButton.BackgroundImage = StayButtonok;
            StayButton.Enabled = true;

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
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("Congrats you win! You got 21!");
            }

            if (DealerHand.GetTotalValue() == 21 && PlayerHand.GetTotalValue() < 21)
            {
                FlipDealerCard();
                DisplayDealerGraphics();
                DisplayPlayerGraphics();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You lost, Dealer got 21!");
            }

            DisplayDealerGraphics();

            DisplayPlayerGraphics();

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
                        //DealerCardAmount2.Text = "0 ";
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

            int numberofcards = DealerHand.GetNumberofCards();

            if (PlayerHand.GetTotalValue() > 21)
            {
                HitMeButton.BackgroundImage = HitMeGreyedout;
                HitMeButton.Enabled = false;
                StayButton.BackgroundImage = StayButtonGreyedout;
                StayButton.Enabled = false;
                DisplayDealerGraphics();
                FlipDealerCard();
                DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                MessageBox.Show("You have busted. Dealer wins!");
            }
            else
            {
                bool deal = true;
                while (deal)
                {
                    if (DealerHand.GetTotalValue() <= 17 && DealerHand.GetTotalValue() < PlayerHand.GetTotalValue())
                    {

                        Card somecard = DeckOfCards.GetNextCard();
                        DealerHand.DealACardToMe(somecard);
                        FlipDealerCard();
                        DisplayDealerGraphics();
                        DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();

                    }
                    else
                    {
                        deal = false;
                    }
                    if (PlayerHand.GetTotalValue() > DealerHand.GetTotalValue())
                    {
                        Card somecard = DeckOfCards.GetNextCard();
                        DealerHand.DealACardToMe(somecard);
                        FlipDealerCard();
                        DisplayDealerGraphics();
                        DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                    }
                    if (DealerHand.GetTotalValue() > 21)
                    {
                        deal = false;
                        DisplayDealerGraphics();
                        FlipDealerCard();
                        DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                        MessageBox.Show("Dealer has busted. You win!");
                    }
                    if (numberofcards > 5)
                    {
                        deal = false;
                    }
                    if (DealerHand.GetTotalValue() <= 21 && DealerHand.GetTotalValue() > PlayerHand.GetTotalValue())
                    {
                        deal = false;
                        DisplayDealerGraphics();
                        FlipDealerCard();
                        DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                        MessageBox.Show("You have lost. Dealer wins!");
                    }
                    if (DealerHand.GetTotalValue() == PlayerHand.GetTotalValue())
                    {
                        deal = false;
                        DisplayDealerGraphics();
                        FlipDealerCard();
                        DealerTotalLabel.Text = "Dealer's Total Value: " + DealerHand.GetTotalValue();
                        MessageBox.Show("Tie game!");
                    }
                }
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

    }
}

