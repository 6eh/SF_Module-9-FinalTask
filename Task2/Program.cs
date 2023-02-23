using System;

namespace Task2
{
    class Program
    {
        public static string[] Peoples = { "Pushkin", "Lermontov", "Bulgakov", "Tolstoy", "Dostoevsky" };

        

        static void Main(string[] args)
        {
            while(true)
            {
                PeoplesSorter peoplesSorter = new();
                peoplesSorter.PeoplesSortEvent += Sorting;
                try
                {
                    peoplesSorter.SortingMethod();
                }
                catch (MyException ex)
                {
                    Console.WriteLine($"{ex.Data["ExceptionDate"]}: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Your void is not correct!");
                }
                finally
                {
                    Console.WriteLine($"\n{DateTime.Now}: Finish!\n");
                }
            }
        }

        static void Sorting(int number)
        {
            switch (number)
            {
                case 1: SortingAZ(); break;
                case 2: SortingZA(); break;
            }
        }

        static void SortingAZ()
        {
            Array.Sort(Peoples);
            Console.WriteLine();
            foreach (var people in Peoples)
                Console.WriteLine(people);
        }

        static void SortingZA()
        {
            Array.Sort(Peoples);
            Console.WriteLine();
            for (int i = Peoples.Length-1; i >= 0; i--)
            {
                Console.WriteLine(Peoples[i]);
            }
        }
    }

    public class PeoplesSorter
    {
        public delegate void PeoplesDelegate(int number);
        public event PeoplesDelegate PeoplesSortEvent;

        public void SortingMethod()
        {
            Console.WriteLine("---");
            Console.WriteLine("Please enter voids:");
            Console.WriteLine("   1 - for sorting A-Z");
            Console.WriteLine("   2 - for sorting Z-A");
            Console.Write(": ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2)
                throw new MyException("Please, enter '1' or '2'!");

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            PeoplesSortEvent?.Invoke(number);
        }
    }

    public class MyException : Exception
    {

        public MyException(string message) : base(message) // Переопределение сообщения (message) у класса Exception
        {
            this.Data.Add("ExceptionDate", DateTime.Now);
            this.HelpLink = "ya.ru";
        }
    }
}

