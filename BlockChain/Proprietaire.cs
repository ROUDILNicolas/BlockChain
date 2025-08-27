using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Proprietaire
    {
        private string _nom;
        private string _prenom;
        private DateOnly _dateDeNaissance;

        public string Nom { get { return _nom; } set { _nom = value; } }
        public string Prenom { get { return _prenom; } set { _prenom = value; } }
        public DateOnly DateDeNaissance { get { return _dateDeNaissance; } set { _dateDeNaissance = value; } }
        public Proprietaire(string nom, string prenom, DateOnly dateDeNaissance)
        {
            _nom = nom;
            _prenom = prenom;
            _dateDeNaissance = dateDeNaissance;
        }
    }
}
