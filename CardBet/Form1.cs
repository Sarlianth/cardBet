using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardBet
{
    public partial class Form1 : Form
    {
        public static Random random = new Random();
        public int randomCard;
        public int myCard;
        public int sec;
        public int betAmount;
        public int wallet;
        public int winAmt;

        public Form1()
        {
            InitializeComponent();
            wallet = CardBet.Properties.Settings.Default.setWallet;
            label4.Text = "Wallet: €" + wallet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == true)
            {

            }
            else
            {
                button2.Image = CardBet.Properties.Resources.reset;
                button1.Image = CardBet.Properties.Resources.betClick;

                if (radioButton1.Checked == true && wallet >= 10) 
                {
                    method();
                }
                else if (radioButton2.Checked == true && wallet >= 15)
                {
                    method();
                }
                else if (radioButton3.Checked == true && wallet >= 25)
                {
                    method();
                }
                else if (radioButton4.Checked == true && wallet >= 50)
                {
                    method();
                }
                else if (radioButton5.Checked == true)
                {
                    betAmount = (int)numericUpDown1.Value;
                    if (betAmount <= wallet)
                    {
                        method();
                    }
                    else
                    {
                        errorMessage();
                    }
                }
                else if(radioButton6.Checked == true && wallet>=1)
                {
                    method();
                }
                else
                {
                    errorMessage();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec -= 1;
            if (sec == 0)
            {
                if (myCard == randomCard)
                {
                    
                    if (radioButton9.Checked == true)
                    {
                        winAmt = betAmount * 5;
                    }
                    else if (radioButton8.Checked == true)
                    {
                        winAmt = betAmount * 3;
                    }
                    if (radioButton7.Checked == true)
                    {
                        winAmt = betAmount * 2;
                    }
                    wallet += winAmt;
                    label3.Text = "You WON €" + winAmt;
                    label4.Text = "Wallet: €" + wallet;
                }
                else
                {
                    wallet -= betAmount;
                    label3.Text = "You LOST €" + betAmount;
                    label4.Text = "Wallet: €" + wallet;
                }
                button1.Image = CardBet.Properties.Resources.bet;
                timer1.Stop();
            }
        }

        private void generateCard()
        {
            if (radioButton9.Checked == true)
            {
                randomCard = random.Next(1, 14);
            }
            else if (radioButton8.Checked == true)
            {
                randomCard = random.Next(1, 10);
            }
            else if (radioButton7.Checked == true)
            {
                randomCard = random.Next(1, 6);
            }
        }

        private void switchRandomCard()
        {
            switch (randomCard)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources._2;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources._3;
                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources._4;
                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources._5;
                    break;

                case 5:
                    pictureBox1.Image = Properties.Resources._6;
                    break;

                case 6:
                    pictureBox1.Image = Properties.Resources._7;
                    break;

                case 7:
                    pictureBox1.Image = Properties.Resources._8;
                    break;

                case 8:
                    pictureBox1.Image = Properties.Resources._9;
                    break;

                case 9:
                    pictureBox1.Image = Properties.Resources._10;
                    break;

                case 10:
                    pictureBox1.Image = Properties.Resources.J;
                    break;

                case 11:
                    pictureBox1.Image = Properties.Resources.Q;
                    break;

                case 12:
                    pictureBox1.Image = Properties.Resources.K;
                    break;

                case 13:
                    pictureBox1.Image = Properties.Resources.A;
                    break;
            }
        }

        private void userCard()
        {
            if (card2.Checked == true)
            {
                myCard = 1;
            }
            else if (card3.Checked == true)
            {
                myCard = 2;
            }
            else if (card4.Checked == true)
            {
                myCard = 3;
            }
            else if (card5.Checked == true)
            {
                myCard = 4;
            }
            else if (card6.Checked == true)
            {
                myCard = 5;
            }
            else if (card7.Checked == true)
            {
                myCard = 6;
            }
            else if (card8.Checked == true)
            {
                myCard = 7;
            }
            else if (card9.Checked == true)
            {
                myCard = 8;
            }
            else if (card10.Checked == true)
            {
                myCard = 9;
            }
            else if (cardJ.Checked == true)
            {
                myCard = 10;
            }
            else if (cardQ.Checked == true)
            {
                myCard = 11;
            }
            else if (cardK.Checked == true)
            {
                myCard = 12;
            }
            else if (cardA.Checked == true)
            {
                myCard = 13;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {

            }
            else
            {
                button2.Image = CardBet.Properties.Resources.resetClick;
                wallet = 1000;
                String message = "You have restarted the game!\nHowever, you can still load your wallet balance!" + "\nYour wallet amount is: " + wallet;
                String title = "Restart!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons);
                timer1.Start();
                timer1.Stop();
                label3.Text = "";
                label4.Text = "Wallet: €" + wallet;
            }
        }

        private void method()
        {
            sec = 2;
            timer1.Start();
            label3.Text = "";

            if (radioButton1.Checked == true)
            {
                betAmount = 10;
            }
            else if (radioButton2.Checked == true)
            {
                betAmount = 15;
            }
            else if (radioButton3.Checked == true)
            {
                betAmount = 25;
            }
            else if (radioButton4.Checked == true)
            {
                betAmount = 50;
            }
            else if (radioButton5.Checked == true)
            {
                betAmount = (int)numericUpDown1.Value;
            }
            else if (radioButton6.Checked == true)
            {
                betAmount = wallet;
            }

            generateCard();

            userCard();

            switchRandomCard();
        }

        private void errorMessage()
        {
            MessageBox.Show("You don't have enough money in your wallet\nPlease choose different bet amount or reset statistics to start again!\nGood luck!",
            "Game over",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            String message, title;
            message = "Are you sure you want to exit the game?";
            title = "Exit";
            result = MessageBox.Show(message, title, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            card7.Enabled = true;
            card8.Enabled = true;
            card9.Enabled = true;
            card10.Enabled = true;
            cardJ.Enabled = false;
            cardQ.Enabled = false;
            cardK.Enabled = false;
            cardA.Enabled = false;
            card2.Checked = true;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            card7.Enabled = false;
            card8.Enabled = false;
            card9.Enabled = false;
            card10.Enabled = false;
            cardJ.Enabled = false;
            cardQ.Enabled = false;
            cardK.Enabled = false;
            cardA.Enabled = false;
            card2.Checked = true;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            card7.Enabled = true;
            card8.Enabled = true;
            card9.Enabled = true;
            card10.Enabled = true;
            cardJ.Enabled = true;
            cardQ.Enabled = true;
            cardK.Enabled = true;
            cardA.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CardBet.Properties.Settings.Default.setWallet = wallet;
            CardBet.Properties.Settings.Default.Save();
            String message = "You have saved your wallet, you can exit the game and load it at any time!"+"\nYour wallet amount is: "+wallet;
            String title = "Wallet Saved!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons);
        }

        private void loadWallet()
        {
            wallet = CardBet.Properties.Settings.Default.setWallet;
            label4.Text = "Wallet: €" + wallet;

            String message = "You have loaded you wallet!" + "\nYour wallet amount is: " + wallet;
            String title = "Wallet Loaded!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadWallet();
        }
    }
}
