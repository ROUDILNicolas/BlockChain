using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Block
    {
        private int _Id;
        private DateTime _CreateTime;
        private Transaction _Transaction;
        private string _HashDuBlockPrecedent;

        public Block(int id, Transaction transaction, string hashDuBlockPrecedent)
        {
            _Id = id;
            _CreateTime = DateTime.Now;
            _Transaction = transaction;
            _HashDuBlockPrecedent = hashDuBlockPrecedent;
        }

        public Block(Transaction transaction, Block blockPrecedent)
        {
            Id = blockPrecedent.Id + 1;
            CreateTime = DateTime.Now;
            Transaction = transaction;
            _HashDuBlockPrecedent = blockPrecedent.HashDuBlockActuelle;
        }

        public int Id { 
            get 
            { 
                return _Id; 
            }
            private set
            {
                _Id = value;
            }
        }
        public DateTime CreateTime 
        { 
            get 
            { 
                return _CreateTime; 
            }
            private set
            {
                _CreateTime = value;
            }
        }
        public Transaction Transaction { 
            get 
            { 
                return _Transaction; 
            }
            private set
            {
                _Transaction = value;
            }
        }
        public string HashDuBlockPrecedent {
            get 
            { 
                return _HashDuBlockPrecedent; 
            }
            private set
            {
                _HashDuBlockPrecedent = value;
            }
        }

        public string HashDuBlockActuelle { 
            get
            {
                return "";
            }
        }
    }
}
