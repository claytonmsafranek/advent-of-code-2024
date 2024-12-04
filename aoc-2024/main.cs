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
        var solutions = new Solutions();
        switch (problemNumber)
        {
            case 1:
                Console.WriteLine("Solving problem 1...");
                solutions.SolveDay1();
                break;
            case 2:
                Console.WriteLine("Solving problem 2...");
                solutions.SolveDay2();
                break;
            default:
                Console.WriteLine("Problem not implemented yet.");
                break;
        }
    }
}