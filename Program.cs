using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_20
{
    class Program
    {
        static void Main()
        {
            string[] currencies = { "USD", "EUR", "JPY" };
            double[] amounts = { 500, 300, 10000 };

            string[] rateCurrency = { "USD", "EUR", "JPY" };
            DateTime[] rateDate = {
            new DateTime(2025, 8, 13),
            new DateTime(2025, 8, 14),
            new DateTime(2025, 8, 10)
        };
            double[] rateValue = { 56.0, 61.5, 0.39 };

            DateTime valuationDate = new DateTime(2025, 8, 14);
            double total = 0;

            Console.WriteLine("Portfolio Values:");
            for (int i = 0; i < currencies.Length; i++)
            {
                double value = 0;
                bool found = false;
                DateTime foundDate = DateTime.MinValue;

                for (int j = 0; j < rateCurrency.Length; j++)
                {
                    if (currencies[i] == rateCurrency[j] && rateDate[j] <= valuationDate)
                    {
                        if (rateDate[j] > foundDate)
                        {
                            foundDate = rateDate[j];
                            value = amounts[i] * rateValue[j];
                            found = true;
                        }
                    }
                }

                if (found && (valuationDate - foundDate).Days <= 2)
                {
                    Console.WriteLine(currencies[i] + ": " + value.ToString("0.00") + " PHP");
                    total += value;
                }
                else
                {
                    Console.WriteLine(currencies[i] + ": STALE or missing rate");
                }
            }

            Console.WriteLine("Total Portfolio: " + total.ToString("0.00") + " PHP");
        }
    }
}
            