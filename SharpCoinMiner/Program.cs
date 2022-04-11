using SharpChain;
using System;
using System.Collections.Generic;

namespace SharpCoinMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain blockChain = new BlockChain(new Block()
            {
                Transaction = new List<Transaction>(),
                Hash = "00000000000000000000000000000000000000000000000000000",
                Nonce = 1,
                PreviousHash = "00000000000000000000000000000000000000000000000000000",
                TimeStamp = DateTime.UtcNow
            });

            for (int i = 0; i < 3; i++)
            {
                List<Transaction> transactionDatas = new List<Transaction>();
                transactionDatas.Add(new Transaction()
                {
                    Receiver = "0xf24bf668aa087990f1d40ababf841456e771913c",
                    Sender = "0x67b5dc04d4116be379779547c474a1f7c3af26c6",
                    Value = i + 10
                });
                Block blockItem = new Block()
                {
                    Transaction = transactionDatas,
                    TimeStamp = DateTime.Now
                };
                blockChain.Mine(blockItem);
            }

        }
    }
}
