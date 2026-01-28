# C# File I/O and CSV Practice Problems

This repository contains a collection of C# practice problems focused on File I/O, Streams, and CSV processing. The problems are categorized into two main projects:

## 1. Stream Practice Problems (`Stream-PracticeProblems`)
Focuses on fundamental C# streams and file handling techniques.

### Problems:
1. **File Read/Write with FileStream**: Basic reading and writing using `FileStream`.
2. **Buffered vs Unbuffered Copy**: Comparing performance between standard and `BufferedStream`.
3. **StreamReader and StreamWriter**: Practical usage for text file manipulation.
4. **MemoryStream Processing**: Handling data in memory without physical files.
5. **Binary Data Handling**: Using `BinaryReader` and `BinaryWriter` for structured data.
6. **Thread-Safe File Logging**: Implementing a basic logger for multi-threaded environments.
7. **Anonymous Pipes**: Inter-process communication using pipes.
8. **File Compression**: Compressing and decompressing files using `GZipStream`.
9. **Object Serialization**: Saving and loading objects using JSON serialization.
10. **Custom Stream Wrapper**: Creating a custom stream for basic encryption/decryption.

## 2. CSV Practice Problems (`CSV_PracticeProblems`)
Intermediate and advanced problems specifically for CSV data manipulation.

### Problems:
1. **Read Data from CSV**: Basic reading and printing of CSV records.
2. **Write Data to CSV**: Creating a CSV file from programmatic data.
3. **Read and Count Rows**: Counting records in a CSV (excluding header).
4. **Filter Records**: Extracting specific records based on criteria (e.g., marks > 80).
5. **Search for a Record**: Finding specific data by a key (e.g., employee name).
6. **Modify CSV Value**: Updating specific fields (e.g., 10% salary hike for IT).
7. **Sort CSV Records**: Ordering data by a specific column (e.g., Salary descending).
8. **Validate CSV Data**: Using Regex to validate Email and Phone number formats.
9. **Convert CSV to Objects**: Mapping CSV rows to C# class objects.
10. **Merge Two CSV Files**: Combining two files based on a common ID.
11. **Large CSV Processing**: Efficiently reading 500MB+ files in small chunks.
12. **Detect Duplicates**: Identifying duplicate records based on ID.
13. **Database to CSV**: Simulating database export to a CSV report.
14. **JSON <-> CSV Converter**: Interchanging data between JSON and CSV formats.
15. **Encrypt CSV Data**: Protecting sensitive fields using encryption while writing.

## How to Run
1. Navigate to the desired project folder:
   ```bash
   cd Stream-PracticeProblems
   # or
   cd CSV_PracticeProblems
   ```
2. Open `Program.cs` and uncomment the problem you want to execute.
3. Run the project:
   ```bash
   dotnet run
   ```

All sample data files are automatically generated in the `DataFiles` directory within each project.
