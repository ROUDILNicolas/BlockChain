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

        /// <summary>
        /// Constructeur de l'objet compte.
        /// </summary>
        /// <param name="proprietaire">Le proprietaire du compte</param>
        /// <param name="iban">L'iban du compte</param>
        /// <param name="solde">Le solde du compte(par défaut = 0)</param>
        public Compte(Proprietaire proprietaire, string iban, decimal solde = 0)
        {
            _solde = solde; 
            _proprietaire = proprietaire;
            _iban = iban;
        }

        /// <summary>
        /// Soustrait un montant du solde d'un compte
        /// uniquement si le Solde est supérieur.
        /// </summary>
        /// <param name="montant">le montant a débiter</param>
        /// <returns></returns>
        public bool DebiterSolde(decimal montant)
        {
            if (this.Solde - montant < 0) 
            { 
                return false;
            }
            
            this.Solde = this.Solde - montant;
            return true;
        }
        /// <summary>
        /// Ajoute un montant au Solde du compte
        /// </summary>
        /// <param name="amount"></param>
        public void CrediterSolde(decimal amount)
        {
            this.Solde = this.Solde + amount;

        }
        /// <summary>
        /// Converti les attributs de l'objet en chaîne de caractères
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Proprietaire.ToString()};{Iban};{Solde.ToString()}";
        }
    }
}
