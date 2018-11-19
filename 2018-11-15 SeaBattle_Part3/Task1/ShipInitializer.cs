using System;


namespace Battle
{
    partial class SeaBattle
    {
        private static void InitializationOfTheNumberOfShips(int[,] masComputerField)
        {
            for (int i = maxNumberOfDecks; i >= 1; i--)        //i - count of descs
            {
                for (int j = i; j <= maxNumberOfDecks; j++)    //j - count of ship
                {
                    SimpleShip(masComputerField, i);
                }
            }
            Console.WriteLine("Computers field:");
            PrintField(masComputerField, sizeX, sizeY);
        }

        private static void SimpleShip(int[,] masComputerField, int decks)
        {
            if (decks != 1)                                     //ComplitShip (decs>1)
            {
                Random rnd = new Random();
                int newRnd = rnd.Next(1, 100);
                if (newRnd % 2 == 0)
                    ComplitShipGorizontal(masComputerField, decks);
                else
                    ComplitShipVertical(masComputerField, decks);
            }
            else
            {
                bool notCheck = true;                           //SimpleShip (decs=1)
                int tryRandom = 0;
                do
                {
                    tryRandom++;
                    int coX = RandomСoordinates(sizeX);
                    int coY = RandomСoordinates(sizeY);
                    if (СheckEnvironment(masComputerField, coX, coY))
                    {
                        masComputerField[coX, coY] = decks;
                        notCheck = false;
                    }
                    if (tryRandom >= maxTry)
                    {
                        Console.WriteLine("Maximum number of attempts to place a ship exceeded");
                        Environment.Exit(0);
                    }
                } while (notCheck);
            }
        }

        private static void ComplitShipGorizontal(int[,] masComputerField, int decks)
        {
            int coX, coY;
            bool notCheck = true;
            int tryRandom = 0;
            do
            {
                tryRandom++;
                coX = RandomСoordinates(sizeX);
                coY = RandomСoordinates(sizeY);
                if ((coX + decks) < sizeX)
                {
                    int colChec = 0;
                    for (int i = coX; i < (coX + decks); i++)
                        if (СheckEnvironment(masComputerField, i, coY))
                            colChec++;
                    if (colChec == decks)
                        notCheck = false;
                }
                if (tryRandom >= maxTry)
                {
                    Console.WriteLine("Maximum number of attempts to place a ship exceeded");
                    Environment.Exit(0);
                }
            } while (notCheck);
            for (int i = coX; i < (coX + decks); i++)
                masComputerField[i, coY] = decks;
        }

        private static void ComplitShipVertical(int[,] masComputerField, int decks)
        {
            int coX, coY;
            bool notCheck = true;
            int tryRandom = 0;
            do
            {
                tryRandom++;
                coX = RandomСoordinates(sizeX);
                coY = RandomСoordinates(sizeY);
                if ((coY + decks) < sizeY)
                {
                    int colChec = 0;
                    for (int i = coY; i < (coY + decks); i++)
                        if (СheckEnvironment(masComputerField, coX, i))
                            colChec++;
                    if (colChec == decks)
                        notCheck = false;
                }
                if (tryRandom >= maxTry)
                {
                    Console.WriteLine("Maximum number of attempts to place a ship exceeded");
                    Environment.Exit(0);
                }
            } while (notCheck);
            for (int i = coY; i < (coY + decks); i++)
                masComputerField[coX, i] = decks;
        }
        private static bool СheckEnvironment(int[,] masField, int x, int y)
        {
            bool possible = true;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if ((i >= 0) & (i < sizeX) & (j >= 0) & (j < sizeY))
                    {
                        if (masField[i, j] != 0)
                        {
                            possible = false;
                            goto ExitCheck;
                        }
                    }
                }
            }
        ExitCheck: return possible;
        }
    }
}