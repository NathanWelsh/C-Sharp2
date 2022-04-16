using System;
using System.Drawing;
using System.Windows.Forms;

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Nathan Welsh
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // WAR GiveToStudents code
    // ***********************************************
    public partial class Form1 : Form
    {
        Cards DeckofCards = new Cards();
        Hand PlayerHand;
        Hand DealerHand;
        Card BackCard;

        int DealerTotalScore = 0;
        int PlayerTotalScore = 0;
        public Form1()
        {
            InitializeComponent();
            DeckofCards.shuffleCards();
            PlayerHand = new Hand("Dr. Roger Webster");
            DealerHand = new Hand("Dealer");
            BackCard = DeckofCards.GetBackCard();

            ResetAllHands();
            this.Size = new Size(800, 650);
        }

        private void BigPurpleButton_Click(object sender, EventArgs e)
        {
            ResetAllHands();
            DeckofCards.shuffleCards();

            DealACardtoDealer();
            DealACardtoPlayer();
            EvaluateWar();
        }


        private void EvaluateWar()
        {
            if (PlayerHand.GetTotalValueofCards() > DealerHand.GetTotalValueofCards())
            {
                PlayerTotalScore = PlayerTotalScore + 2;
                PlayerScorelabel.Text = "Player's Score: " + PlayerTotalScore;
                TopMsglabel.Text = "PLAYER WINS!!";
            }
            else
            {
                DealerTotalScore = DealerTotalScore + 2;
                DealerScorelabel.Text = "Dealer's Score: " + DealerTotalScore;
                TopMsglabel.Text = "DEALER WINS!!";
            }
            if (PlayerHand.GetTotalValueofCards() == DealerHand.GetTotalValueofCards())
            {
                TopMsglabel.Text = "TIE this is WAR";
                MessageBox.Show("TIE! " + "\nPlayer total is " + PlayerHand.GetTotalValueofCards() + "\nDealer total is " + DealerHand.GetTotalValueofCards());
                switch (TieBreaker())
                {
                    case 0:
                        break;
                    case 1:
                        PlayerScorelabel.Text = "Player Score " + PlayerTotalScore;
                        PlayerTotalScore = PlayerTotalScore + 8;
                        TopMsglabel.Text = "PLAYER WINS!!";
                        break;
                    case 2:
                        DealerScorelabel.Text = "Player Score " + DealerTotalScore;
                        DealerTotalScore = DealerTotalScore + 8;
                        TopMsglabel.Text = "DEALER WINS!!";
                        break;
                }
            }

        }



        public int TieBreaker()
        {
            // For loop in TieBreaker
            int PlayerTieScore = 0;
            int DealerTieScore = 0;
            int WarCode = 0;// no one wins

            for (int i = 1; i < 4; i++)
            {
                DealACardtoDealer();
                DealACardtoPlayer();
                if (PlayerHand.GetTotalValueofCards() > DealerHand.GetTotalValueofCards())
                {
                    PlayerTieScore++;
                }
                else
                {
                    DealerTieScore++;
                }

                if (PlayerTieScore > DealerTieScore)
                {
                    WarCode = 1;
                }
                else
                {
                    WarCode = 2;
                }
                if (PlayerTieScore == DealerTieScore)
                {
                    WarCode = 0;
                }

            }

            MessageBox.Show("Player tie score " + PlayerTieScore + "\nDealer tie score " + DealerTieScore, "COP2362 BlackJack!");


            return (WarCode);

        }
        private void ResetAllHands()
        {
            DealerHand.ResetHand();
            PlayerHand.ResetHand();
            button4.BackgroundImage = BackCard.GetCardImage();
            label3.Text = " ";

            button5.BackgroundImage = BackCard.GetCardImage();
            label4.Text = " ";

            button6.BackgroundImage = BackCard.GetCardImage();
            label7.Text = " ";

            button7.BackgroundImage = BackCard.GetCardImage();
            label8.Text = " ";

            button3.BackgroundImage = BackCard.GetCardImage();
            label2.Text = " ";

            button11.BackgroundImage = BackCard.GetCardImage();
            label14.Text = " ";

            button12.BackgroundImage = BackCard.GetCardImage();
            label15.Text = "";
        }

        private void DealACardtoPlayer()
        {
            int cardnumber = PlayerHand.GetNumberofCards();
            if (cardnumber < 5)
            {
                Card ACard = DeckofCards.GetNextCard();
                PlayerHand.DealACardtoMe(ACard);
                UpdatePlayerGraphics(cardnumber);
            }

        }

        private void UpdatePlayerGraphics(int index)
        {
            Card ACard = PlayerHand.GetaCard(index);
            switch (index)
            {
                //FIRST Card
                case 0:
                    button4.BackgroundImage = ACard.GetCardImage();
                    label3.Text = " " + ACard.GetCardValue();
                    break;
                //first tie Card
                case 1:
                    button5.BackgroundImage = ACard.GetCardImage();
                    label4.Text = " " + ACard.GetCardValue();
                    break;
                //second tie Card
                case 2:
                    button6.BackgroundImage = ACard.GetCardImage();
                    label7.Text = " " + ACard.GetCardValue();
                    break;
                //third tie Card
                case 3:
                    button7.BackgroundImage = ACard.GetCardImage();
                    label8.Text = " " + ACard.GetCardValue();
                    break;
            }
        }
        private void DealACardtoDealer()
        {
            int cardnumber = DealerHand.GetNumberofCards();
            if (cardnumber < 5)
            {
                Card ACard = DeckofCards.GetNextCard();
                DealerHand.DealACardtoMe(ACard);
                switch (cardnumber)
                {
                    case 0:
                        button2.BackgroundImage = ACard.GetCardImage();
                        label1.Text = " " + ACard.GetCardValue();
                        break;
                    case 1:
                        button3.BackgroundImage = ACard.GetCardImage();
                        label2.Text = " " + ACard.GetCardValue();
                        break;
                    case 2:
                        button11.BackgroundImage = ACard.GetCardImage();
                        label14.Text = " " + ACard.GetCardValue();
                        break;
                    case 3:
                        button12.BackgroundImage = ACard.GetCardImage();
                        label15.Text = " " + ACard.GetCardValue();
                        break;

                }
            }

        }


    }
}


