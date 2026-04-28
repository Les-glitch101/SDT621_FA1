using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentResultsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt for student name
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            // Array to store marks
            int[] marks = new int[3];

            // Collect and validate marks
            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    Console.Write($"Enter mark for Subject {i + 1}: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int mark))
                    {
                        marks[i] = mark;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a numeric value.");
                    }
                }
            }

            // Calculate total and average
            int totalMarks = marks[0] + marks[1] + marks[2];
            double averageMarks = totalMarks / 3.0;

            // Determine result
            string resultStatus = averageMarks >= 50 ? "PASS" : "FAIL";

            // Display results
            Console.WriteLine("\n===== STUDENT RESULTS =====");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Average Marks: {averageMarks:F1}");
            Console.WriteLine($"Result: {resultStatus}");
            Console.WriteLine($"Result Issued At: {DateTime.Now:dd MMM yyyy HH:mm:ss}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
    }
