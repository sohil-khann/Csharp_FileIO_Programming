/*
️⃣Read a CSV File and Print Data
● Read a CSV file containing student details (ID, Name, Age, Marks).
● Print each record in a structured format.

*/
using System;
using System.IO;
using System.Text;
namespace CSV_PracticeProblems.Problems;
public class ReadCSV
{
    public static void Solution() //Main method
    {
        String filePath = "./DataFiles/students.csv";
         if (!File.Exists(filePath))//Check if file exists
            {
                File.Create(filePath).Close();
                Console.WriteLine("CSV file created at: " + filePath);
            }
        try
        {
            using(FileStream fs=new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite)) //FileStream to read and write
            {
                byte[] data = Encoding.UTF8.GetBytes("ID,Name,Age,Marks\n1,Sohil,20,85\n2,Jaadu,22,90\n3,Oggy,19,78\n");
                fs.Write(data, 0, data.Length);
        }

            using (StreamReader sr=new StreamReader(filePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);

                }
            }
        }catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}