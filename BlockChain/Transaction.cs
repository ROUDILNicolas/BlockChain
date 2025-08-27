using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Transaction
    {
        private Compte Creancier;
        private Compte Debiteur;
        private decimal Montant;
        private EStatusType Status;

        public Transaction(Compte creancier, Compte debiteur, decimal montant)
        {
            Creancier = creancier;
            Debiteur = debiteur;
            Montant = montant;
            //TODO le status
        }

        public bool Apply()
        {
            return new Random().Next(2) == 0;
        }

        public enum EStatusType
        {
        }
    }
}
