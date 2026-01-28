/*
 * 7. Data Streams - Store and Retrieve Primitive Data
 * Problem Statement: Write a C# program that stores student details 
 * (roll number, name, GPA) in a binary file and retrieves it later. 
 * Requirements: Use BinaryWriter to write primitive data. Use 
 * BinaryReader to read data. Ensure proper closing of resources.
 */
using System;
using System.IO;

namespace StreamPracticeProblems.Problems
{
    public class StudentDataBinary
    {
        public static void Run()
        {
            string fileName = "student_data.dat";

            // Sample data
            int rollNumber = 101;
            string name = "sohil khan";
            double gpa = 3.85;

            try
            {
                // 1. Write primitive data to binary file
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(rollNumber);
                    writer.Write(name);
                    writer.Write(gpa);
                }
                Console.WriteLine("Student data successfully stored in binary format.");

                // 2. Read primitive data from binary file
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int readRoll = reader.ReadInt32();
                    string readName = reader.ReadString();
                    double readGpa = reader.ReadDouble();

                    Console.WriteLine("\nRetrieved Student Details:");
                    Console.WriteLine($"Roll Number: {readRoll}");
                    Console.WriteLine($"Name: {readName}");
                    Console.WriteLine($"GPA: {readGpa}");
                }
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
