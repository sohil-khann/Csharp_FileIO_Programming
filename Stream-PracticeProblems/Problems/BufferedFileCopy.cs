/*
 * 2. Buffered Streams - Efficient File Copy
 * Problem Statement: Create a C# program that copies a large file 
 * (e.g., 100MB) from one location to another using Buffered Streams 
 * (BufferedStream). Compare the performance with normal file streams. 
 * Requirements: Read and write in chunks of 4 KB (4096 bytes). Use 
 * Stopwatch to measure execution time. Compare execution time with 
 * unbuffered streams.
 */
using System;
using System.Diagnostics;
using System.IO;

namespace StreamPracticeProblems.Problems
{
    public class BufferedFileCopy
    {
        public static void Run()
        {
            string sourceFile = "large_test_file.bin";
            string unbufferedDest = "unbuffered_copy.bin";
            string bufferedDest = "buffered_copy.bin";
            int fileSizeInMb = 100;
            int bufferSize = 4096; // 4 KB

            // 1. Create a large dummy file if it doesn't exist
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"Creating a {fileSizeInMb}MB test file.");
                byte[] data = new byte[1024 * 1024]; // 1MB buffer
                new Random().NextBytes(data);
                using (FileStream fs = new FileStream(sourceFile, FileMode.Create))
                {
                    for (int i = 0; i < fileSizeInMb; i++)
                    {
                        fs.Write(data, 0, data.Length);
                    }
                }
                Console.WriteLine("Test file created.");
            }

            try
            {
                // 2. Unbuffered Copy
                Stopwatch sw = Stopwatch.StartNew();
                CopyUnbuffered(sourceFile, unbufferedDest, bufferSize);
                sw.Stop();
                long unbufferedTime = sw.ElapsedMilliseconds;
                Console.WriteLine($"Unbuffered copy took: {unbufferedTime} ms");

                // 3. Buffered Copy
                sw.Restart();
                CopyBuffered(sourceFile, bufferedDest, bufferSize);
                sw.Stop();
                long bufferedTime = sw.ElapsedMilliseconds;
                Console.WriteLine($"Buffered copy took: {bufferedTime} ms");

                Console.WriteLine($"Performance Improvement: {unbufferedTime - bufferedTime} ms");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
           
        }

        private static void CopyUnbuffered(string source, string dest, int bufferSize) //copy usinng  unbuffered stream
        {
            using (FileStream fsIn = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (FileStream fsOut = new FileStream(dest, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int read;
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
            }
        }

        private static void CopyBuffered(string source, string dest, int bufferSize)//copy using buffered stream 
        {
            using (FileStream fsIn = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (BufferedStream bsIn = new BufferedStream(fsIn))
            using (FileStream fsOut = new FileStream(dest, FileMode.Create, FileAccess.Write))
            using (BufferedStream bsOut = new BufferedStream(fsOut))
            {
                byte[] buffer = new byte[bufferSize];
                int read;
                while ((read = bsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bsOut.Write(buffer, 0, read);
                }
            }
        }
    }
}
