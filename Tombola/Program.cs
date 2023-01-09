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
            int[,] player1,player2,player3 = new int[3,9];
            int[] numTabel = new int[90];
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("Giocatore 1");
            player1 = Cartella(3);
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("Giocatore 2");
            player2 = Cartella(13);
            Console.SetCursorPosition(5, 21);
            Console.WriteLine("Giocatore 3");
            player3 = Cartella(23);
            Console.SetCursorPosition(55, 1);
            Console.WriteLine("TABELLONE");
            numTabel = Tabellone();
            Tombola(player1, player2, player3);
        }

        static void Tombola(int[,] gioc1, int[,] gioc2, int[,]gioc3) //GENERAZIONE NUMERI CASUALI E CONTROLLO TOMBOLA
        {
            int[] numero = new int[90];
            int playe1=0,playe2=0,playe3=0;
            int coordsX = 52, coordsY=1;

            for (int i = 0; i < 90; i++) //CICLO RANDOM PER SCELTA NUMERO ESTRATTO
            {
                numero[i] = random.Next(1, 91);

                for (int j = 0; j < i; j++) //CICLO PER ELIMINAZIONE NUMERO DUPLICATO
                {
                    if (numero[i] == numero[j])
                    {
                        i--;
                    }
                }
            }

            for (int k = 0; k < 90; k++) //CONTROLLO NUMERO USCITO E AGGIORNAMENTO TABELLONE
            {
                coordsX = 52; 
                coordsY = 3;
                if (playe1 == 15) //CONTROLLO INTERROMPIMENTO CICLO
                {
                    break;
                }
                if (playe2 == 15)
                {
                    break;
                }
                if (playe3 == 15)
                {
                    break;
                }
                for (int l = 0; l < 90; l++) //AGGIORNAMENTO TABELLONE
                {
                    if (l != 0)
                    {
                        if (l % 10 == 0)
                        {
                            if (numero[k] == l)
                            {
                                Console.SetCursorPosition(coordsX, coordsY);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(numero[k]);
                                coordsX = 52;
                                coordsY++;
                                coordsY++;
                                break;
                            }
                            coordsX = 52;
                            coordsY++;
                            coordsY++;
                        }
                    }
                    if (numero[k] == l)
                    {
                        if (numero[k] < 10)
                        {

                            Console.SetCursorPosition(coordsX, coordsY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(numero[k]);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(coordsX, coordsY);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(numero[k]);
                            break;
                        }
                    }
                    coordsX = coordsX + 3;
                }
                
                Thread.Sleep(400);

                for (int i = 0; i < gioc1.GetLength(0); i++) 
                {
                    if (playe1 == 15)
                    {
                        break;
                    }
                    if (playe2 == 15)
                    {
                        break;
                    }
                    if (playe3 == 15)
                    {
                        break;
                    }
                    for (int j = 0; j < gioc1.GetLength(1); j++)
                    {
                        
                        if (numero[k] == gioc1[i, j])
                        {
                            playe1++;
                        }
                        if (numero[k] == gioc2[i, j])
                        {
                            playe2++;
                        }
                        if (numero[k] == gioc3[i, j])
                        {
                            playe3++;
                        }
                        if (playe1 == 15)
                        {
                            Console.SetCursorPosition(55, 20);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Tombola! Giocatore 1 HA VINTO!!!");
                            break;
                        }
                        if (playe2 == 15)
                        {
                            Console.SetCursorPosition(55, 21);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Tombola! Giocatore 2 HA VINTO!!!");
                            break;
                        }
                        if (playe3 == 15)
                        {
                            Console.SetCursorPosition(55, 22);
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.WriteLine("Tombola! Giocatore 3 HA VINTO!!!");
                            break;
                        }
                        if (playe1 == 15 || playe2 == 15 || playe3 == 15) //CONTROLLO CHIUSURA CICLO
                        {
                            break;
                        }
                    }
                        
                    
                }
            }
            
        }

        static int[] Tabellone() //GENERAZIONE TABELLONE
        {
            int[] tabellone = new int[90];
            int x = 0;
            int coordsX = 55, coordsY = 3;

            for (int i = 0; i < 91; i++) //CARICAMENTO TABELLONE
            {
                
                if (i != 0)
                {
                    tabellone[x] = i;
                    x++;
                }
                
            }

            for (int k=0; k < 90; k++) //VISUALIZZAZIONE TABELLONE
            {
                if (k != 0)
                {
                    if (k % 10 == 0)
                    {
                        coordsX = 55;
                        coordsY++;
                        coordsY++;
                    }
                }
                if (tabellone[k] < 10)
                {

                    Console.SetCursorPosition(coordsX, coordsY);
                    
                    Console.Write(tabellone[k]);
                }
                else
                {
                    Console.SetCursorPosition(coordsX, coordsY);
                    
                    Console.Write(tabellone[k]);
                }
                coordsX = coordsX + 3;
            }
            return tabellone;
        }

        static int[,] Cartella(int coordy) //GENERAZIONE CARTELLA
        {
            
            int[,] numeri = new int[3, 9];
            int[] num_appoggio1 = new int[9];
            int[] decine1 = new int[5];
            int[] num_appoggio2 = new int[9];
            int[] decine2 = new int[5];
            int[] num_appoggio3 = new int[9];
            int[] decine3 = new int[5];
            int x = 0, y = 10;
            int coordsX = 5, coordsY = coordy;

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
                            Console.SetCursorPosition(coordsX, coordsY);
                            Console.Write(numeri[i, j]);
                        }
                        else
                        {
                            Console.SetCursorPosition(coordsX, coordsY);
                            Console.Write(numeri[i, j]);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(coordsX, coordsY);
                        Console.Write("__");
                    }
                    coordsX++;
                    coordsX++;
                    coordsX++;
                }
                coordsX = 5;
                coordsY++;
                coordsY++;
            }

            Console.WriteLine();
            return numeri;
        }


    }
}
