using System;
using System.Collections.Generic;
using System.Text;

namespace SharpChain
{
    public class Transaction
    {
        /// <summary> /// Coin gönderen /// </summary>
        public string Sender { get; set; }

        /// <summary> /// Coin alan kişi /// </summary>
        public string Receiver { get; set; }

        public float Value { get; set; }

        public override string ToString()
        {
            return Sender + ":" + Receiver + ":" + Value;
        }
    }
}
