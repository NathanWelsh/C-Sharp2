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
    class Funds
    {
        private int totalmoney = 0;
        private int betamount = 0;

        public Funds(int initialfunds)
        {
            totalmoney = initialfunds;
        }

        public void SetBetAmount(int betamt)
        {
            betamount = betamt;
        }

        public int GetBetAmount()
        {
            return (betamount);
        }
        public void WonBet()
        {
            totalmoney = totalmoney + betamount;
        }
        public void LostBet()
        {
            totalmoney = totalmoney - betamount;
        }
        public int GetMoney()
        {
            return (totalmoney);
        }
    }
}
