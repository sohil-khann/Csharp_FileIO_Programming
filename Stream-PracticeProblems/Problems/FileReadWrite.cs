/*
 * 1. File Handling - Read and Write a Text File
 * Problem Statement: Write a C# program that reads the contents of a 
 * text file and writes it into a new file. If the source file does not exist, 
 * display an appropriate message. 
 * Requirements: Use FileStream for reading and writing. Handle 
 * IOException properly. Ensure that the destination file is created if it does 
 * not exist.
 */
using System;
using System.IO;

namespace StreamPracticeProblems.Problems
{
    public class FileReadWrite
    {
        public static void Run()
        {
            string sourcePath = "source.txt";
            string destinationPath = "destination.txt";

            // Create a dummy source file for demonstration if it doesn't exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "This is the content of the source file.\nWelcome to C# File Handling!");
                Console.WriteLine("Source file created for demonstration.");
            }

            try
            {
                // Use FileStream for reading and writing as per requirements
                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destinationStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                Console.WriteLine("File copied successfully using FileStream.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The source file was not found.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
