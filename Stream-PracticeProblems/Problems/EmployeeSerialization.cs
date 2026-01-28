/*
 * 4. Serialization - Save and Retrieve an Object
 * Problem Statement: Design a C# program that allows a user to store 
 * a list of employees in a file using Object Serialization and later retrieve 
 * the data from the file. 
 * Requirements: Create an Employee class with fields: id, name, 
 * department, salary. Serialize the list of employees into a file 
 * (BinaryFormatter / JSON Serialization). Deserialize and display the 
 * employees from the file. Handle exceptions properly.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StreamPracticeProblems.Problems
{
    // Employee class as per requirements
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name ?? "N/A"}, Dept: {Department ?? "N/A"}, Salary: {Salary:C}";
        }
    }

    public class EmployeeSerialization
    {
        public static void Run()
        {
            string fileName = "employees.json";
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 101, Name = "Sohil", Department = "HR", Salary = 55000 },
                new Employee { Id = 102, Name = "Raj", Department = "IT", Salary = 75000 },
                new Employee { Id = 103, Name = "Charan", Department = "Finance", Salary = 65000 }
            };

            try
            {
                string jsonString= JsonSerializer.Serialize(employees,new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, jsonString);
                Console.WriteLine($"Employees serialized to {fileName}");
                string readJson=File.ReadAllText(fileName);
                List<Employee>? deserializedEmployees=JsonSerializer.Deserialize<List<Employee>>(readJson);
                Console.WriteLine("Deserialized Employees:");
                if (deserializedEmployees != null)
                {
                    foreach (var emp in deserializedEmployees)
                    {
                        Console.WriteLine(emp.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No employees found after deserialization.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Serialization Error: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
