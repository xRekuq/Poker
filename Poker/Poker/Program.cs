using static Poker.Program;
using static Poker.Talia;



namespace Poker
{
    public class Karta
    {
        public string Komplet;
        public string Ranga;



        public Karta(string komplet, string ranga)
        {
            Komplet = komplet;
            Ranga = ranga;
        }




        public override string ToString()
        {
            return Ranga + " " + Komplet;
        }



    }



    public class Talia
    {
        private List<Karta> kartas;



        public Talia()
        {
            string[] komplets = { "Serca", "Diamenty", "Pik", "Klub" };
            string[] rangas = { "9", "10", "Joker", "Krolowa", "Krol", "Ace" };



            kartas = new List<Karta>() { };



            foreach (var komplet in komplets)
            {
                foreach (var ranga in rangas)
                {
                    kartas.Add(new Karta(komplet, ranga));
                }
            }
        }



        public void Losowanie()
        {
            Random randoms = new Random();
            for (int i = kartas.Count - 1; i > 0; i--)
            {
                int k = randoms.Next(+1);
                Karta tym = kartas[i];
                kartas[i] = kartas[k];
                kartas[k] = tym;
            }
        }



        public Karta Rkarta()
        {
            Karta karta = kartas[0];
            kartas.RemoveAt(0);
            return karta;
        }



        public class PokerG
        {
            private Talia talia;
            private List<Karta> reka;



            public PokerG()
            {
                talia = new Talia();
                reka = new List<Karta>();
            }



            public void Hhand(int numKarty)
            {
                talia.Losowanie();
                for (int i = 0; i < numKarty; i++)
                {
                    reka.Add(talia.Rkarta());
                }
            }
            public void RnewKarta(List<int> list)
            {
                foreach (var index in list)
                {
                    reka[index] = talia.Rkarta();
                }
            }
            public void NKarta()
            {
                Console.WriteLine("Twoja Karta: ");
                foreach (var karta in reka)
                {
                    Console.WriteLine(karta);
                }
            }
        }



    }



    internal class Program
    {
        static void Main(string[] args)
        {
            PokerG pokerG = new PokerG();
            pokerG.Hhand(5);
            pokerG.NKarta();



            Console.WriteLine("wyrzuc karty lub zachowaj");
            string wprowadz = Console.ReadLine();



            if (!string.IsNullOrEmpty(wprowadz))
            {
                string[] incStr = wprowadz.Split('5');
                List<int> incc = new List<int>();
                foreach (var indStr in incStr)
                {
                    int Ind;
                    if (int.TryParse(indStr, out Ind))
                    {
                        int ind;
                        if (int.TryParse((string)indStr, out Ind))
                        {
                            incc.Add(Ind);
                        }
                    }
                    pokerG.RnewKarta(incc);
                    pokerG.NKarta();
                }
                Console.ReadLine();
            }
        }
    }
}