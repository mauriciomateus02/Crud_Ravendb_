using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using crudRavendb.Modal;
using crudRavendb.Raven;

namespace crudRavendb.Controller
{
    class FunctionsController
    {
        public  void CreateCompanyDataset(string Rating, string Company, string Average, string Lowest, string Highest, string Date )
        {
            DataSet data = new DataSet();

            data.Rating = Rating;
            data.Company = Company;
            data.Average = Average;
            data.Lowest = Lowest;
            data.Highest = Highest;
            data.Date = Date;

            SessionCreate(data);
        }


        public  void UpdateCompanyDataset(string id)
        {
            SessionUpdateDataSet(id);
        }

        public  void GetCompanyDataSet(string id)
        {
            GetDataSet(id);
        }


        public void GetAllCompanyDataset()
        {
            AllDataSet();
        }


        public  void GetBetweenCompanyDataSet(int skip, int take)
        {
            GetDataSet(skip, take);
        }

        public  void DeleteCompanyDataSet(string id)
        {
            SessionDeleteCompany(id);
        }

       
        //------------------CREATE COMPANY -----------------------//

        private static void SessionCreate(DataSet data)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(data);
                session.SaveChanges();

            }
        }
        //----------------------------FIM CREATE COMAPNY ----------------------------//

        //------------------------------ UPDATE COMPANY------------------------------------//

        private static void UpdateDataSet(DataSet data)
        {

            Console.WriteLine($"Actual Rating: {data.Rating}");
            Console.WriteLine("New Rating: ");
            data.Rating = Console.ReadLine();

            Console.WriteLine($"Actual Company: {data.Company}");
            Console.WriteLine("New Company: ");
            data.Company = Console.ReadLine();

            Console.WriteLine($"Actual Average: {data.Average}");
            Console.WriteLine("New Average: ");
            data.Average = Console.ReadLine();

            Console.WriteLine($"Actual Lowest: {data.Lowest}");
            Console.WriteLine("New Lowest: ");
            data.Lowest = Console.ReadLine();

            Console.WriteLine($"Actual Highest: {data.Highest}");
            Console.WriteLine("New Highest: ");
            data.Highest = Console.ReadLine();

            Console.WriteLine($"Actual Date: {data.Date}");
            Console.WriteLine("New Date: ");
            data.Date = Console.ReadLine(); 

        }

        private static void SessionUpdateDataSet(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                DataSet data = session.Load<DataSet>(id);

                if (data == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                 UpdateDataSet(data);

                session.SaveChanges();
            }
        }

        //-------------------FIM UPDATE --------------------------------------------//

        //------------------------GET DATASET---------------------------------------//
        private static void GetDataSet(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                DataSet data = session.Load<DataSet>(id);

                if (data == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                Console.WriteLine($"id: {data.Id} | {data.Rating} | { data.Company} | { data.Average} | { data.Lowest} | { data.Highest} | { data.Date}");

            }

        }


        private static void GetDataSet(int pageNdx, int pageSize)
        {
            int skip = (pageNdx - 1) * pageSize;
            int take = pageSize;

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                List<DataSet> data = session.Query<DataSet>()
                    .Statistics(out QueryStatistics stats)
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                if (data == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                Console.WriteLine($" Resultado da Pesquisa de {skip + 1} até {skip + pageSize} de {stats.TotalResults}");

                view(data);
            }
        }


        private static void AllDataSet()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                List<DataSet> data = session.Query<DataSet>().ToList();

                view(data);
            }
        }
        
        //--------------------------END GET DATASET-------------------------------//

        //---------------------------Delete ---------------------------//
        private static void SessionDeleteCompany(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                DataSet data = session.Load<DataSet>(id);

                if (data == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                session.Delete(data);
                session.SaveChanges();

            }
        }
    //-----------------------------END DELETE --------------------------------------//

        private static void view(List<DataSet> all)
        {

            foreach(DataSet data in all)
            {
                Console.WriteLine($"id: {data.Id} | {data.Rating} | { data.Company} | { data.Average} | { data.Lowest} | { data.Highest} | { data.Date}");
            }
        }
    }
}
