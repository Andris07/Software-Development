namespace Hanoi_LIB
{
    public class Hanoi
    {
        public Stack<int> A = new Stack<int>();
        public Stack<int> B = new Stack<int>();
        public Stack<int> C = new Stack<int>();
        public int Korongok { get; init; }
        public int mozgások { get; private set; }

        public Hanoi(int korongok)
        {
            this.Korongok = korongok;

            for(int i = korongok; i > 0; i--)
            {
                A.Push(i);
            }
        }

        public static bool KorongÁttevés(Stack<int> innen, Stack<int> ide, ref int mozgások)
        {
            if (ÜresRúd(innen)) throw new ÜresRúdException();

            int áthelyezendőKorong = innen.Pop();

            if (!Áttehető(ide, áthelyezendőKorong))
            {
                innen.Push(áthelyezendőKorong);
                throw new NemTehetőÁtException();
            }

            ide.Push(áthelyezendőKorong);
            mozgások++;
            return true;
        }

        public static bool KorongÁttevés(Stack<int> innen, Stack<int> ide)
        {
            int mozgások = 0;
            return KorongÁttevés(innen, ide, ref mozgások);
        }

        public static bool ÜresRúd(Stack<int> rúd)
        {
            return rúd.Count == 0;
        }

        public static bool Áttehető(Stack<int> rúd, int áthelyezendőKorong)
        {
            if (ÜresRúd(rúd)) return true;
            int felsőKorong = rúd.Peek();
            return áthelyezendőKorong < felsőKorong;
        }

        public static bool JátékVége(Stack<int> A, Stack<int> B, Stack<int> C, int korongok)
        {
            return ÜresRúd(A) && ÜresRúd(B) && !ÜresRúd(C) && C.Count == korongok;
        }

        public void Megjelenítés()
        {
            int szélesség = Korongok * 2 + 1;
            Console.WriteLine();
            Console.WriteLine($"  A ({A.Count})   B ({B.Count})   C ({C.Count})");
            for (int szint = Korongok; szint >= 1; szint--)
            {
                Console.Write($"  {RúdSor(A, szint, szélesség)}   {RúdSor(B, szint, szélesség)}   {RúdSor(C, szint, szélesség)}");
                Console.WriteLine();
            }
            Console.WriteLine($"  {'─'.ToString().PadLeft(szélesség)}   {'─'.ToString().PadLeft(szélesség)}   {'─'.ToString().PadLeft(szélesség)}");
            Console.WriteLine($"     A         B         C");
            Console.WriteLine();
        }

        private string RúdSor(Stack<int> rúd, int szint, int szélesség)
        {
            var lista = new List<int>(rúd);
            if (lista.Count >= szint)
            {
                int korong = lista[lista.Count - szint];
                string csík = new string('█', korong * 2);
                return csík.PadLeft(szélesség);
            }
            return new string(' ', szélesség);
        }
    }
}
