using System;

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
            int[,] numeri = new int[3, 9];
            int[] num_appoggio = new int[9];
            int[] decine = new int[5];
            int x = 0, y = 10;

            //CREAZIONE VALORI PRIMA RIGA

            for (int i = 0; i < 9; i++) //CICLO PER GENERARE 9 VALORI COMPRESI TRA X E Y
            {
                num_appoggio[i] = random.Next(x, y);
                x = x + 10;
                y = y + 10;
                if (num_appoggio[0] == 0)
                {
                    num_appoggio[0] = 1;
                }
            }

            for (int i = 0; i < 5; i++) //CICLO RANDOM PER SCELTA DECINE
            {
                decine[i] = random.Next(0, 9);

                for (int j = 0; j < i; j++) //CICLO PER ELIMINAZIONE NUMERO DUPLICATO
                {
                    if (decine[i] == decine[j])
                    {
                        i--;
                        break;
                    }
                }
            }

            Array.Sort(decine);

            for (int i = 0; i<5 ;i++)
            {
                for (int j = 0; j<9; j++)
                {
                    if (decine[i] == j)
                    {
                        numeri[0, j] = num_appoggio[j];
                        
                    }
                }
            }

            for (int i = 0; i < numeri.GetLength(0); i++) //CICLO STAMPA VALORI PRIMA RIGA
            {
                for (int j = 0; j < numeri.GetLength(1); j++)
                {
                    if (numeri[0, j] != 0)
                    {
                        Console.Write(numeri[0, j] + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
