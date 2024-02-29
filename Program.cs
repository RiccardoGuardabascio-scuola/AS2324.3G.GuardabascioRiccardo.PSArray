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
            StampaVotiDispariMaggiori4(ref voti, ref pesi, nVoti);
            double max = voti[0], min = voti[0];
            int posmin = 0, posmax = 0;
            double mediaPonderata = MediaPonderata(voti, pesi, nVoti, ref max, ref min, ref posmin, ref posmax);
            Console.WriteLine($"\nLa media ponderata dei voti è: {mediaPonderata}, il voto minimo è: {min}, in posizione {posmin+1}, mentre il voto massimo è: {max}, in posizione {posmax+1}");
            Console.WriteLine("Inserire un voto per stampare tutti i voti che ricadono nell'intervallo +-0.5");
            int voto = Convert.ToInt32(Console.ReadLine());
            ElencoVotiNellIntorno(voti, pesi, nVoti, voto);
            OrdinaPerVoto(ref voti, ref pesi, nVoti);
            Console.WriteLine("\nVoti e relativi pesi ordinati in ordine crescente");
            Console.WriteLine("Voti     Pesi");
            for (int i = 0; i < nVoti; i++)
            {
                Console.WriteLine($"{voti[i]}         {pesi[i]}");
            }
        }
        static void StampaVotiPesi(double[] voti, int[] pesi, int nVoti)
        {
            Console.WriteLine("Voti     Pesi");
            for(int i=0; i<nVoti; i++)
            {
                Console.WriteLine($"{voti[i]}         {pesi[i]}");
            }
        }
        static void CaricaVettori(ref double[] voti, ref int[] pesi, int nVoti)
        {
            Random random = new Random();
            for (int i = 0; i < nVoti; i++)
            {
                voti[i] = random.NextDouble()*10+1;
                pesi[i] = random.Next(0, 101);
            }
        }

        static void StampaVotiDispariMaggiori4(ref double[] voti, ref int[] pesi, int nVoti)
        {
            Console.WriteLine("Voti in posizioni dispari e maggiori di 4, con i relativi pesi");
            for(int i=0; i < nVoti; i += 2)
            {
                if (voti[i] > 4)
                {
                    Console.WriteLine($"{voti[i]}         {pesi[i]}");
                }
            }
        }

        static double MediaPonderata(double[] voti, int[] pesi, int nVoti, ref double max, ref double min, ref int posmin, ref int posmax)
        {
            double mediaPonderata=0, sommatoriaVotiPesi=0;
            int sommatoriaPesi=0;
            for(int i=0; i < nVoti; i++)
            {
                sommatoriaPesi += pesi[i];
                sommatoriaVotiPesi += voti[i] * pesi[i];
            }
            mediaPonderata = sommatoriaVotiPesi / sommatoriaPesi;
            for(int i=1; i < nVoti; i++)
            {
                if (voti[i] > max)
                {
                    max = voti[i];
                    posmax = i;
                }
                if (voti[i] < min)
                {
                    min = voti[i];
                    posmax = i;
                }
            }
            return mediaPonderata;
        }

        static void ElencoVotiNellIntorno(double[] voti, int[] pesi, int nVoti, int voto)
        {
            for(int i=0; i < nVoti; i++)
            {
                if (voti[i]>voto-0.5 && voti[i] < voto + 0.5)
                {
                    Console.WriteLine($"Il voto {voti[i]} in posizione {i + 1}, è compreso nell'intervallo che va da {voto - 0.5} e {voto + 0.5}");
                }
            }
        }

        static void OrdinaPerVoto(ref double[] voti, ref int[] pesi, int nVoti)
        {
            for (int i = 0; i < nVoti - 1; i++)
            {
                for (int j = 0; j < nVoti - 1 - i; j++)
                {
                    if (voti[j] > voti[j + 1])
                    {
                        double temp = voti[j];
                        voti[j] = voti[j + 1];
                        voti[j + 1] = temp;
                        int temppesi = pesi[j];
                        pesi[j] = pesi[j + 1];
                        pesi[j + 1] = temppesi;
                    }
                }
            }
        }
    }
}

















































