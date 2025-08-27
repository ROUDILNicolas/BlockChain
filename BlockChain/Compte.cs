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

        public Proprietaire Proprietaire { get { return _proprietaire; } set { _proprietaire = value; } }
        public string Iban { get { return _iban; } set { _iban = value; } }
        public decimal Solde { get { return _solde; } set {_solde = value; } }

        public Compte(Proprietaire proprietaire, string iban) : this(proprietaire, iban, 0)
        {

        }

        public Compte(Proprietaire proprietaire, string iban, decimal solde)
        {
            _solde = solde; 
            _proprietaire = proprietaire;
            _iban = iban;
        }


        public bool DebiterSolde(decimal montant)
        {
            return new Random().Next(2) == 0;
        }
        public void CrediterSolde(decimal amount)
        {
            //TODO
        }

        public override string ToString()
        {
            return $"{Proprietaire.ToString()};";
        }
    }
}
