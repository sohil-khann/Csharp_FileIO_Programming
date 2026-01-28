/*
 * 5. ByteArray Stream - Convert Image to ByteArray
 * Problem Statement: Write a C# program that converts an image file 
 * into a byte array and then writes it back to another image file. 
 * Requirements: Use MemoryStream to handle byte arrays. Verify that the 
 * new file is identical to the original image. Handle IOException.
 */
using System;
using System.IO;
using System.Linq;

namespace StreamPracticeProblems.Problems
{
    public class ImageToByteArray
    {
        public static void Run()
        {
            string originalFile = "original_image.jpeg";
            string copiedFile = "copied_image.jpeg";

            // Create a dummy "image" file for demonstration
            // byte[] dummyImageData = new byte[5000];
            // new Random().NextBytes(dummyImageData);
            // File.WriteAllBytes(originalFile, dummyImageData);

            try
            {
                byte[] imageBytes;

                // 1. Read image to byte array using MemoryStream
                using (FileStream fs = new FileStream(originalFile, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        imageBytes = ms.ToArray();
                    }
                }
                Console.WriteLine($"Image converted to byte array. Size: {imageBytes.Length} bytes.");

                // 2. Write byte array back to another image file
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    using (FileStream fs = new FileStream(copiedFile, FileMode.Create, FileAccess.Write))
                    {
                        ms.WriteTo(fs);
                    }
                }
                Console.WriteLine($"Byte array written back to {copiedFile}.");

                // 3. Verify files are identical
                byte[] originalData = File.ReadAllBytes(originalFile);
                byte[] copiedData = File.ReadAllBytes(copiedFile);

                if (originalData.SequenceEqual(copiedData))
                {
                    Console.WriteLine("Verification Successful: The new file is identical to the original.");
                }
                else
                {
                    Console.WriteLine("Verification Failed: The files are different.");
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
