using System;
using System.IO;

namespace Battle
{
    partial class SeaBattle
    {
        private static void LoadMyField(int[,] masField, string filePatch)
        {
            var file = new StreamReader(filePatch);
            string line;
            int i = 0;
            while ((line = file.ReadLine()) != null)
            {
                for (int j = 0; j < 10; j++)
                {
                    masField[i, j] = int.Parse(line[j].ToString());
                }
                i++;
            }
            file.Close();
            Console.WriteLine("My field:");
            PrintField(masField, 10, 10);
        }

        private static void PrintField(int[,] masField, byte sizeX, byte sizeY)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (masField[i, j] != 0)
                    {

                        if (masField[i, j] == 42)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("*" + " ");
                        }
                        else if (masField[i, j] == 88)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("X" + " ");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write(masField[i, j] + " ");
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(masField[i, j] + " ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}