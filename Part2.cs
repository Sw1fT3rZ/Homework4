using System;
using System.Text;

namespace Task2
{
    class City
    {
        private string name;
        private int population;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Population
        {
            get { return population; }
            set
            {
                if (value >= 0)
                    population = value;
                else
                    Console.WriteLine("Населення не може бути від'ємним значенням!");
            }
        }


        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public static City operator +(City city, int amount)
        {
            city.Population += amount;
            return city;
        }

        public static City operator -(City city, int amount)
        {
            city.Population -= amount;
            return city;
        }

        public static bool operator ==(City city1, City city2)
        {
            return city1.Population == city2.Population;
        }

        public static bool operator !=(City city1, City city2)
        {
            return !(city1 == city2);
        }

        public static bool operator <(City city1, City city2)
        {
            return city1.Population < city2.Population;
        }

        public static bool operator >(City city1, City city2)
        {
            return city1.Population > city2.Population;
        }

        public override bool Equals(object obj)
        {
            if (obj is City)
            {
                return this == (City)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Population.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} з населенням: {Population} осіб.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            City city1 = new City("Київ", 2800000);
            City city2 = new City("Львів", 750000);

            Console.WriteLine("Початкові дані:");
            Console.WriteLine(city1);
            Console.WriteLine(city2);

            city1 += 50000;
            Console.WriteLine("\nПісля збільшення населення:");
            Console.WriteLine(city1);

            city2 -= 10000;
            Console.WriteLine("\nПісля зменшення населення:");
            Console.WriteLine(city2);

            Console.WriteLine("\nПеревірка на рівність населення:");
            Console.WriteLine(city1 == city2 ? "Населення рівне" : "Населення різне");

            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
