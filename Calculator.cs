using System;

class Program
{
    static void Main()
    {
        Console.Title = "C# Calculator";
        Console.WindowWidth = 31;
        Console.WindowHeight = 20;
        decimal result = 0;
        decimal num1;
        decimal num2;
        decimal num3;
        string num1string;
        string num2string;
        string num3string;
        string choicestring;
        string more;
        int choice;
    poczatek:
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" -       C# Calculator       -");
        Console.WriteLine("\n------------------------------");
        Console.Write("Choose your operation:\n1 - addition\n2 - substraction\n3 - multiplying\n4 - division\n\nChoice: ");
        choicestring = Console.ReadLine();
        if (int.TryParse(choicestring, out choice))
        {
            if (choice < 1 && choice > 4)
            {
                OperationError();
                Console.ReadKey();
                Console.Clear();
                goto poczatek;
            }
        liczba1:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("First number: ");
            num1string = Console.ReadLine();
            if (decimal.TryParse(num1string, out num1) == false)
            {
                NonIntegralError();
                goto liczba1;
            }
        liczba2:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Second number: ");
            num2string = Console.ReadLine();
            if (decimal.TryParse(num2string, out num2) == false)
            {
                NonIntegralError();
                goto liczba2;
            }
            if (choice == 1)
                result = num1 + num2;
            else if (choice == 2)
                result = num1 - num2;
            else if (choice == 3)
                result = num1 * num2;
            else if (choice == 4)
            {
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Don't divide by zero!");
                    goto liczba2;
                }
            }
            Console.WriteLine("\nResult: " + result + "\n------------------------------");
            Console.Write("Do you want to act\non the result? (yes/no): ");
            more = Console.ReadLine();
            Console.Clear();
            if (more == "yes")
            {
                int i = 0;
                while (i < 1)
                {
                    Console.WriteLine("------------------------------");
                liczbaponow:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Operation: ");
                    choicestring = Console.ReadLine();
                    if (int.TryParse(choicestring, out choice) == false)
                    {
                        NonIntegralError();
                        goto liczbaponow;
                    }
                    Console.Write("Number: ");
                    num3string = Console.ReadLine();
                    if (decimal.TryParse(num3string, out num3))
                    {
                        if (choice == 1)
                            result = result + num3;
                        else if (choice == 2)
                            result = result - num3;
                        else if (choice == 3)
                            result = result * num3;
                        else if (choice == 4)
                            if (num3 != 0)
                                result = result / num3;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Don't divide by zero!");
                                goto liczbaponow;
                            }
                        else
                        {
                            OperationError();
                            goto liczbaponow;
                        }
                        Console.WriteLine("\nResult: " + result + "\n------------------------------");
                        Console.Write("Do you want to act\non the result? (yes/no): ");
                        more = Console.ReadLine();
                        if (more == "no")
                        {
                            i++;
                        }
                        else if (more == "yes") {}
                    }
                    else
                    {
                        NonIntegralError();
                        goto liczbaponow;
                    }
                }
                Console.Clear();
                goto poczatek;
            }
            else if (more == "no")
            {
                Console.Clear();
                goto poczatek;
            }
        }
        else
        {
            NonIntegralError();
            Console.ReadKey();
            Console.Clear();
            goto poczatek;
        }
    }
    static void NonIntegralError()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please write a NUMBER!");
    }
    static void OperationError()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please give a number between 1 and 4!");
    }
}