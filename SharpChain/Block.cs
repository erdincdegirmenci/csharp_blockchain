using System;
using System.Collections.Generic;
using System.Text;

namespace SharpChain
{
    public class Block
    {
        /// <summary> /// Proof of Work için gerekli Nonce /// </summary>
        public int Nonce { get; set; }

        /// <summary> /// Transaction'ların tutulduğu değişken /// </summary>
        public List<Transaction> Transaction { get; set; }

        /// <summary> /// Önceki blogun hash değeri /// </summary>
        public string PreviousHash { get; set; }

        /// <summary> /// Mevcut blog hash değeri /// </summary>
        public string Hash { get; set; }

        /// <summary> /// Blok oluşturulduğu tarih /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>/// SHA256 hash'ini oluştururken kullanacağımız string değerini döndürdük. /// </summary>
        public override string ToString()
        {
            return Nonce + ":" + PreviousHash + ":" + TimeStamp.ToString() + ":" + GetDataString();
        }

        /// <summary> /// Transaction'ları string'e dönüştüren metod /// </summary>
        private string GetDataString()
        {
            string result = "";
            foreach (var t in Transaction)
            {
                result += t.ToString() + ":";
            }
            return result;
        }
    }
}
