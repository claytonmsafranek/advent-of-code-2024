using aoc_2024;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter the number of the AOC day to solve that day's problem: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= 25)
            {
                SolveProblem(choice);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void SolveProblem(int problemNumber)
    {
        switch (problemNumber)
        {
            case 1:
                // Add code to solve problem 1
                Console.WriteLine("Solving problem 1...");
                var day1 = new Day1();
                day1.EvaluateInput();
                break;
            case 2:
                // Add code to solve problem 2
                Console.WriteLine("Solving problem 2...");
                break;
            // Add more cases as needed
            default:
                Console.WriteLine("Problem not implemented yet.");
                break;
        }
    }
}