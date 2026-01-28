/*
 * 6. Filter Streams - Convert Uppercase to Lowercase
 * Problem Statement: Create a program that reads a text file and 
 * writes its contents into another file, converting all uppercase letters to 
 * lowercase. 
 * Requirements: Use StreamReader and StreamWriter. Use 
 * BufferedStream for efficiency. Handle character encoding issues.
 */
using System;
using System.IO;
using System.Text;

namespace StreamPracticeProblems.Problems
{
    public class UppercaseToLowercase
    {
        public static void Run()
        {
            string inputFile = "input_uppercase.txt";
            string outputFile = "output_lowercase.txt";

            // Create input file with some uppercase content
            File.WriteAllText(inputFile, "HELLO WORLD! THIS IS A TEST FILE WITH UPPERCASE LETTERS.");

            try
            {
                // Use UTF-8 encoding to handle character encoding issues
                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (BufferedStream bsIn = new BufferedStream(fsIn))
                using (StreamReader reader = new StreamReader(bsIn, Encoding.UTF8))
                using (FileStream fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (BufferedStream bsOut = new BufferedStream(fsOut))
                using (StreamWriter writer = new StreamWriter(bsOut, Encoding.UTF8))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Convert to lowercase and write
                        writer.WriteLine(line.ToLower());
                      
                    }
                }

                Console.WriteLine($"File processed successfully. Content from {inputFile} converted to lowercase in {outputFile}.");

                // Display the output file content
                string outputContent = File.ReadAllText(outputFile);
                Console.WriteLine("Output File Content:");
                Console.WriteLine(outputContent);

            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
