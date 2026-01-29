using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BasicJsonHandling
{
    public class ObjToJson
    {
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
        }

        public static void Solution()
        {
            // Create a C# object list
            List<Car> cars = new List<Car>
            {
                new Car { Make = "Toyota", Model = "Camry", Year = 2020 },
                new Car { Make = "Honda", Model = "Civic", Year = 2019 },
                new Car { Make = "Ford", Model = "Mustang", Year = 2021 }
            };

            // Convert to JSON array
            JArray jsonCars = new JArray();
            for (int i=0;i<cars.Count;i++)
            {
            {
                JObject jsonCar = new JObject
                {
                    { "Make", cars[i].Make },
                    { "Model", cars[i].Model },
                    { "Year", cars[i].Year }
                };
                jsonCars.Add(jsonCar);
            }
            }
            // Convert to string and print
            string jsonString = jsonCars.ToString();
            Console.WriteLine(jsonString);
        }
    }
}