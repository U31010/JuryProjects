using System;
using System.Collections.Generic;

namespace testJuryNumberProject
{
    class Program
    {
        public class NumberPrinter
        {
            bool IsDotNeed { get; set; }
            int DisplayAfterDot { get; set; }
            public NumberPrinter(bool isNeedDot, int countAfterDot)
            {
                IsDotNeed = isNeedDot;
                DisplayAfterDot = countAfterDot;
            }

            public string Print(double valueToPrint)
            {
                valueToPrint = Math.Round(valueToPrint, DisplayAfterDot);
                string result = string.Empty;
                string pattern = $"F{DisplayAfterDot}";

                result = valueToPrint.ToString(pattern, System.Globalization.CultureInfo.InvariantCulture);
                if (IsDotNeed)
                {
                    if ((valueToPrint % 1) == 0)
                        result = result.Split('.')[0] + ".";
                }
                else
                {
                    if ((valueToPrint % 1) == 0)
                        result = result.Split('.')[0];
                }
                return result;
            }
        }
        static void Main(string[] args)
        {
            List<double> test = new List<double>() { 
                0.1,
                10,
                115,
                1234.5678,
                0.0126,
                .0789
            };

            bool isNeedDot = true;

            Console.WriteLine("DOT - 1");
            var printer = new NumberPrinter(isNeedDot, 1);
            foreach (var value in test)
                Console.WriteLine( printer.Print(value));
            Console.WriteLine("DOT - 2");
            printer = new NumberPrinter(isNeedDot, 2);
            foreach (var value in test)
                Console.WriteLine(printer.Print(value));
            Console.WriteLine("DOT - 3");
            printer = new NumberPrinter(isNeedDot, 3);
            foreach (var value in test)
                Console.WriteLine(printer.Print(value));

            isNeedDot = false;
            Console.WriteLine("W/O DOT - 1");
            printer = new NumberPrinter(isNeedDot, 1);
            foreach (var value in test)
                Console.WriteLine(printer.Print(value));
            Console.WriteLine("W/O DOT - 2");
            printer = new NumberPrinter(isNeedDot, 2);
            foreach (var value in test)
                Console.WriteLine(printer.Print(value));
            Console.WriteLine("W/O DOT - 3");
            printer = new NumberPrinter(isNeedDot, 3);
            foreach (var value in test)
                Console.WriteLine(printer.Print(value));

            Console.ReadKey();
            
        }
    }
}
