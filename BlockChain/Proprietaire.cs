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

        public Proprietaire(string nom, string prenom, DateOnly dateDeNaissance)
        {
            _nom = nom;
            _prenom = prenom;
            _dateDeNaissance = dateDeNaissance;
        }
    }
}
