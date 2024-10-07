using System;
using System.Text;

namespace Task3
{
    class CreditCard
    {

        private string ownerName;     
        private string cardNumber;     
        private float balance;        
        private int cvcCode;         

        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public float Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)      
                    balance = value;
                else
                    Console.WriteLine("Баланс не може бути від'ємним!");
            }
        }

        public int CvcCode
        {
            get { return cvcCode; }
            set
            {
                if (value >= 100 && value <= 999) 
                    cvcCode = value;
                else
                    Console.WriteLine("Невірний CVC код. Введіть тризначне число!");
            }
        }

        public CreditCard(string ownerName, string cardNumber, float balance, int cvcCode)
        {
            OwnerName = ownerName;    
            CardNumber = cardNumber;
            Balance = balance;
            CvcCode = cvcCode;
        }

        public static CreditCard operator +(CreditCard card, float amount)
        {
            card.Balance += amount;  
            return card;
        }

        public static CreditCard operator -(CreditCard card, float amount)
        {
            if (card.Balance >= amount)  
                card.Balance -= amount;  
            else
                Console.WriteLine("Недостатньо коштів на картці!");

            return card;
        }

        public static bool operator ==(CreditCard card1, CreditCard card2)
        {
            return card1.CvcCode == card2.CvcCode;  
        }

        public static bool operator !=(CreditCard card1, CreditCard card2)
        {
            return !(card1 == card2);
        }

        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return card1.Balance < card2.Balance;  
        }

        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return card1.Balance > card2.Balance;  
        }

        public override bool Equals(object obj)
        {
            if (obj is CreditCard)
            {
                return this == (CreditCard)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CvcCode.GetHashCode(); 
        }

        public override string ToString()
        {
            return $"Власник: {OwnerName}, Номер картки: {CardNumber}, Баланс: {Balance} грн, CVC код: {CvcCode}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            CreditCard card1 = new CreditCard("Іван Іванов", "1234-5678-9876-5432", 10000.0f, 123);
            CreditCard card2 = new CreditCard("Петро Петренко", "4321-8765-6789-1234", 5000.0f, 456);

            Console.WriteLine("Початкові дані:");
            Console.WriteLine(card1);
            Console.WriteLine(card2);

            card1 += 2000.0f;
            Console.WriteLine("\nПісля поповнення балансу:");
            Console.WriteLine(card1);

            card2 -= 1500.0f;
            Console.WriteLine("\nПісля зняття коштів:");
            Console.WriteLine(card2);

            Console.WriteLine("\nПеревірка на рівність CVC кодів:");
            Console.WriteLine(card1 == card2 ? "CVC коди однакові" : "CVC коди різні");

            Console.WriteLine("\nПорівняння балансів карток:");
            Console.WriteLine(card1 > card2 ? "Баланс першої картки більший" : "Баланс другої картки більший");

            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
