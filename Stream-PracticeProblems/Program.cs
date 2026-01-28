using System;
using StreamPracticeProblems.Problems;

namespace StreamPracticeProblems
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1. File Handling - Read and Write a Text File
            // FileReadWrite.Run();

            // 2. Buffered Streams - Efficient File Copy
            // BufferedFileCopy.Run();

            // 3. Read User Input from Console
            // UserInputToFile.Run();

            // 4. Serialization - Save and Retrieve an Object
            // EmployeeSerialization.Run();

            // 5. ByteArray Stream - Convert Image to ByteArray
            // ImageToByteArray.Run();

            // 6. Filter Streams - Convert Uppercase to Lowercase
            // UppercaseToLowercase.Run();

            // 7. Data Streams - Store and Retrieve Primitive Data
            // StudentDataBinary.Run();

            // 8. Piped Streams - Inter-Thread Communication
            PipedCommunication.Run();

            // 9. Read a Large File Line by Line
            // LargeFileErrorSearch.Run();

            // 10. Count Words in a File
            // WordFrequencyCounter.Run();

            Console.ReadKey();
        }
    }
}
