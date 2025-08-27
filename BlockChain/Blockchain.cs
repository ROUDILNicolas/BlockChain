using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Blockchain
    {
        private List<Block> blocks;

        public Blockchain()
        {
            blocks = new List<Block>();
        }

        public void AjouterBlock(Block block)
        {
            //TODO
        }

        public void AfficherBlockChain()
        {
            //TODO
        }

        public bool CheckCorruption()
        {
            //hasher blocks[0] et comparer avec block[1].HashDuBlockPrecedent
            return new Random().Next(2) == 0;
        }
    }
}
