using System;
using System.Globalization;
using System.Text;

using CreditSuisse.App.Domain.Repository;

namespace CreditSuisse.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine($"Bem-Vindo, {DateTime.Today:MM/dd/yyyy}!");
            Console.WriteLine();
            Console.WriteLine("Sample input:");
            Console.WriteLine();

            string line;
            List<string> lines = new();
            do
            {
                line = Console.ReadLine();
                if (!string.IsNullOrEmpty(line)) lines.Add(line);
            } while (!string.IsNullOrEmpty(line));

            List<Category> result = Program.Execute(lines);

            Console.WriteLine();
            Console.WriteLine($"{Environment.NewLine} Sample output:");

            foreach (Category category in result)
            {
                Console.WriteLine($"{category.Name}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"{Environment.NewLine} Press any key to exit...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static List<Category> Execute(List<string> lines)
        {
            List<Category> categories = new();
            DateTime dataRef = Convert.ToDateTime(lines[0]);

            foreach (var line in lines)
            {
                var category = ApplyRuleInTrade(line, dataRef);

                if (category != null)
                {
                    categories.Add(new Category { Name = category });
                }
            }

            return categories;
        }

        /// <summary>
        /// Apply rules in data trades
        /// </summary>
        /// <param name="line"></param>
        /// <param name="dataRef"></param>
        /// <returns>Category</returns>
        public static string ApplyRuleInTrade(string line, DateTime dataRef)
        {
            string result = null;

            if (line.Split(" ").Length == 3 )
            {
                double value = Convert.ToDouble(line.Split(" ")[0]);
                string clientSector = line.Split(" ")[1];
                DateTime dateNextPayment = Convert.ToDateTime(line.Split(" ")[2], new CultureInfo("en-US"));

                if (value > 1000000)
                {
                    if (clientSector == "Private")
                    {
                        result = "HIGHRISK";
                    }
                    if (clientSector == "Public")
                    {
                        result = "MEDIUMRISK";
                    }
                }
                else if (dateNextPayment.AddDays(30) < dataRef)
                {
                    result = "EXPIRED";
                }
            }

            return result;
        }
    }
}
