using System.Security.Cryptography;
using System.Text;

namespace BlockChain
{
    public class Block
    {
        private static int BlockInstanceCompteur = 0;

        private int _Id;
        private DateTime _CreateTime;
        private Transaction _Transaction;
        private string _HashDuBlockPrecedent;

        /// <summary>
        /// Constructeur d'un block
        /// </summary>
        /// <param name="id">L'id du block</param>
        /// <param name="transaction">La transaction éfféctuer</param>
        /// <param name="hashDuBlockPrecedent">Le hash du block précédent</param>
        public Block(Transaction transaction, string hashDuBlockPrecedent)
        {
            _Id = BlockInstanceCompteur;
            BlockInstanceCompteur++;
            _CreateTime = DateTime.Now;
            _Transaction = transaction;
            _HashDuBlockPrecedent = hashDuBlockPrecedent;
        }

        /// <summary>
        /// Création du block avec la transaction et le block précédent
        /// </summary>
        /// <param name="transaction">La transaction éfféctuer</param>
        /// <param name="blockPrecedent">Le block précédent</param>
        public Block(Transaction transaction, Block blockPrecedent): this (transaction, blockPrecedent.HashDuBlockActuelle)
        {
        }

        /// <summary>
        /// Constructeur pour crée le premier block
        /// </summary>
        /// <param name="transaction"></param>
        public Block(Transaction transaction) : this(transaction, "0")
        {
            
        }

        /// <summary>
        /// L'Id du block
        /// </summary>
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
        /// <summary>
        /// La date et l'heure ou le block à été crée
        /// </summary>
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
        /// <summary>
        /// La transaction du block actuelle
        /// </summary>
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
        /// <summary>
        /// Le hash du block précédent
        /// </summary>
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

        /// <summary>
        /// Va crée un hash de l'instance actuelle
        /// </summary>
        public string HashDuBlockActuelle { 
            get
            {
                //on retourne directement le contenue de l'instance encoder
                return Encode();
            }
        }

        /// <summary>
        /// Format l'objet sur le format CSV
        /// </summary>
        /// <returns>
        /// L'objet en CSV 
        /// Id;TimeStamp;NomCréditeur;PrénomCréditeur;DateAniversaireCréditeur;IbanCréditeur;SoldeCréditeur;NomDébiteur;PrénomDébiteur;DateAniversaireDébiteur;IbanDébiteur;SoldeDébiteur;HashDuBlockPrécédent
        /// </returns>
        public override string ToString()
        {
            //on convertit au format CSV le block
            return $"{Id};{GetTimestamp(CreateTime)};{Transaction};{HashDuBlockPrecedent}";
        }

        private string Encode()
        {
            //on déclare et initialize la classe SHA256
            SHA256 sha256 = SHA256.Create();
            //on récuper les octets qui servent à représenter la chaine de charactère avec le format UTF-8
            byte[] inputBytes = Encoding.UTF8.GetBytes(ToString());
            //on hash les octets avec l'algorithm sha256
            byte[] hash = sha256.ComputeHash(inputBytes);
            //on crée un StringBuilder afin de transformer la liste d'octet en une chaine de charactère
            StringBuilder sb = new StringBuilder();
            foreach (byte t in hash)
            {
                //Format le string en hexadecimal minuscule
                sb.Append(t.ToString("x2"));
            }
            //on retourne le hash décoder en string
            return sb.ToString();
        }

        //convertit la date en timestamp
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
