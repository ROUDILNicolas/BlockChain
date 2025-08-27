namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Proprietaire proprietaire = new Proprietaire("Patrick","Michel", new DateOnly(1985,5,18));
            proprietaire.ToString();
        }
    }
}
