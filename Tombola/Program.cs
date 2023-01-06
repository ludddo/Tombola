using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace Tombola
{
    internal class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            Cartella();
            Cartella();
        }

        static void Cartella() //GENERAZIONE CARTELLA
        {
            
            int[,] numeri = new int[3, 9];
            int[] num_appoggio1 = new int[9];
            int[] decine1 = new int[5];
            int[] num_appoggio2 = new int[9];
            int[] decine2 = new int[5];
            int[] num_appoggio3 = new int[9];
            int[] decine3 = new int[5];
            int x = 0, y = 10;

            //CREAZIONE VALORI PRIMA RIGA

            for (int i = 0; i < 9; i++) //CICLO PER GENERARE 9 VALORI COMPRESI TRA X E Y
            {
                num_appoggio1[i] = random.Next(x, y);
                num_appoggio2[i] = random.Next(x, y);
                num_appoggio3[i] = random.Next(x, y);
                x = x + 10;
                y = y + 10;
                if (num_appoggio1[0] == 0)
                {
                    num_appoggio1[0] = 1;
                }
                if (num_appoggio2[0] == 0)
                {
                    num_appoggio2[0] = 1;
                }
                if (num_appoggio2[i] == num_appoggio1[i])
                {
                    num_appoggio2[i]++;
                }
                if (num_appoggio2[i] == num_appoggio3[i])
                {
                    num_appoggio3[i]++;
                }
                if (num_appoggio1[i] == num_appoggio3[i])
                {
                    num_appoggio3[i]++;
                }
            }

            for (int i = 0; i < 5; i++) //CICLO RANDOM PER SCELTA DECINE
            {
                decine1[i] = random.Next(0, 9);

                for (int j = 0; j < i; j++) //CICLO PER ELIMINAZIONE NUMERO DUPLICATO
                {
                    if (decine1[i] == decine1[j])
                    {
                        i--;
                    }
                }
            }

            for (int i = 0; i < 5; i++) //CICLO RANDOM PER SCELTA DECINE
            {
                decine2[i] = random.Next(0, 9);

                for (int j = 0; j < i; j++) //CICLO PER ELIMINAZIONE NUMERO DUPLICATO
                {
                    if (decine2[i] == decine2[j])
                    {
                        i--;
                    }
                }
            }

            for (int i = 0; i < 5; i++) //CICLO RANDOM PER SCELTA DECINE
            {
                decine3[i] = random.Next(0, 9);

                for (int j = 0; j < i; j++) //CICLO PER ELIMINAZIONE NUMERO DUPLICATO
                {
                    if (decine3[i] == decine3[j])
                    {
                        i--;
                    }
                }
            }

            Array.Sort(decine1);
            Array.Sort(decine2);
            Array.Sort(decine3);

            for (int i = 0; i<5 ;i++) //CICLO IMPOSTAZIONE ARRAY NELLA POSIZIONE CORRETTA
            {
                for (int j = 0; j<9; j++)
                {
                    if (decine1[i] == j)
                    {
                        numeri[0, j] = num_appoggio1[j];
                        
                    }
                }
            }

            for (int i = 0; i < 5; i++) //CICLO IMPOSTAZIONE ARRAY NELLA POSIZIONE CORRETTA
            {
                for (int j = 0; j < 9; j++)
                {
                    if (decine2[i] == j)
                    {
                        numeri[1, j] = num_appoggio2[j];

                    }
                }
            }

            for (int i = 0; i < 5; i++) //CICLO IMPOSTAZIONE ARRAY NELLA POSIZIONE CORRETTA
            {
                for (int j = 0; j < 9; j++)
                {
                    if (decine3[i] == j)
                    {
                        numeri[2, j] = num_appoggio3[j];

                    }
                }
            }

            for (int i = 0; i < numeri.GetLength(0); i++) //STAMPA CARTELLA
            {
                for (int j = 0; j < numeri.GetLength(1); j++)
                {
                    if (numeri[i, j] != 0)
                    {
                        if (numeri[i, j] > 10)
                        {
                            Console.Write(numeri[i, j] + " ");
                        }
                        else
                        {
                            Console.Write(" "+ numeri[i, j] + " ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
