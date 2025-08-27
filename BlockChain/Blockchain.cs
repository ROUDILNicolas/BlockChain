namespace BlockChain
{
    public class Blockchain
    {
        private List<Block> blocks;

        public Blockchain()
        {
            blocks = new List<Block>();
        }

        /// <summary>
        /// Ajoute un block a la liste blocks Si il n'est pas en PENDING
        /// </summary>
        /// <param name="block"></param>
        public void AjouterBlock(Block block)
        {
            if (block.Transaction.Status != EStatusType.PENDING)
            {
                blocks.Add(block);
            }
            
        }

        /// <summary>
        /// Affiche l'ensemble des données composant un block
        /// </summary>
        public void AfficherBlockChain()
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                Block block = blocks[i];
                Console.WriteLine("---------------------");
                Console.WriteLine($"{block.Id}");
                Console.WriteLine($"{block.CreateTime.ToString("dd/MM/yyyy HH:mm:ss")}");
                Console.WriteLine($"{block.Transaction}");
                Console.WriteLine("**********************");
                Console.WriteLine($"{block.HashDuBlockPrecedent}");
                Console.WriteLine($"{block.HashDuBlockActuelle}");
                Console.WriteLine("---------------------");
            }
        }
        /// <summary>
        /// Compare le Hash des 2 block, renvoie true si il y a que 2 block
        /// Et renvoie false si le hash des 2 blocks comparer sont different
        /// Sinon renvoie true
        /// </summary>
        /// <returns></returns>
        public bool CheckCorruption()
        {
            //hasher blocks[0] et comparer avec block[1].HashDuBlockPrecedent
            if (blocks.Count < 2)
            {
                return true;
            }
            for (int i = 1; i < blocks.Count; i++)
            {
                Block blockPre = blocks[i - 1];
                Block blockActuel = blocks[i];
                if (blockPre.HashDuBlockActuelle != blockActuel.HashDuBlockPrecedent)
                {
                    return false;
                }

            }
            return true;
        }
    }
}
