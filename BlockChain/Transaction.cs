using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Transaction
    {
        // Déclaration des attributs et accésseurs
        private static int NbTransaction { get; set; }
        public int ID { get; private set; }
        public Compte Creancier { get; private set; }
        public Compte Debiteur { get; private set; }
        public decimal Montant { get; private set; }
        public EStatusType Status { get; private set; }

        /// <summary>
        /// Constructeur d'une Transaction
        /// </summary>
        /// <param name="creancier">Compte à crediter</param>
        /// <param name="debiteur">Compte à débiter</param>
        /// <param name="montant">Montant de la transaction</param>
        public Transaction(Compte creancier, Compte debiteur, decimal montant)
        {
            ID = ++NbTransaction;
            Creancier = creancier;
            Debiteur = debiteur;
            Montant = montant;
            Status = EStatusType.PENDING;
        }

        /// <summary>
        /// Return true ou false si le débit sur le compte débiteur est possible, puis modifie la valeur de l'attribut Status
        /// </summary>
        /// <returns></returns>
        public bool Apply()
        {
            if (Debiteur.DebiterSolde(Montant))
            {
                Creancier.CrediterSolde(Montant);
                Status = EStatusType.DONE;
                return true;
            } 
            Status = EStatusType.FAILED;
            return false;
            
        }

        /// <summary>
        /// Affiche les détails de la trasaction en format CSV
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ID};{Creancier};{Debiteur};{Montant};{Status}";
        }
    }

    // Définition des valeurs de EStatusType
    public enum EStatusType
    {
        PENDING,
        FAILED,
        DONE
    }
}
