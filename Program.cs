namespace AS2324._3G.GuardabascioRiccardo.PSArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Riccardo Guardabascio 3G PSArray");
            Console.WriteLine("Inserire il numero di voti");
            int nVoti=Convert.ToInt32(Console.ReadLine());
            double[] voti=new double[nVoti];
            int[] pesi=new int[nVoti];
            CaricaVettori(ref voti, ref pesi, nVoti);
            Console.WriteLine("I voti con in relativi pesi:");
            StampaVotiPesi(voti, pesi, nVoti);

        }
        static void StampaVotiPesi(double[] voti, int[] pesi, int nVoti)
        {
            Console.WriteLine("Voti     Pesi");
            for(int i=0; i<nVoti; i++)
            {
                Console.WriteLine($"{voti[i]}      {pesi[i]}");
            }
        }
        static void CaricaVettori(ref double[] voti, ref int[] pesi, int nVoti)
        {
            Random random = new Random();
            for (int i = 0; i < nVoti; i++)
            {
                voti[i] = random.Next(0,11);
                pesi[i] = random.Next(0, 101);
            }
        }

    }
}
