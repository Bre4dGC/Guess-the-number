using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxNumber;
            int maxAttempts;
            string nameOfDifficulty;
            bool playAgain = false;

            while (playAgain != true)
            {
                string gtn = "'УГАДАЙ ЧИСЛО'";
                Console.SetCursorPosition((Console.WindowWidth - gtn.Length) / 2, Console.CursorTop);
                Console.WriteLine(gtn);
                Console.Write("Выберите сложность: easy, medium, hard или extreme: ");
                string difficulty = Console.ReadLine().ToLower(); Console.Clear();

                switch (difficulty)
                {
                    case "easy":
                        nameOfDifficulty = "(EASY)";
                        maxNumber = 10;
                        maxAttempts = 5;
                        break;
                    case "medium":
                        nameOfDifficulty = "(MEDIUM)";
                        maxNumber = 20;
                        maxAttempts = 8;
                        break;
                    case "hard":
                        nameOfDifficulty = "(HARD)";
                        maxNumber = 30;
                        maxAttempts = 12;
                        break;
                    case "extreme":
                        nameOfDifficulty = "(EXTREME)";
                        maxNumber = 50;
                        maxAttempts = 20;
                        break;
                    default:
                        Console.WriteLine("Некорректная сложность. Попробуйте еще раз.");
                        return;
                }



                Random rand = new Random();

                string nod = nameOfDifficulty;
                Console.SetCursorPosition((Console.WindowWidth - nod.Length) / 2, Console.CursorTop);
                Console.WriteLine(nod);

                int number = rand.Next(1, maxNumber + 1), attempt = 1;
                Console.WriteLine($"\nЯ загадал число от 1 до {maxNumber}, у вас {maxAttempts} попыток");
               
                for (int i = 0; i < maxAttempts; i++)
                {   
                    Console.Write("\nЧто это за число: ");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("У вас осталось " + (maxAttempts - i -1) + " попыток");

                    if (userInput <= 0 || userInput >= maxNumber + 1)
                    {
                        Console.WriteLine("\nНе допустимое число");
                    }

                    else if (userInput < number)
                    {
                        Console.WriteLine("Ваше число меньше загаданного");
                    }

                    else if (userInput > number)
                    {
                        Console.WriteLine("Ваше число больше загаданного");
                    }
                    else if (i == 0)
                    {
                        Console.WriteLine("У вас закончились попытки, игра окончена;(");
                        Console.Write("Напишите 'exit' чтобы выйти из игры, или 'again' чтобы начать заново: ");
                        string playAgainResponse = Console.ReadLine().ToLower();

                        if (playAgainResponse == "again")
                            playAgain = false;
                        Console.Clear();

                        break;
                    }

                    else if (userInput == number)
                    {
                        Console.Clear();
                        Console.WriteLine("\nВы угадали, это число " + number);
                        Console.Write("Напишите 'again' чтобы начать заново: ");
                        string playAgainResponse = Console.ReadLine();

                        if (playAgainResponse == "again")
                            playAgain = false;
                        Console.Clear();
                    }
                }
            }
        }
    }
}
