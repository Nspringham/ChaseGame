using System;

namespace SmallGame
{
    class Program
    {
        //Attributes / Variables
        static int playerPosX = 1, playerPosY = 1;
        static int enemyPosX, enemyPosY;
        static int length = 10, height = 10;
        static char player = '*', space = '-', enemy = '@';
        static Random random = new Random();

        // Main game
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // Hide the cursor
            enemyPosX = length;
            enemyPosY = height;

            bool continuePress = true;
            while (continuePress)
            {
                Draw();

                if (PlayerCollideWithEnemy()) break;
                
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if ((keyPressed.Key == ConsoleKey.W && playerPosY != 1) || (keyPressed.Key == ConsoleKey.S && playerPosY != length))
                {
                    playerPosY += (keyPressed.Key == ConsoleKey.S) ? 1 : -1;
                }

                if ((keyPressed.Key == ConsoleKey.A && playerPosX != 1) || (keyPressed.Key == ConsoleKey.D && playerPosX != height))
                {
                    playerPosX += (keyPressed.Key == ConsoleKey.D) ? 1 : -1;
                }
                // call the enemy method
                MoveEnemy();
            }
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Do you want to play again? [Y/N]");
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.Y)
            {
                continuePress = true;
            }
            Console.WriteLine("Goodbye");
        }

        // Move the enemy
        static void MoveEnemy()
        {
            if(random.Next(0,11) < 5 && playerPosX != enemyPosX) // X
            {
                if (playerPosX < enemyPosX) --enemyPosX;
                else if (playerPosX > enemyPosX) ++enemyPosX;
            }
            else // Y
            {
                if (playerPosY < enemyPosY) --enemyPosY;
                else if (playerPosY > enemyPosY) ++enemyPosY;
            }
        }

        // Check if the enemy has caught player
        static bool PlayerCollideWithEnemy()
        {
            if (playerPosX == enemyPosX && playerPosY == enemyPosY) return true;
            return false;
            
        }

        // Draw the game
        static void Draw()
        {
            Console.Clear();
            Console.Write(playerPosX + ", " + playerPosY + "\n");
            Console.Write(enemyPosX + ", " + enemyPosY + "\n");
            for (int y = 1; y <= height; ++y)
            {
                for (int x = 1; x <= length; ++x)
                {
                    if (x == playerPosX && y == playerPosY) Console.Write(player);
                    else if (x == enemyPosX && y == enemyPosY) Console.Write(enemy);
                    else Console.Write(space);
                }
                Console.WriteLine();
            }
        }
    }
}
