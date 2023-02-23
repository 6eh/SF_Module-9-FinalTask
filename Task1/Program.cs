using System;

namespace Task1
{
    class Program
    {
        class MyException : Exception
        {
            public MyException(string message) : base(message) // Переопределение сообщения (message) у класса Exception
            {
                this.Data.Add("ExceptionDate", DateTime.Now);
                this.HelpLink = "ya.ru";
            }
        }

        static void Main(string[] args)
        {
            Exception[] exceptions = {
                new ApplicationException(),
                new AccessViolationException(),
                new MyException("This is Custom Exception."),
                new ArgumentException(),
                new ArithmeticException()};

            foreach (var exception in exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType()} > {ex.Message}");
                    if (ex is MyException)
                    {
                        Console.WriteLine($"Exception Date: {ex.Data["ExceptionDate"]}");
                        Console.WriteLine($"Help link: {ex.HelpLink}");
                    }
                }
                finally
                {
                    Console.WriteLine("- - -");
                }
            }
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}

