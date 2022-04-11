using System;
using System.Collections.Generic;
using System.Text;

namespace SharpChain
{
    public class BlockChain
    {
        /// <summary>
        /// Blockchain içerisinde bulunan bloklarımız.
        /// </summary>
        public List<Block> Chain { get; set; }
        /// <summary>
        /// Blok'un doğru Hash değerine sahip olması için hash içerisinde bulunması gereken 0-'sıfır' sayısı
        /// </summary>
        private int Difficulty;
        public BlockChain(Block genesisBlock)
        {
            Difficulty = 2;
            Chain = new List<Block>();
            Chain.Add(genesisBlock);
        }

        /// <summary>
        /// Blok'a ait HASH değerini oluşturmak için kullanılan metodtur
        /// </summary>
        /// <param name="blockToGenerate">Hash'i oluşturulacak blok</param>
        private string GenerateHash(Block generateToBlock)
        {
            GenerateSHA256 sHA256 = new GenerateSHA256();
            return sHA256.GetHash(generateToBlock.ToString());
        }

        /// <summary>
        /// Blok oluşturma ve oluşturulan bloku zincire ekleyen metod
        /// </summary>
        public void Mine(Block blockToAdd)
        {
            blockToAdd.PreviousHash = Chain[Chain.Count - 1].Hash;
            while (true)
            {
                blockToAdd.Nonce++;
                blockToAdd.Hash = GenerateHash(blockToAdd);
                if (IsValid(blockToAdd))
                {
                    break;
                }
            }
            Chain.Add(blockToAdd);
        }

        /// <summary>
        /// Bu metod eklenen blokun hash değerinin istenen zorlukta olup olmadığını kontrol eder
        /// </summary>
        /// <param name="blockToAdd">Hash değeri kontrol edilecek olan blok</param>
        private bool IsValid(Block blockToAdd)
        {
            return blockToAdd.Hash.Substring(0, 2).Equals("00");
        }


        /// <summary>
        /// Geçerli bloktan önceki blokun geçerli olup olmadığını kontrol eden metod
        /// </summary>
        private bool IsValidPreviousBlock(Block currentBlock, Block previousBlock)
        {
            var prevIsValid = IsValid(previousBlock);
            var hashIsCorrect = currentBlock.PreviousHash == previousBlock.Hash;
            var currentIsValid = IsValid(currentBlock);
            return prevIsValid && hashIsCorrect && currentIsValid;

        }

        /// <summary>
        /// Tüm Zincir'in geçerli olup olmadığını kontrol eden metod
        /// </summary>
        private bool IsValidBlockChain(List<Block> blockChain)
        {
            if (blockChain.Count < 2)
                return true;
            for (int i = 1; i < blockChain.Count; i += 2)
            {
                if (!IsValidPreviousBlock(blockChain[i + 1], blockChain[i]))
                    return false;
            }
            if (!IsValidPreviousBlock(blockChain[blockChain.Count - 1], blockChain[blockChain.Count - 2]))
                return false;
            return true;
        }

    }
}
