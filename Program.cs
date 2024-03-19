using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int numStudents = 5;
            int[] finalExamScores = new int[numStudents];

            // Get students' exam scores
            GetExamScores(finalExamScores, numStudents);

            // Display all exam scores
            DisplayAllExamScores(finalExamScores);

            // Display the highest exam score and its index
            DisplayHighestScore(finalExamScores);

            // Display the lowest exam score and its index
            DisplayLowestScore(finalExamScores);

            // Display the average exam score for the class
            DisplayAverageScore(finalExamScores);

            // Keep the console open until a key is pressed
            Console.ReadKey();
        }

        static void GetExamScores(int[] scores, int numStudents)
        {
            for (int i = 0; i < numStudents; i++)
            {
                bool validInput = false;
                do
                {
                    try
                    {
                        Console.Write($"Enter final exam score for student {i + 1}: ");
                        int score = Convert.ToInt16(Console.ReadLine());

                        if (score < 0 || score > 100)
                            throw new ArgumentException("Score must be between 0 and 100.");

                        scores[i] = score;
                        validInput = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                    }
                } while (!validInput);
            }
        }

        static void DisplayAllExamScores(int[] scores)
        {
            Console.WriteLine("\nAll exam scores:");
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine($"Student {i + 1}: {scores[i]}");
            }
        }

        static void DisplayHighestScore(int[] scores)
        {
            int maxScore = scores[0];
            int maxIndex = 0;
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > maxScore)
                {
                    maxScore = scores[i];
                    maxIndex = i;
                }
            }
            Console.WriteLine($"\nHighest exam score: {maxScore} (Student {maxIndex + 1})");
        }

        static void DisplayLowestScore(int[] scores)
        {
            int minScore = scores[0];
            int minIndex = 0;
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < minScore)
                {
                    minScore = scores[i];
                    minIndex = i;
                }
            }
            Console.WriteLine($"Lowest exam score: {minScore} (Student {minIndex + 1})");
        }

        static void DisplayAverageScore(int[] scores)
        {
            double totalScore = 0;
            foreach (int score in scores)
            {
                totalScore += score;
            }
            double averageScore = totalScore / scores.Length;
            Console.WriteLine($"Average exam score: {averageScore}");
        }
    }
}
