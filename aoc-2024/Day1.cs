using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2024
{
    public class Day1
    {
        static string[] ReadInputFromFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public void EvaluateInput()
        {
            var answer = 0;
            var similarityScore = 0;
            var day1Input = ReadInputFromFile("C:\\\\Users\\\\Clayton.Safranek\\\\Documents\\\\projects\\\\aoc-2024\\\\aoc-2024\\\\day1-input.txt");

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


    }
}
