using System;
using System.Globalization;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("C# Calculator");
        Console.WriteLine("Operations: +  -  *  /  %");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter first number (or quit with q): ");
            string? firstInput = Console.ReadLine();
            if (firstInput is null || firstInput.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (!TryReadNumber(firstInput, out double firstNumber))
            {
                Console.WriteLine("Make sure to enter a valid number!");
                Console.WriteLine();
                continue;
            }

            Console.Write("Operator: ");
            string? operationInput = Console.ReadLine();
            if (operationInput is null || operationInput.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            string operation = operationInput.Trim();
            if (operation is not ("+" or "-" or "*" or "/" or "%"))
            {
                Console.WriteLine("Choose +, -, *, /, or %.");
                Console.WriteLine();
                continue;
            }

            Console.Write("Second number: ");
            string? secondInput = Console.ReadLine();
            if (secondInput is null || secondInput.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (!TryReadNumber(secondInput, out double secondNumber))
            {
                Console.WriteLine("Make sure to enter a valid number!");
                Console.WriteLine();
                continue;
            }

            if ((operation is "/" or "%") && secondNumber == 0)
            {
                Console.WriteLine("Can't divide by zero");
                Console.WriteLine();
                continue;
            }

            double result = operation switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => firstNumber / secondNumber,
                "%" => firstNumber % secondNumber,
                _ => throw new InvalidOperationException("Unsupported operation..")
            };

            Console.WriteLine($"Result: {result.ToString("G12", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
        }

        Console.WriteLine("Goodbye.");
    }

    private static bool TryReadNumber(string input, out double number)
    {
        return double.TryParse(
            input.Trim(),
            NumberStyles.Float,
            CultureInfo.CurrentCulture,
            out number);
    }
}
