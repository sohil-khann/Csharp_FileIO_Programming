/*
 * 3. Read User Input from Console
 * Problem Statement: Write a program that asks the user for their 
 * name, age, and favorite programming language, then saves this 
 * information into a file. 
 * Requirements: Use StreamReader for console input. Use StreamWriter 
 * to write the data into a file. Handle exceptions properly.
 */
using System;
using System.IO;

namespace StreamPracticeProblems.Problems
{
    public class UserInputToFile
    {
        public static void Run()
        {
            string filePath = "user_info.txt";

            try
            {
                // Requirement: Use StreamReader for console input
                using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    Console.WriteLine("Please enter your details below:");

                    Console.Write("Enter your Name: ");
                    string? name = reader.ReadLine();

                    Console.Write("Enter your Age: ");
                    string? age = reader.ReadLine();

                Console.Write("Enter your Favorite Programming Language: ");
                string? language = reader.ReadLine();

                DateTime datetime = DateTime.Now;

                // Writing to file
                   
                    writer.WriteLine($"Name: {name ?? "N/A"}");
                    writer.WriteLine($"Age: {age ?? "N/A"}");
                    writer.WriteLine($"Favorite Language: {language ?? "N/A"}");
                    writer.WriteLine($"Timestamp: {datetime}");

                    Console.WriteLine($"\nInformation successfully saved to {filePath}");
                }
                StreamReader Reader = new StreamReader(filePath);
               string read=Reader.ReadLine();
                Console.WriteLine("The content of the file is:");
                while (read!=null)
                { 
                    Console.WriteLine(read);
                     read=Reader.ReadLine();

                }
            }
         
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
