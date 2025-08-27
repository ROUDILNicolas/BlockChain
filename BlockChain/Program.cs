using JsonFileManager;
using System.Text.Json;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Blockchain blockchain = new Blockchain();

            Proprietaire premierProprietaire = new Proprietaire("Nicolas", "Rondil", new DateOnly(2001,12,23));
            Proprietaire deuxiemeProprietaire = new Proprietaire("Nicolas", "Bisti", new DateOnly(1992,05,12));

            Compte premierCompte = new Compte(premierProprietaire, "FR78 5268 4785 4561", 1000);
            Compte deuxiemeCompte = new Compte(deuxiemeProprietaire, "FR78 7893 1596 7531", 2000);

            Transaction premierTransaction = new Transaction(premierCompte, deuxiemeCompte, 500);
            Console.WriteLine(premierTransaction.Status);
            premierTransaction.Apply();
            Console.WriteLine(premierTransaction.Status);
            Block premierBlock = new Block(premierTransaction);
            Console.WriteLine();
            blockchain.AjouterBlock(premierBlock);
            Console.WriteLine();
            Console.WriteLine("Affichage de la blockchain");
            blockchain.AfficherBlockChain();

            Transaction deuxiemeTransaction = new Transaction(deuxiemeCompte, premierCompte, 3000);
            Console.WriteLine(deuxiemeTransaction.Status);
            deuxiemeTransaction.Apply();
            Console.WriteLine(deuxiemeTransaction.Status);
            Block suivant = new Block(deuxiemeTransaction, premierBlock);
            Console.WriteLine();
            blockchain.AjouterBlock(suivant);
            Console.WriteLine();
            Console.WriteLine("Affichage de la blockchain");
            blockchain.AfficherBlockChain();
            Console.WriteLine();

            Transaction troisiemeTransaction = new Transaction(deuxiemeCompte, premierCompte, 500);
            Console.WriteLine(troisiemeTransaction.Status);
            suivant = new Block(troisiemeTransaction, suivant);
            blockchain.AjouterBlock(suivant);
            Console.WriteLine();
            Console.WriteLine("Affichage de la blockchain");
            blockchain.AfficherBlockChain();

            CheckCorruption(blockchain);

            Console.WriteLine("Allez dans le debugger pour corrompre la blockchaine ensuite taper sur entrer");
            Console.ReadLine();
            Console.Write("");// Placer le point d'arret ici et taper entrer ensuite modifier un blockchain et continuer l'éxécution

            CheckCorruption(blockchain);
        }

        private static void CheckCorruption(Blockchain blockchain)
        {
            if (blockchain.CheckCorruption())
            {
                Console.WriteLine("La blockchain n'est pas corrompu");
            }
            else
            {
                Console.WriteLine("La blockchain est corrompu");
            }
        }
    }
}
