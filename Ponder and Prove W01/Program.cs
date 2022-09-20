/**
 * Author: Brandon Smith
 * Program: Tic-Tac-Toe Game
 * Week: 02
 * Class: CSE 210
 * **/
namespace Ponder_Prove_W01
{
    class Program
    {
        static void DisplayGame(string[] board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        static string CheckForWin(string[] board, string player)
        {
            // Check if the board is filled
            bool filled = true;
            foreach (string item in board)
            {
                if (item.All(Char.IsNumber)) // if there are remaining numbers 
                {
                    filled = false; // then board is not filled
                }
            }
            // Probably a better way to do this but I couldn't think of the logic
            string message = "";
            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                message = $"{player} is the winner";
            }
            else if(filled) // if board filled but no winner
            {
                message = $"You both tied";
            }

            return message;
        }

        static void PlayGame()
        {
            string[] board = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int choice = 0;
            string input = "";
            string player = "x";
            bool playing = true;
            string anouncment = "";
            while (playing)
            {
                // Display the board
                DisplayGame(board);
                if (player == "x")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{player}'s turn to choose a square(1-9):");
                Console.ForegroundColor = ConsoleColor.White;
                // Get input from user with slight input validation
                input = Console.ReadLine();
                if (input == null || !input.All(Char.IsNumber) || input == "" || input.Length > 1) Console.WriteLine("Please enter a number(1-9)");
                else
                {
                    choice = int.Parse(input);

                    if (board[choice - 1].All(Char.IsLetter))
                    {
                        Console.WriteLine("That place has already been taken.");
                    }
                    else
                    {
                        if (choice == 0) playing = false;
                        else
                        {
                            board[choice - 1] = player.ToString(); // Change board
                        }

                        // Check for a winner
                        anouncment = CheckForWin(board, player);
                        if (anouncment.Length > 0)
                        {
                            playing = false;
                            // Display the board
                            DisplayGame(board);
                            Console.WriteLine(anouncment);
                            break;
                        }

                        // If no winner Switch users
                        if (player == "x") player = "o";
                        else player = "x";
                    } 
                }
            }
        }

        static void Main(string[] args)
        {
            // Allows you to play again as many times as you want
            bool keepPlaying = true;
            while (keepPlaying)
            {
                PlayGame(); // Start new game
                string input = "";
                while (input == "") // Check if you want to play again
                {
                    Console.Write("Do you want to play again (y/n):");
                    input = Console.ReadLine().ToLower();
                    if (input != "y" && input != "n")
                    {
                        Console.WriteLine("Invalid input");
                        input = "";
                    }
                }
                if(input == "n") 
                    keepPlaying = false;
            }
        }
    }
}