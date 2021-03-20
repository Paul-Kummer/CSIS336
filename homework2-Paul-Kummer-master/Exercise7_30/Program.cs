using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_30
{
    class Program
    {
        private enum UserGuess
        {
            Exit,
            Invalid,
            High,
            Low,
            Correct
        }

        private enum GameStatus
        {
            Quit,
            Continue
        }

        static void Main(string[] args)
        {
            //Values for AI
            int highValue = 1000, lowValue = 0, roundsToPlay = 1;
            bool enableRobot = false;

            //Values for Game
            Random rAndInt = new Random();
            int playerGuess = 0, numberToGuess, numOfGuesses, rounds = 0, totalGuesses = 0;
            UserGuess playerState = UserGuess.Correct;
            GameStatus gameState = GameStatus.Continue;

            Console.WriteLine("\t\t\t[ Guess The Number! ]\n\n" +
                "\t* Attempt to guess the randomly selected number between (1-1000).\n" +
                "\t* You will be told if you guessed above or below that number.\n" +
                "\t* The game ends when you successfully guess the number.\n" +
                "\t* You can exit the game at any time by guessing ZERO.\n\n");

            Console.Write("Would You Like Artifical Intelligence to Play (Y for yes): ");
            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
                enableRobot = true;
                do
                {
                    Console.Write("\nHow Many Rounds Should AI Play: ");
                } while (!int.TryParse(Console.ReadLine(), out roundsToPlay));
            };

            do
            {
                roundsToPlay = !enableRobot ? ++roundsToPlay : roundsToPlay; //Ensures that the user must stop the game by never exceeding rounds to play

                ++rounds;
                numberToGuess = rAndInt.Next(1, 1001);
                numOfGuesses = 0;
                Console.WriteLine("\n--- A New Game Has Been Started And a Number Has Been Generated ---");
                do
                {
                    int tmpValue = 0;
                    Console.Write("\n(0 to exit), What is your Guess: ");
                    if (enableRobot || int.TryParse(Console.ReadLine(), out tmpValue))
                    {
                        playerGuess = enableRobot ? AI.GuessNumber(highValue, lowValue) : tmpValue;
                        if(enableRobot)
                        {
                            Console.Write($"{playerGuess}");
                        }

                        ++totalGuesses;
                        ++numOfGuesses;
                        if (playerGuess == 0)
                        {
                            playerState = UserGuess.Exit;
                            gameState = GameStatus.Quit;
                            Console.WriteLine("\n\t*** Exiting Game ***");
                        }

                        else if (playerGuess == numberToGuess)
                        {
                            playerState = UserGuess.Correct;
                            Console.WriteLine($"\n\n\t *_-`\\Congratulations/'-_*\n\n" +
                                $"\n\t[     Summary     ]" +
                                $"\n\tThe correct number was: {numberToGuess}" +
                                $"\n\tYour number of guesses: {numOfGuesses}" +
                                $"\n\tNumber of rounds played: {rounds}" +
                                $"\n\tThe average number of guesses until correct is: {totalGuesses/rounds}\n\n");

                            //AI Values reset
                            highValue = 1000;
                            lowValue = 0;
                        }

                        else if (playerGuess < numberToGuess && playerGuess >= 0)
                        {
                            playerState = UserGuess.Low;
                            Console.WriteLine("\n\t--- Your Guess Is Too Low ---");

                            //AI Value
                            lowValue = playerGuess;
                        }

                        else if (playerGuess > numberToGuess && playerGuess <=1000)
                        {
                            playerState = UserGuess.High;
                            Console.WriteLine("\n\t+++ Your Guess Is Too High +++");

                            //AI Value
                            highValue = playerGuess;
                        }

                        else
                        {
                            Console.WriteLine("\n\t! Your Number Is Out of Range !");
                            playerState = UserGuess.Invalid;
                        }
                    }

                    else
                    {
                        Console.WriteLine("\n\t! You Didn't Enter A Valid Number !");
                        playerState = UserGuess.Invalid;
                    }
                } while (playerState != UserGuess.Correct && playerState != UserGuess.Exit);
            } while (gameState == GameStatus.Continue && rounds < roundsToPlay);
            
            Console.WriteLine("\n*** Press Any Key To Exit ***");
            Console.ReadKey(true);
        }  
    }
}
