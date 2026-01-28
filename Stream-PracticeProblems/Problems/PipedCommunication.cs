/*
 * 8. Piped Streams - Inter-Thread Communication
 * Problem Statement: Implement a C# program where one thread 
 * writes data into a PipeStream and another thread reads data from it. 
 * Requirements: Use two threads for reading and writing. Synchronize 
 * properly to prevent data loss. Handle IOException.
 */
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace StreamPracticeProblems.Problems
{
    public class PipedCommunication
    {
        public static void Run()
        {
            try
            {
                using (AnonymousPipeServerStream pipeServer =new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.None))
                {
                    string clientHandle = pipeServer.GetClientHandleAsString();

                    Thread readerThread = new Thread(ReadFromPipe)
                    {
                        Name = "ReaderThread"
                    };
                    readerThread.Start(clientHandle);


                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        Console.WriteLine("[Writer Thread] Sending messages to the pipe...");
                        sw.WriteLine("Message 1: Hello from the Writer Thread!");
                        sw.WriteLine("Message 2: Piped streams are useful for IPC.");
                        sw.WriteLine("STOP"); // Signal to stop
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[Main Thread] I/O Error: {ex.Message}");
            }
        }

        private static void ReadFromPipe(object? pipeHandle)
        {
            try
            {
                string? handle = pipeHandle as string;
                if (string.IsNullOrEmpty(handle)) return;

                using (AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, handle))
                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    string? message;
                    while ((message = sr.ReadLine()) != null)
                    {
                        if (message == "STOP") break;
                        Console.WriteLine($"[Reader Thread] Received: {message}");
                    }
                }
                Console.WriteLine("[Reader Thread] Finished reading and closed.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[Reader Thread] I/O Error: {ex.Message}");
            }
        }
    }
}