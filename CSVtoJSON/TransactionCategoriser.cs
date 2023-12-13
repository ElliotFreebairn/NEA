using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEAScripts
{
    public class TransactionCategoriser
    {

        public TransactionCategoriser()
        {

        }

        public bool CheckIfObjectIsEmpty(TransactionData data)
        {
            bool isInvalid = false;
            if (data.DateOfTransaction == null || data.Details == null || data.TransactionType == null || (data.MoneyIn == 0 && data.MoneyOut == 0) || data.Balance == 0)
            {
                isInvalid = true;
            }

            return isInvalid;
        }
    }
}
