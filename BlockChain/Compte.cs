using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Compte
    {
        private Proprietaire _proprietaire;
        private string _iban;
        private decimal _solde;

        public Compte(Proprietaire proprietaire, string iban)
        {
            _proprietaire = proprietaire;
            _iban = iban;
            _solde = 0;
        }

        public Compte(Proprietaire proprietaire, string iban, decimal solde) : this(proprietaire, iban)
        {
            _solde = solde;
        }


        public bool DebiterSolde(decimal montant)
        {
            return new Random().Next(2) == 0;
        }
        public void CrediterSolde(decimal amount)
        {
            //TODO
        }
    }
}
