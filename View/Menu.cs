using crudRavendb.Controller;
using crudRavendb.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudRavendb.View
{
    class Menu
    {
        FunctionsController controller = new FunctionsController();

        public void menu()
        {
            string id;
            int skip, take;
            do
            {
                Console.WriteLine("Please, press:");
                Console.WriteLine("C - Create Company");
                Console.WriteLine("U - Update Company");
                Console.WriteLine("D - Delete a Company");
                Console.WriteLine("Q - Query all Company");
                Console.WriteLine("S - search Company by Id");
                Console.WriteLine("B - search range among all" +
                "\n(informe intervalo para buscar no BD)");

                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.C:
                        insert();
                        break;
                    case ConsoleKey.U:
                        Console.WriteLine("Insert ID: ");
                        id = Console.ReadLine();
                        controller.UpdateCompanyDataset(id);
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Insert ID: ");
                        id = Console.ReadLine();
                        controller.DeleteCompanyDataSet(id);
                        break;
                    case ConsoleKey.Q:
                        controller.GetAllCompanyDataset();
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Insert ID: ");
                        id = Console.ReadLine();
                        controller.GetCompanyDataSet(id);
                        break;
                    case ConsoleKey.B:
                        Console.WriteLine("New Average: ");
                        skip = int.Parse(Console.ReadLine());
                        take = int.Parse(Console.ReadLine());
                        controller.GetBetweenCompanyDataSet(skip,take);
                        break;
                }
            } while (true);
        }
        public void insert()
        {
            Console.WriteLine("New Rating: ");
            string rating = Console.ReadLine();

            Console.WriteLine("New Company: ");
            string company = Console.ReadLine();

            Console.WriteLine("New Average: ");
            string average = Console.ReadLine();

            Console.WriteLine("New Lowest: ");
            string lowest = Console.ReadLine();

            Console.WriteLine("New Highest: ");
            string highest = Console.ReadLine();

            Console.WriteLine("New Date: ");
            string date = Console.ReadLine();

            controller.CreateCompanyDataset(rating, company, average, lowest, highest, date);
        }
    }
}
