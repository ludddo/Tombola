using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cartella();
        }

        
        static void Cartella() //GENERAZIONE CARTELLA
        {
            Random random = new Random();
            int[,] numeri = new int[9, 3];
            int[] num_appoggio = new int[9];
            int[] decine = new int[9];
            int x = 0, y = 10;

            //CREAZIONE VALORI PRIMA RIGA

            for (int i = 0; i < 9; i++) //CICLO PER GENERARE 9 VALORI COMPRESI TRA X E Y
            {
                num_appoggio[i] = random.Next(x, y);
                x = x + 10;
                y = y + 10;
                Console.WriteLine(num_appoggio[i]);
            }

            for (int i = 0; i < 5; i++) //CICLO RANDOM PER SCELTA DECINE
            {
                decine[i] = random.Next(0, 9);
                for (int j = 0; j < i; j++)
                {
                    if (decine[i] == decine[j])
                    {
                        i--;
                        break;
                    }
                }
            }
        }
    }
}
