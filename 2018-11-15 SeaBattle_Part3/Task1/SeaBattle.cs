using System;
using System.Collections.Generic;

namespace Battle
{
    struct Deck
    {
        public int coX, coY;
        
        public Deck(int coX, int coY)
        {
            this.coX = coX;
            this.coY = coY;           
        }
    }
    partial class SeaBattle
    {
        const byte sizeX = 10;
        const byte sizeY = 10;
        const byte maxNumberOfDecks = 4;
        const int maxTry = 1000;            //maximum number of attempts to place a ship          
        //
        static void Main(string[] args)
        {
            int[,] masMyField = new int[10, 10];
            int[,] masMyRadar = new int[sizeX, sizeY];           
            int[,] masComputerField = new int[sizeX, sizeY];
            int[,] masComputerRadar = new int[sizeX, sizeY];                   
            const string filePatch = @"D:\1.C#\A-Level\2018-11-15 SeaBattle_Part3\MyField.txt";
            LoadMyField(masMyField, filePatch);
            PrintRadarField(masMyRadar);
            InitializationOfTheNumberOfShips(masComputerField);
            //
            List<Deck> ComplitShip = new List<Deck>();
            ComputerVolley(masComputerRadar, masMyField, ComplitShip);
        }        

        private static void ComputerVolley(int[,] masComputerRadar, int[,] masMyField, List<Deck> ComplitShip)
        { 
            bool extraTurn = false;
            int coX, coY;
           
            //coX = RandomСoordinates(sizeX);
            //coY = RandomСoordinates(sizeY);
            do
            {
                Console.WriteLine("input X ");
                coX = int.Parse(Console.ReadLine());
                Console.WriteLine("input Y ");
                coY = int.Parse(Console.ReadLine());
                do
                {
                    if (masComputerRadar[coX, coY] == 0)
                    {
                        switch (masMyField[coX, coY])
                        {
                            case 0:
                                masComputerRadar[coX, coY] = '*';    //Past, '*',42
                                Console.WriteLine("Past, transition course");
                                break;
                            case 1:
                                Console.WriteLine("Killed, extra turn");                               
                                KilledVolley(masComputerRadar, coX, coY);
                                masComputerRadar[coX, coY] = 'X';    //Killed, 'X',88
                                masMyField[coX, coY] = 'X';          //Killed, 'X',88
                                if (!ComputerFinal(masMyField))
                                    extraTurn = true;
                                else
                                {
                                    Console.WriteLine("Game over! Сongratulations to the computer!");
                                    Environment.Exit(0);
                                }
                                break;
                            default:
                                Console.WriteLine("Hurt or Killed, extra turn");                           
                                Deck deck = new Deck(coX, coY);
                                ComplitShip.Add(deck);
                                if (ComplitShip.Count == masMyField[coX, coY])
                                {
                                    for (int i = 0; i < ComplitShip.Count; i++)
                                    {
                                        KilledVolley(masComputerRadar, ComplitShip[i].coX, ComplitShip[i].coY);
                                    }
                                    for (int i = 0; i < ComplitShip.Count; i++)
                                    {
                                        masComputerRadar[ComplitShip[i].coX, ComplitShip[i].coY] = 'X';    //Killed, 'X',88
                                    }
                                    masMyField[coX, coY] = 'X';          //Hurt or Killed, 'X',88
                                }
                                else
                                {
                                    HurtVolley(masComputerRadar, coX, coY);
                                    masComputerRadar[coX, coY] = 'X';    //Killed, 'X',88
                                    masMyField[coX, coY] = 'X';          //Killed, 'X',88
                                    //
                                    СomputerСenerationСoordinates(ComplitShip);
                                    


                                }

                                if (!ComputerFinal(masMyField))
                                    extraTurn = true;
                                else
                                {
                                    Console.WriteLine("Game over! Сongratulations to the computer!");
                                    Environment.Exit(0);
                                }
                                break;                               
                        }
                    }
                    PrintRadarField(masComputerRadar);
                    PrintRadarField(masMyField);
                } while (false);

                Console.WriteLine("y / n");
                extraTurn = true;
            } while ("y" == Console.ReadLine());
        }

        private static void СomputerСenerationСoordinates(List<Deck> ComplitShip)
        {
             for (int i = x - 1; i <= x + 1; i += 2)
            {
                for (int j = y - 1; j <= y + 1; j += 2)
                {

                    if ((i >= 0) & (i<sizeX) & (j >= 0) & (j<sizeY))
                    {
                        
                    }
}
            }
        }

        private static void HurtVolley(int[,] masComputerRadar, int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i += 2)
            {
                for (int j = y - 1; j <= y + 1; j += 2)
                {

                    if ((i >= 0) & (i < sizeX) & (j >= 0) & (j < sizeY))
                    {
                        masComputerRadar[i, j] = '*';    //Past, '*',42
                    }
                }
            }        
        }

        private static void KilledVolley(int[,] masComputerRadar, int x, int y)
        {
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if ((i >= 0) & (i < sizeX) & (j >= 0) & (j < sizeY))
                    {
                        masComputerRadar[i, j] = '*';    //Past, '*',42
                    }
                }
            }
        }

        private static bool ComputerFinal(int[,] masMyField)
        {
            bool final = true;
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if ((masMyField[i, j]!=0) || (masMyField[i, j] != 88))
                    {
                        final = false;
                        goto ComputerFinal;
                    }
                }
            }
        ComputerFinal: return final;
        }       

        private static int RandomСoordinates(byte size)
        {
            return new Random().Next(size);           
        }

        private static void PrintRadarField(int[,] Radar)
        {
            Console.WriteLine("Radar:");
            PrintField(Radar, sizeX, sizeY);
        }       
    }
}
