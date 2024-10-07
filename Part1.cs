using System;
using System.Text;

namespace Task1
{
    class Employee
    {

        private string name;    
        private int age;            
        private double salary;     

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)      
                    age = value;
                else
                    Console.WriteLine("Вік не може бути від'ємним або нульовим!");
            }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)    
                    salary = value;
                else
                    Console.WriteLine("Зарплата не може бути від'ємною!");
            }
        }

        public Employee(string name, int age, double salary)
        {
            Name = name;           
            Age = age;
            Salary = salary;
        }

        public static Employee operator +(Employee emp, double amount)
        {
            emp.Salary += amount; 
            return emp;
        }

        public static Employee operator -(Employee emp, double amount)
        {
            emp.Salary -= amount; 
            return emp;
        }

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.Salary == emp2.Salary; 
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2); 
        }

        public static bool operator <(Employee emp1, Employee emp2)
        {
            return emp1.Salary < emp2.Salary; 
        }

        public static bool operator >(Employee emp1, Employee emp2)
        {
            return emp1.Salary > emp2.Salary;  
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                return this == (Employee)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Salary.GetHashCode();  
        }

        public override string ToString()
        {
            return $"Ім'я: {Name}, Вік: {Age}, Заробітна плата: {Salary} грн";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            Employee emp1 = new Employee("Андрій Іванов", 35, 15000.0);
            Employee emp2 = new Employee("Оксана Петрівна", 42, 18000.0);

            Console.WriteLine("Початкові дані:");
            Console.WriteLine(emp1);
            Console.WriteLine(emp2);

            emp1 += 2000.0;
            Console.WriteLine("\nПісля збільшення зарплати:");
            Console.WriteLine(emp1);

            emp2 -= 1500.0;
            Console.WriteLine("\nПісля зменшення зарплати:");
            Console.WriteLine(emp2);

            Console.WriteLine("\nПеревірка на рівність зарплат:");
            Console.WriteLine(emp1 == emp2 ? "Зарплати рівні" : "Зарплати різні");

            Console.WriteLine("\nПорівняння зарплат:");
            Console.WriteLine(emp1 > emp2 ? "Зарплата першого співробітника більша" : "Зарплата другого співробітника більша");

            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
