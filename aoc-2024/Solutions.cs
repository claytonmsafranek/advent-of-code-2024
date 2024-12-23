﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2024
{
    public class Solutions
    {
        static string[] ReadInputFromFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        static bool IsSafeReport(int[] array)
        {
            if (array.Length < 2)
                return true;

            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 1; i < array.Length; i++)
            {
                int jump = array[i] - array[i - 1];
                if (jump < 1 && jump > -1 || jump > 3 || jump < -3)
                    return false;

                if (jump > 0)
                    isDecreasing = false;
                if (jump < 0)
                    isIncreasing = false;
            }

            return isIncreasing || isDecreasing;
        }

        static bool Day2ProblemDampener(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                // Create a new array with the current element removed
                int[] newArray = new int[array.Length - 1];
                Array.Copy(array, 0, newArray, 0, i);
                Array.Copy(array, i + 1, newArray, i, array.Length - i - 1);

                if (IsSafeReport(newArray))
                    return true;
            }

            return false;
        }

        public void SolveDay1()
        {
            var answer = 0;
            var similarityScore = 0;
            var day1Input = ReadInputFromFile(@"..\..\..\day1-input.txt");


            var locationList1 = new List<int>();
            var locationList2 = new List<int>();
            var numberCounts = new Dictionary<int, int>();

            for (int i = 0; i < day1Input.Length; i++)
            {
                // separate into individual lists
                var numbers = day1Input[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(numbers[0], out int number1) && int.TryParse(numbers[1], out int number2))
                {
                    locationList1.Add(number1);
                    locationList2.Add(number2);
                }
                else
                {
                    throw new Exception("Cannot convert Elvish string location to int");
                }
            }

            // validations
            if (locationList1.Count != locationList2.Count)
            {
                throw new Exception("Number of elements in each list are not equal, the Elvish Historians messed up");
            }

            // sort each list
            locationList1.Sort();
            locationList2.Sort();

            // solve day 1 problem
            for (int i = 0; i< locationList1.Count; i++)
            {
                // find the difference between each location ID
                var difference = locationList1[i] - locationList2[i];
                var tmp = difference < 0 ? difference * -1 : difference;
                answer += tmp;

                // create a dictionary of the second list for part 2 of the problem
                if (numberCounts.ContainsKey(locationList2[i]))
                {
                    numberCounts[locationList2[i]]++;
                }
                else
                {
                    numberCounts[locationList2[i]] = 1;
                }
            }

            // solve part 2 of day 1 problem
            foreach (int number in locationList1)
            {
                if (numberCounts.TryGetValue(number, out int number2)) 
                {
                    var tmp = number * number2;
                    similarityScore += tmp;
                }
            }

            // return the answer
            Console.WriteLine("List distances: " + answer);
            Console.WriteLine("Similarity score: " + similarityScore);
        }

        public void SolveDay2()
        {
            var safeReports = 0;
            var day2Input = ReadInputFromFile(@"..\..\..\day2-input.txt");
            foreach (var line in day2Input)
            {
                var lineData = new List<int>();
                // split the line into an array of numbers
                string[] numberStrings = line.Split(' '); // Split the string by spaces
                int[] numberArray = Array.ConvertAll(numberStrings, int.Parse);

                // check if each line report is safe, if so add to total count
                if (IsSafeReport(numberArray))
                {
                    safeReports += 1;
                }
                else
                {
                    // check with the problem dampener
                    if (Day2ProblemDampener(numberArray))
                    {
                        safeReports += 1;
                    }
                }

            }
            Console.WriteLine("Number of safe reports: " +  safeReports);
        }

    }
}
